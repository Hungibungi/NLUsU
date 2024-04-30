using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //GameObjects
    [SerializeField]
    private Text _clock;
    [SerializeField]
    private Text _game_speed;
    [SerializeField]
    private Image _day;
    [SerializeField]
    private Image _extended_day;
    [SerializeField]
    private Image _night;
    [SerializeField]
    private Text _temperature;
    [SerializeField]
    private Text _next_trend_time;
    [SerializeField]
    private Text _next_trend_temperature;
    [SerializeField]
    private Text _next_storm;
    [SerializeField]
    private Image _happy;
    [SerializeField]
    private Image _neutral;
    [SerializeField]
    private Image _sad;
    [SerializeField]
    private Image _protest;
    [SerializeField]
    private Text _residents;
    [SerializeField]
    private Image _residents_image;
    [SerializeField]
    private Text _workers;
    [SerializeField]
    private Text _children;
    [SerializeField]
    private Text _sick;
    [SerializeField]
    private Image _sick_image;
    public ReadSaveSlotInfoInGame read_save_slot_info;

    //variables
    public int start_time;
    public int elapsed_hours = 0;
    public int current_hours = 1;
    public bool morning = true;
    public int current_days = 1;
    public int prev_remainder = 0;
    public int temperature;
    public int next_trend_temperature = 10;
    public int next_trend_time;
    public int next_storm_time;
    public int current_storm_hour = 0;
    public int target_temperature;
    public bool is_first_storm = true;
    public int happyness = 50;
    public int protest_days = 0;

    void Start(){
        // clock widget
        start_time = (int)Time.time;
        _clock.text = "1 am";
        _game_speed.text = "1x";

        // day cycle widget
        AdjustDayCycle();

        // resources widget

        // weather widget
        target_temperature = 30 + (5 * (-3 + GameOptions.starting_temperature));
        temperature = target_temperature;
        next_trend_time = 55;
        next_storm_time = 24 * (14 - (3 - GameOptions.first_storm_timer)) + 7;
        _temperature.text = temperature + "°C";
        _next_trend_temperature.text = "+" + next_trend_temperature + "°C";
        _next_trend_temperature.color = Color.red;
        _next_trend_time.text = "in 2d7h";
        _next_storm.text = "in " + ((int)next_storm_time / 24) + "d" + next_storm_time % 24 + "h";

        // happyness widget
        AdjustHappyness();

        //residents widget
        AdjustResidents();

        if(GameOptions.game_controller != null){
            LoadGameController(GameOptions.game_controller);
            NextTick();
        }
    }

    public void LoadGameController(StrippedGameController game_controller){
        elapsed_hours = game_controller.elapsed_hours;
        current_hours = game_controller.current_hours;
        morning = game_controller.morning;
        current_days = game_controller.current_days;
        prev_remainder = game_controller.prev_remainder;
        temperature = game_controller.temperature;
        next_trend_temperature = game_controller.next_trend_temperature;
        next_trend_time = game_controller.next_trend_time;
        next_storm_time = game_controller.next_storm_time;
        current_storm_hour = game_controller.current_storm_hour;
        target_temperature = game_controller.target_temperature;
        is_first_storm = game_controller.is_first_storm;
        happyness = game_controller.happyness;
        protest_days = game_controller.protest_days;
    }

    public void BackToMainMenu(){
        GameOptions.game_controller = null;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menus");
    }

    public void ChangeGameSpeed(){
        switch(GameOptions.game_speed){
            case 1:
                GameOptions.game_speed = 2;
                _game_speed.text = GameOptions.game_speed + "x";
                break;
            case 2:
                GameOptions.game_speed = 5;
                _game_speed.text = GameOptions.game_speed + "x";
                break;
            case 5:
                GameOptions.game_speed = 10; // 10 makes the tick impossible, which causes the game to pause
                prev_remainder = 0; // safety measure to make sure there's no accidental tick after the game has been paused
                _game_speed.text = "paused";
                break;
            case 10:
                GameOptions.game_speed = 1;
                _game_speed.text = GameOptions.game_speed + "x";
                break;
        }
    }

    public void ChangeGameSpeed(int speed){
        GameOptions.game_speed = speed;
        _game_speed.text = GameOptions.game_speed==10?"paused":GameOptions.game_speed+"x";
    }

    void Update(){
        CheckTick();
    }

    private void CheckTick(){
        if(((int)Time.time - start_time) % (10 / GameOptions.game_speed) == 0 && prev_remainder != 0){
            prev_remainder = 0;
            elapsed_hours++;
            NextTick();
        }
        prev_remainder = ((int)Time.time - start_time) % (10 / GameOptions.game_speed);
    }

    private void NextTick(){
        CheckSave();
        AdjustClock();
        AdjustDayCycle();
        AdjustWeather();
        AdjustResidents();
        AdjustHappyness();
    }

    private void CheckSave(){
        if(elapsed_hours % GameOptions.autosave_frequency == 0){
            StrippedGameController stripped_game_controller = new StrippedGameController();
            stripped_game_controller.elapsed_hours = elapsed_hours;
            stripped_game_controller.current_hours = current_hours;
            stripped_game_controller.morning = morning;
            stripped_game_controller.current_days = current_days;
            stripped_game_controller.prev_remainder = prev_remainder;
            stripped_game_controller.temperature = temperature;
            stripped_game_controller.next_trend_temperature = next_trend_temperature;
            stripped_game_controller.next_trend_time = next_trend_time;
            stripped_game_controller.next_storm_time = next_storm_time;
            stripped_game_controller.current_storm_hour = current_storm_hour;
            stripped_game_controller.target_temperature = target_temperature;
            stripped_game_controller.is_first_storm = is_first_storm;
            stripped_game_controller.happyness = happyness;
            stripped_game_controller.protest_days = protest_days;
            SaveController.SaveGameData(stripped_game_controller, 0);
        }
    }

    public void SaveGame(int saveslot){
        StrippedGameController stripped_game_controller = new StrippedGameController();
        stripped_game_controller.elapsed_hours = elapsed_hours;
        stripped_game_controller.current_hours = current_hours;
        stripped_game_controller.morning = morning;
        stripped_game_controller.current_days = current_days;
        stripped_game_controller.prev_remainder = prev_remainder;
        stripped_game_controller.temperature = temperature;
        stripped_game_controller.next_trend_temperature = next_trend_temperature;
        stripped_game_controller.next_trend_time = next_trend_time;
        stripped_game_controller.next_storm_time = next_storm_time;
        stripped_game_controller.current_storm_hour = current_storm_hour;
        stripped_game_controller.target_temperature = target_temperature;
        stripped_game_controller.is_first_storm = is_first_storm;
        SaveController.SaveGameData(stripped_game_controller, saveslot);
        read_save_slot_info.ReadSaveSlots();
    }

    private void AdjustClock(){
        if(current_hours == 12){
            current_hours = 1;
            if(!morning){
                current_days++;
            }
            morning = !morning;
        } else{
            current_hours++;
        }
        _clock.text = current_hours.ToString() + (morning ? " am" : " pm");
    }

    private void AdjustDayCycle(){
        switch(morning){
            case true:
                if(current_hours < 6){
                    _day.enabled = false;
                    _extended_day.enabled = false;
                    _night.enabled = true;
                }
                if(current_hours >= 6 && current_hours < 8){
                    _day.enabled = false;
                    _extended_day.enabled = true;
                    _night.enabled = false;
                }
                if(current_hours >= 8){
                    _day.enabled = true;
                    _extended_day.enabled = false;
                    _night.enabled = false;
                }
                break;
            case false:
                if(current_hours < 4){
                    _day.enabled = true;
                    _extended_day.enabled = false;
                    _night.enabled = false;
                }
                if(current_hours >= 4 && current_hours < 6){
                    _day.enabled = false;
                    _extended_day.enabled = true;
                    _night.enabled = false;
                }
                if(current_hours >= 6){
                    _day.enabled = false;
                    _extended_day.enabled = false;
                    _night.enabled = true;
                }
                break;
        }
    }

    private void AdjustWeather(){
        if(elapsed_hours < next_storm_time){
            _next_storm.text = "in " + ((int)(next_storm_time - elapsed_hours) / 24) + "d" + (next_storm_time - elapsed_hours) % 24 + "h";
            _next_storm.color = Color.black;
        } else {
            InStorm();
        }

        if(elapsed_hours < next_trend_time){
            _next_trend_time.text = "in " + ((int)(next_trend_time - elapsed_hours) / 24) + "d" + (next_trend_time - elapsed_hours) % 24 + "h";
        } else{
            temperature = temperature + next_trend_temperature;
            _temperature.text = temperature + "°C ";
            _temperature.color = (temperature - target_temperature) > 0 ? Color.red : Color.blue;
            _temperature.color = temperature == target_temperature ? Color.black : _temperature.color;
            CalculateNextTrend();
        }
    }

    private void CalculateNextTrend(){
        if(next_storm_time - 4 > next_trend_time){
            next_trend_temperature = 5 * (int)Random.Range(-3,4);
            if(temperature + next_trend_temperature > target_temperature + 10 || temperature + next_trend_temperature < target_temperature - 10 || next_trend_temperature == 0){
                CalculateNextTrend();
            }
            _next_trend_temperature.text = (next_trend_temperature >= 0 ? "+ " : "") + next_trend_temperature + "°C";
            _next_trend_temperature.color = next_trend_temperature > 0 ? Color.red : Color.blue;
            next_trend_time = elapsed_hours + (int)Random.Range(1,4) * 24;
            _next_trend_time.text = "in " + ((int)(next_trend_time - elapsed_hours) / 24) + "d" + (next_trend_time - elapsed_hours) % 24 + "h";
        } else{
            CalculateNextTrendInStorm();
        }
    }

    private void CalculateNextTrendInStorm(){
        next_trend_temperature = target_temperature + 5 * (int)Random.Range(-1,2) - temperature;
        if (next_trend_temperature == 0){
            CalculateNextTrendInStorm();
        }
        _next_trend_temperature.text = (next_trend_temperature >= 0 ? "+" : "") + next_trend_temperature + "°C";
        _next_trend_temperature.color = next_trend_temperature > 0 ? Color.red : Color.blue;
        next_trend_time = elapsed_hours + (int)Random.Range(1,4) * 24;
        _next_trend_time.text = "in " + ((int)(next_trend_time - elapsed_hours) / 24) + "d" + (next_trend_time - elapsed_hours) % 24 + "h";
    }

    private void InStorm(){
        _next_storm.text = ((int)(GameOptions.storm_duration * 24 - current_storm_hour) / 24) + "d" + (GameOptions.storm_duration * 24 - current_storm_hour) % 24 + "h LEFT!";
        _next_storm.color = Color.red;
        if(current_storm_hour == 0 && !is_first_storm){
            switch(GameOptions.storm_intensity){
                case 1:
                    target_temperature = target_temperature + 10;
                    temperature = temperature + 10;
                    break;
                case 2:
                    target_temperature = target_temperature + 20;
                    temperature = temperature + 20;
                    break;
                case 3:
                    target_temperature = target_temperature + 25;
                    temperature = temperature + 30;
                    break;
                case 4:
                    target_temperature = target_temperature + 25;
                    temperature = temperature + 40;
                    break;
                case 5:
                    target_temperature = target_temperature + 30;
                    temperature = temperature + 50;
                    break;
                case 6:
                    target_temperature = target_temperature + 40;
                    temperature = temperature + 60;
                    break;
            }
        } else if(current_storm_hour == 0 && is_first_storm){
            target_temperature = target_temperature + 10;
            temperature = temperature + 20;
        }
        _temperature.text = temperature + "°C ";
        _temperature.color = (temperature - target_temperature) > 0 ? Color.red : Color.blue;
        _temperature.color = temperature == target_temperature ? Color.black : _temperature.color;

        if(current_storm_hour < GameOptions.storm_duration * 24){
            current_storm_hour++;
        } else{
            current_storm_hour = 0;
            if(is_first_storm){
                temperature = temperature - 10;
                is_first_storm = false;
            } else {
                switch(GameOptions.storm_intensity){
                    case 1:
                        target_temperature = target_temperature - 5;
                        temperature = temperature - 5;
                        break;
                    case 2:
                        target_temperature = target_temperature - 10;
                        temperature = temperature - 10;
                        break;
                    case 3:
                        target_temperature = target_temperature - 10;
                        temperature = temperature - 15;
                        break;
                    case 4:
                        target_temperature = target_temperature - 10;
                        temperature = temperature - 20;
                        break;
                    case 5:
                        target_temperature = target_temperature - 10;
                        temperature = temperature - 25;
                        break;
                    case 6:
                        target_temperature = target_temperature - 20;
                        temperature = temperature - 30;
                        break;
                }
            }
            _temperature.text = temperature + "°C ";
            _temperature.color = (temperature - target_temperature) > 0 ? Color.red : Color.blue;
            _temperature.color = temperature == target_temperature ? Color.black : _temperature.color;
            next_storm_time = elapsed_hours + 24 * (14 - (-3 + GameOptions.storm_intensity) - (1 * (int)Random.Range(-3,4)));
        }
    }

    private void AdjustResidents(){
        int residents = Residents.residents.Length;
        int housing_space = Buildings.OverallHousingSpace();
        int workers = Residents.OverallWorkers();
        int working_workers = Residents.OverallWorkingWorkers();
        int children = Residents.OverallChildren();
        int working_children = Residents.OverallChildWorkers();
        int sick = Residents.OverallSick();
        int sick_place = Buildings.OverallSickSpace();

        _residents.text = residents + "\n---\n" + housing_space;
        _residents.color = residents - housing_space < 0 ? Color.black : Color.red;
        _residents_image.color = residents - housing_space < 0 ? Color.black : Color.red;
        _workers.text = working_workers + "\n---\n" + workers;
        _children.text = working_children + "\n---\n" + children;
        _sick.text = sick + "\n---\n" + sick_place;
        _sick.color = sick - sick_place < 0 ? Color.black : Color.red;
        _sick_image.color = sick - sick_place < 0 ? Color.black : Color.red;
    }

    private void AdjustHappyness(){
        Residents.AdjustHappyness(temperature);
        happyness = Residents.OverallHappyness();
        
        _happy.enabled = false;
        _neutral.enabled = false;
        _sad.enabled = false;
        _protest.enabled = false;
        switch(happyness){
            case > 67:
                _happy.enabled = true;
                protest_days = 0;
                break;
            case > 33:
                _neutral.enabled = true;
                protest_days = 0;
                break;
            case > 0:
                _sad.enabled = true;
                protest_days = 0;
                break;
            case <= 0:
                _protest.enabled = true;
                protest_days++;
                break;
        }

        if(protest_days == 5){
            LostGame();
        }
    }

    private void LostGame(){

    }
}
