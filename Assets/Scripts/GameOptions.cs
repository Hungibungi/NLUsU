using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    public static int coordinate = 0;
    public static int difficulty = 2;
    public static int first_storm_timer = 4;
    public static int starting_resources = 4;
    public static int starting_technologies = 4;
    public static int starting_temperature = 2;
    public static int overall_costs = 2;
    public static int overall_discontent = 2;
    public static int storm_duration = 2;
    public static int storm_intensity = 2;
    public static int game_speed = 1;
    public static int music_volume = -40;
    public static int effects_volume = -40;
    public static int autosave_frequency = 24;
    public static StrippedGameController game_controller;

    public static void SaveUserSettings(){
        PlayerPrefs.SetInt("coordinate", coordinate);
        PlayerPrefs.SetInt("difficulty", difficulty);
        PlayerPrefs.SetInt("first_storm_timer", first_storm_timer);
        PlayerPrefs.SetInt("starting_resources", starting_resources);
        PlayerPrefs.SetInt("starting_technologies", starting_technologies);
        PlayerPrefs.SetInt("starting_temperature", starting_temperature);
        PlayerPrefs.SetInt("overall_costs", overall_costs);
        PlayerPrefs.SetInt("overall_discontent", overall_discontent);
        PlayerPrefs.SetInt("storm_duration", storm_duration);
        PlayerPrefs.SetInt("storm_intensity", storm_intensity);
        PlayerPrefs.SetInt("game_speed", game_speed);
        PlayerPrefs.SetInt("music_volume", music_volume);
        PlayerPrefs.SetInt("effects_volume", effects_volume);
        PlayerPrefs.SetInt("autosave_frequency", autosave_frequency);
        PlayerPrefs.Save();
    }

    public static void LoadUserSettings(){
        coordinate = PlayerPrefs.GetInt("coordinate", 0);
        difficulty = PlayerPrefs.GetInt("difficulty", 2); 
        first_storm_timer = PlayerPrefs.GetInt("first_storm_timer", 4); 
        starting_resources = PlayerPrefs.GetInt("starting_resources", 4); 
        starting_technologies = PlayerPrefs.GetInt("starting_technologies", 4); 
        starting_temperature = PlayerPrefs.GetInt("starting_temperature", 2); 
        overall_costs = PlayerPrefs.GetInt("overall_costs", 2); 
        overall_discontent = PlayerPrefs.GetInt("overall_discontent", 2); 
        storm_duration = PlayerPrefs.GetInt("storm_duration", 2); 
        storm_intensity = PlayerPrefs.GetInt("storm_intensity", 2); 
        game_speed = PlayerPrefs.GetInt("game_speed", 1); 
        music_volume = PlayerPrefs.GetInt("music_volume", -40); 
        effects_volume = PlayerPrefs.GetInt("effects_volume", -40); 
        autosave_frequency = PlayerPrefs.GetInt("autosave_frequency", 24); 
    }
}