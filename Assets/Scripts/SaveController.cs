using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Unity.Services.CloudSave;
using UnityEngine;

public class SaveFileInfo{
    public string timestamp;
    public string coordinate;
    public int difficulty;
    public int current_days;
}

public class StrippedGameController{
    public int elapsed_hours;
    public int current_hours;
    public bool morning;
    public int current_days;
    public int prev_remainder;
    public int temperature;
    public int next_trend_temperature;
    public int next_trend_time;
    public int next_storm_time;
    public int current_storm_hour;
    public int target_temperature;
    public bool is_first_storm;
    public int happyness;
    public int protest_hours;
    public int base_cooling;
    public int leader_type;
}

public static class SaveController
{
    [System.Serializable]
    public class SaveData{
        public string game_options;
        public string game_controller;
        public string buildings;
        public string residents;

        public SaveData(string game_options, string game_controller, string buildings, string residents){
            this.game_options = game_options;
            this.game_controller = game_controller;
            this.buildings = buildings;
            this.residents = residents;
        }
    }

    public class LoadedGameOptions{
        public int coordinate;
        public int difficulty;
        public int overall_costs;
        public int overall_discontent;
        public int storm_duration;
        public int storm_intensity;
        public string game_controller;
    }

    public class LoadedBuildings{
        public Building[] buildings;
    }

    public class LoadedResidents{
        public Resident[] residents;
    }

    private static string[] paths = FillPaths();

    private static string[] FillPaths(){
        string[] paths = new string[4];
        paths[0] = Application.persistentDataPath + "/Saves/AutoSave.save";
        paths[1] = Application.persistentDataPath + "/Saves/ManualSave1.save";
        paths[2] = Application.persistentDataPath + "/Saves/ManualSave2.save";
        paths[3] = Application.persistentDataPath + "/Saves/ManualSave3.save";
        return paths;
    }
    public static void SaveGameData(StrippedGameController stripped_game_controller, int save_slot){
        string path = paths[save_slot];
        string game_options = JsonConvert.SerializeObject(new {
            coordinate = GameOptions.coordinate,
            overall_costs = GameOptions.overall_costs,
            difficulty = GameOptions.difficulty,
            overall_discontent = GameOptions.overall_discontent,
            storm_duration = GameOptions.storm_duration,
            storm_intensity = GameOptions.storm_intensity });
        /*string game_controller = JsonConvert.SerializeObject(new {
            elapsed_hours = stripped_game_controller.elapsed_hours,
            current_hours = stripped_game_controller.current_hours,
            morning = stripped_game_controller.morning,
            current_days = stripped_game_controller.current_days,
            prev_remainder = stripped_game_controller.prev_remainder,
            temperature = stripped_game_controller.temperature,
            next_trend_temperature = stripped_game_controller.next_trend_temperature,
            next_trend_time = stripped_game_controller.next_trend_time,
            next_storm_time = stripped_game_controller.next_storm_time,
            current_storm_hour = stripped_game_controller.current_storm_hour,
            target_temperature = stripped_game_controller.target_temperature,
            is_first_storm = stripped_game_controller.is_first_storm,
            happyness = stripped_game_controller.happyness,
            protest_hours = stripped_game_controller.protest_hours,
            base_cooling = stripped_game_controller.base_cooling,
            leader_type = stripped_game_controller.leader_type });
        */
        //string buildings = JsonConvert.SerializeObject(new { buildings = Buildings.buildings });
        //string residents = JsonConvert.SerializeObject(new { residents = Residents.residents });
        SaveData save_data = new SaveData(game_options, "game_controller", "buildings", "residents");
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, save_data);
        stream.Close();
    }

    public static void LoadGameData(int save_slot){
        string path = paths[save_slot];
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        SaveData save_data = formatter.Deserialize(stream) as SaveData;
        stream.Close();
        LoadedGameOptions loaded_game_options = JsonConvert.DeserializeObject<LoadedGameOptions>(save_data.game_options);
        StrippedGameController loaded_game_controller = JsonConvert.DeserializeObject<StrippedGameController>(save_data.game_controller);
        LoadedBuildings loaded_buildings = JsonConvert.DeserializeObject<LoadedBuildings>(save_data.buildings);
        LoadedResidents loaded_residents = JsonConvert.DeserializeObject<LoadedResidents>(save_data.residents);
        GameOptions.coordinate = loaded_game_options.coordinate;
        GameOptions.overall_costs = loaded_game_options.overall_costs;
        GameOptions.overall_discontent = loaded_game_options.overall_discontent;
        GameOptions.storm_duration = loaded_game_options.storm_duration;
        GameOptions.storm_intensity = loaded_game_options.storm_intensity;
        GameOptions.game_controller = loaded_game_controller;
        Buildings.buildings = loaded_buildings.buildings;
        Residents.residents = loaded_residents.residents;
    }

    public static SaveFileInfo[] ReadSaveFileInfo(){
        SaveFileInfo[] save_file_info = new SaveFileInfo[4];

        for (int i = 0; i < 4; i++) {
            if (System.IO.File.Exists(paths[i])){
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(paths[i], FileMode.Open);
                SaveData save_data = formatter.Deserialize(stream) as SaveData;
                stream.Close();
                LoadedGameOptions loaded_game_options = JsonConvert.DeserializeObject<LoadedGameOptions>(save_data.game_options);
                StrippedGameController loaded_game_controller = JsonConvert.DeserializeObject<StrippedGameController>(save_data.game_controller);
                
                save_file_info[i] = new SaveFileInfo();
                save_file_info[i].timestamp = System.IO.File.GetLastWriteTime(paths[i]).ToString("yyyy/MM/dd HH:mm:ss");
                save_file_info[i].coordinate = Coordinates.coordinates[loaded_game_options.coordinate].name;
                save_file_info[i].difficulty = loaded_game_options.difficulty;
                save_file_info[i].current_days = loaded_game_controller.current_days;
            }
        }
        return save_file_info;
    }

    public static async void UploadSaveFiles(){
        for (int i = 0; i < 4; i++){
            if (System.IO.File.Exists(paths[i]))
            {
                byte[] file = System.IO.File.ReadAllBytes(paths[i]);
                await CloudSaveService.Instance.Files.Player.SaveAsync(paths[i].Split("Saves/")[paths[i].Split("Saves/").Length - 1].ToLower(), file);
            }
        }
    }

    public static async void DownloadSaveFiles(ReadSaveSlotInfo read_save_slot_info){
        for (int i = 0; i < 4; i++){
            try{
                byte[] file = await CloudSaveService.Instance.Files.Player.LoadBytesAsync(paths[i].Split("Saves/")[paths[i].Split("Saves/").Length - 1].ToLower());
                FileStream stream = new FileStream(paths[i], FileMode.Create);
                stream.Close();
                File.WriteAllBytes(paths[i], file);
            } catch(Exception ex){

            }
        }
        read_save_slot_info.ReadSaveSlots();
    }
}