using System;
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
    public Text _clock;
    [SerializeField]
    public Text _game_speed;
    [SerializeField]
    public Image _day;
    [SerializeField]
    public Image _extended_day;
    [SerializeField]
    public Image _night;
    [SerializeField]
    public Text _temperature;
    [SerializeField]
    public Text _next_trend_time;
    [SerializeField]
    public Text _next_trend_temperature;
    [SerializeField]
    public Text _next_storm;
    [SerializeField]
    public Image _happy;
    [SerializeField]
    public Image _neutral;
    [SerializeField]
    public Image _sad;
    [SerializeField]
    public Image _protest;
    [SerializeField]
    public Text _residents;
    [SerializeField]
    public Image _residents_image;
    [SerializeField]
    public Text _workers;
    [SerializeField]
    public Text _children;
    [SerializeField]
    public Text _sick;
    [SerializeField]
    public Image _sick_image;
    [SerializeField]
    public Text _food;
    [SerializeField]
    public Image _food_image;
    [SerializeField]
    public Text _power;
    [SerializeField]
    public Image _power_image;
    [SerializeField]
    public Text _building_material;
    [SerializeField]
    public Image _building_material_image;
    [SerializeField]
    public Text _iron;
    [SerializeField]
    public Image _iron_image;
    [SerializeField]
    public Text _end_game;
    [SerializeField]
    public GameObject _end_game_image;
    [SerializeField]
    public GameObject _leading_way;
    [SerializeField]
    public GameObject _law_menu;
    [SerializeField]
    public GameObject _policy_3x3;
    [SerializeField]
    public Image _policy_3x3_1x1;
    [SerializeField]
    public Image _policy_3x3_1x2;
    [SerializeField]
    public Image _policy_3x3_1x3;
    [SerializeField]
    public Image _policy_3x3_2x1;
    [SerializeField]
    public Image _policy_3x3_2x2;
    [SerializeField]
    public Image _policy_3x3_2x3;
    [SerializeField]
    public Image _policy_3x3_3x1;
    [SerializeField]
    public Image _policy_3x3_3x2;
    [SerializeField]
    public Image _policy_3x3_3x3;
    [SerializeField]
    public GameObject _policy_4x3;
    [SerializeField]
    public Image _policy_4x3_1x1;
    [SerializeField]
    public Image _policy_4x3_1x2;
    [SerializeField]
    public Image _policy_4x3_1x3;
    [SerializeField]
    public Image _policy_4x3_2x1;
    [SerializeField]
    public Image _policy_4x3_2x2;
    [SerializeField]
    public Image _policy_4x3_2x3;
    [SerializeField]
    public Image _policy_4x3_3x1;
    [SerializeField]
    public Image _policy_4x3_3x2;
    [SerializeField]
    public Image _policy_4x3_3x3;
    [SerializeField]
    public Image _policy_4x3_4x1;
    [SerializeField]
    public Image _policy_4x3_4x2;
    [SerializeField]
    public Image _policy_4x3_4x3;
    [SerializeField]
    public Text _policy_price;
    [SerializeField]
    public Text _policy_description;
    [SerializeField]
    public Button _activate_policy;
    [SerializeField]
    public GameObject _technology_menu;
    [SerializeField]
    public  GameObject _technology_1_1;
    [SerializeField]
    public  GameObject _technology_2_1;
    [SerializeField]
    public  GameObject _technology_2_2;
    [SerializeField]
    public  GameObject _technology_2_3;
    [SerializeField]
    public  GameObject _technology_2_4;
    [SerializeField]
    public  GameObject _technology_2_5;
    [SerializeField]
    public  GameObject _technology_next_3_1;
    [SerializeField]
    public  GameObject _technology_3_1;
    [SerializeField]
    public  GameObject _technology_next_3_2;
    [SerializeField]
    public  GameObject _technology_3_2;
    [SerializeField]
    public  GameObject _technology_next_3_3;
    [SerializeField]
    public  GameObject _technology_3_3;
    [SerializeField]
    public  GameObject _technology_next_3_4;
    [SerializeField]
    public  GameObject _technology_3_4;
    [SerializeField]
    public  GameObject _technology_next_3_5;
    [SerializeField]
    public  GameObject _technology_3_5;
    [SerializeField]
    public  GameObject _technology_next_4_1;
    [SerializeField]
    public  GameObject _technology_4_1;
    [SerializeField]
    public  GameObject _technology_next_4_2;
    [SerializeField]
    public  GameObject _technology_4_2;
    [SerializeField]
    public  GameObject _technology_next_4_3;
    [SerializeField]
    public  GameObject _technology_4_3;
    [SerializeField]
    public  GameObject _technology_next_4_4;
    [SerializeField]
    public  GameObject _technology_4_4;
    [SerializeField]
    public  GameObject _technology_next_4_5;
    [SerializeField]
    public  GameObject _technology_4_5;
    [SerializeField]
    public Text _technology_price;
    [SerializeField]
    public Text _technology_description;
    [SerializeField]
    public Button _research_technology;
    [SerializeField]
    public Text _food_production;
    [SerializeField]
    public Text _power_production;
    [SerializeField]
    public Text _building_material_production;
    [SerializeField]
    public Text _iron_production;
    [SerializeField]
    public  GameObject _building_slot_1;
    [SerializeField]
    public Text _building_slot_1_text;
    [SerializeField]
    public Button _building_slot_1_button;
    [SerializeField]
    public Button _building_slot_1_add_worker;
    [SerializeField]
    public Button _building_slot_1_remove_worker;
    [SerializeField]
    public Button _building_slot_1_add_child;
    [SerializeField]
    public Button _building_slot_1_remove_child;
    [SerializeField]
    public  GameObject _building_slot_2;
    [SerializeField]
    public Text _building_slot_2_text;
    [SerializeField]
    public Button _building_slot_2_button;
    [SerializeField]
    public Button _building_slot_2_add_worker;
    [SerializeField]
    public Button _building_slot_2_remove_worker;
    [SerializeField]
    public Button _building_slot_2_add_child;
    [SerializeField]
    public Button _building_slot_2_remove_child;
    [SerializeField]
    public  GameObject _building_slot_3;
    [SerializeField]
    public Text _building_slot_3_text;
    [SerializeField]
    public Button _building_slot_3_button;
    [SerializeField]
    public Button _building_slot_3_add_worker;
    [SerializeField]
    public Button _building_slot_3_remove_worker;
    [SerializeField]
    public Button _building_slot_3_add_child;
    [SerializeField]
    public Button _building_slot_3_remove_child;
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
    public int protest_hours = 0;
    public int base_cooling = 0;
    public int leader_type = 0;
    public int open_policy_tab;
    public int open_policy;
    public int open_technology_tab;
    public int open_technology; 
    public int day_cycle;
    public int open_building_tab;
    public int open_people_tab;
    public bool build_intent;

    void Start(){
        ChangeGameSpeed(1);

        // clock widget
        start_time = (int)Time.time;
        _clock.text = "1 am";
        _game_speed.text = "1x";

        // day cycle widget
        AdjustDayCycle();

        // resources widget
        Buildings.buildings[0] = new Building.Warehouse();
        ResourcesManager.food = 25 * GameOptions.starting_resources;
        ResourcesManager.power = 100 * GameOptions.starting_resources;
        ResourcesManager.building_material = 50 * GameOptions.starting_resources;
        ResourcesManager.iron = 25 * GameOptions.starting_resources;
        ResourcesManager.RefreshResourcesWidget(this);

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

        // residents widget
        AdjustResidents();

        // starting technologies
        switch(GameOptions.starting_technologies){
            case 0:
                Buildings.science_lab.active = true;
                Technologies.ActivateTechnology(8, this);
                Technologies.ActivateTechnology(34, this);
                break;
            case 1:
                Buildings.science_lab.active = true;
                Technologies.ActivateTechnology(8, this);
                Technologies.ActivateTechnology(34, this);
                Technologies.ActivateTechnology(18, this);
                Technologies.ActivateTechnology(25, this);
                Technologies.ActivateTechnology(44, this);
                break;
            case 2:
                Buildings.science_lab.active = true;
                Technologies.ActivateTechnology(8, this);
                Technologies.ActivateTechnology(34, this);
                Technologies.ActivateTechnology(18, this);
                Technologies.ActivateTechnology(25, this);
                Technologies.ActivateTechnology(44, this);
                Technologies.ActivateTechnology(0, this);
                Technologies.ActivateTechnology(52, this);
                break;
        }

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
        protest_hours = game_controller.protest_hours;
        base_cooling = game_controller.base_cooling;
        leader_type = game_controller.leader_type;
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
        ResourcesManager.CalculateProduction(temperature, base_cooling, day_cycle);
        ResourcesManager.GainHourlyResources();
        ResourcesManager.RefreshResourcesWidget(this);
        AdjustClock();
        AdjustDayCycle();
        AdjustWeather();
        AdjustSick();
        AdjustResidents();
        AdjustHappyness();
        AdjustSideMenu();
        Buildings.UpdateBuildings();
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
            stripped_game_controller.protest_hours = protest_hours;
            stripped_game_controller.base_cooling = base_cooling;
            stripped_game_controller.leader_type = leader_type;
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
        stripped_game_controller.happyness = happyness;
        stripped_game_controller.protest_hours = protest_hours;
        stripped_game_controller.base_cooling = base_cooling;
        stripped_game_controller.leader_type = leader_type;
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
                    day_cycle = 0;
                }
                if(current_hours >= 6 && current_hours < 8){
                    _day.enabled = false;
                    _extended_day.enabled = true;
                    _night.enabled = false;
                    day_cycle = 1;
                }
                if(current_hours >= 8){
                    _day.enabled = true;
                    _extended_day.enabled = false;
                    _night.enabled = false;
                    day_cycle = 2;
                }
                break;
            case false:
                if(current_hours < 4){
                    _day.enabled = true;
                    _extended_day.enabled = false;
                    _night.enabled = false;
                    day_cycle = 2;
                }
                if(current_hours >= 4 && current_hours < 6){
                    _day.enabled = false;
                    _extended_day.enabled = true;
                    _night.enabled = false;
                    day_cycle = 1;
                }
                if(current_hours >= 6){
                    _day.enabled = false;
                    _extended_day.enabled = false;
                    _night.enabled = true;
                    day_cycle = 0;
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
            next_trend_temperature = 5 * (int)UnityEngine.Random.Range(-3,4);
            if(temperature + next_trend_temperature > target_temperature + 10 || temperature + next_trend_temperature < target_temperature - 10 || next_trend_temperature == 0){
                CalculateNextTrend();
            }
            _next_trend_temperature.text = (next_trend_temperature >= 0 ? "+ " : "") + next_trend_temperature + "°C";
            _next_trend_temperature.color = next_trend_temperature > 0 ? Color.red : Color.blue;
            next_trend_time = elapsed_hours + (int)UnityEngine.Random.Range(1,4) * 24;
            _next_trend_time.text = "in " + ((int)(next_trend_time - elapsed_hours) / 24) + "d" + (next_trend_time - elapsed_hours) % 24 + "h";
        } else{
            CalculateNextTrendInStorm();
        }
    }

    private void CalculateNextTrendInStorm(){
        next_trend_temperature = target_temperature + 5 * (int)UnityEngine.Random.Range(-1,2) - temperature;
        if (next_trend_temperature == 0){
            CalculateNextTrendInStorm();
        }
        _next_trend_temperature.text = (next_trend_temperature >= 0 ? "+" : "") + next_trend_temperature + "°C";
        _next_trend_temperature.color = next_trend_temperature > 0 ? Color.red : Color.blue;
        next_trend_time = elapsed_hours + (int)UnityEngine.Random.Range(1,4) * 24;
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
                _leading_way.SetActive(true);
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
            next_storm_time = elapsed_hours + 24 * (14 - (-3 + GameOptions.storm_intensity) - (1 * (int)UnityEngine.Random.Range(-3,4)));
        }
    }

    private void AdjustSick(){
        foreach(Resident res in Residents.residents){
            if(!res.is_sick){
                int multiplier = (res.overall_temperature - 25)>=0?0:res.overall_temperature - 25;
                bool rng = UnityEngine.Random.Range(0, 999) < 1 + multiplier / 24;
                if(rng && !res.is_sick){
                    Residents.GotSick(res, elapsed_hours);
                }
            }
            if(res.is_sick && res.medical == null){
                bool rng = UnityEngine.Random.Range(0, 200) < 2;
                if(rng){
                    Residents.Died(res);
                }
                rng = UnityEngine.Random.Range(0, 200) < 1;
                if(rng){
                    Residents.Recovered(res);
                }
            }
            if(res.medical != null){
                float effective_treatment_speed = 1 / (res.medical.treatment_speed * (res.medical.current_workers * res.medical.workers_efficiency + res.medical.children_workers * res.medical.children_efficiency + res.medical.sick_workers * res.medical.sick_efficiency));
                if(effective_treatment_speed == 0){
                    res.medical.current_sick--;
                    res.medical = null;
                } else if(res.start_treatment + (int)(effective_treatment_speed * 72) == elapsed_hours){
                    Residents.Recovered(res);
                }
            }
        }
    }

    public void AdjustResidents(){
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

        if(residents == 0){
            LostGame(false);
        }
    }

    private void AdjustHappyness(){
        Residents.AdjustHappyness(temperature, base_cooling);
        happyness = Residents.OverallHappyness();
        
        _happy.enabled = false;
        _neutral.enabled = false;
        _sad.enabled = false;
        _protest.enabled = false;
        switch(leader_type){
            case 0:
                switch(happyness){
                    case > 66:
                        _happy.enabled = true;
                        Residents.happyness_state = "happy";
                        protest_hours = 0;
                        break;
                    case > 33:
                        _neutral.enabled = true;
                        Residents.happyness_state = "neutral";
                        protest_hours = 0;
                        break;
                    case > 0:
                        _sad.enabled = true;
                        Residents.happyness_state = "sad";
                        protest_hours = 0;
                        break;
                    case <= 0:
                        _protest.enabled = true;
                        Residents.happyness_state = "sad";
                        protest_hours++;
                        break;
                }
                break;
            case 1:
                switch(happyness){
                    case > 33:
                        _happy.enabled = true;
                        Residents.happyness_state = "happy";
                        protest_hours = 0;
                        break;
                    case > 0:
                        _sad.enabled = true;
                        Residents.happyness_state = "sad";
                        protest_hours = 0;
                        break;
                    case <= 0:
                        _protest.enabled = true;
                        Residents.happyness_state = "sad";
                        protest_hours++;
                        break;
                }
                break;
            case 2:
                switch(happyness){
                    case > 67:
                        _happy.enabled = true;
                        Residents.happyness_state = "happy";
                        protest_hours = 0;
                        break;
                    case > 0:
                        _neutral.enabled = true;
                        Residents.happyness_state = "neutral";
                        protest_hours = 0;
                        break;
                    case <= 0:
                        _protest.enabled = true;
                        Residents.happyness_state = "sad";
                        protest_hours++;
                        break;
                }
                break;
            case 3:
                _sad.enabled = true;
                Residents.happyness_state = "sad";
                break;
        }
        if(protest_hours == 120){
            LostGame(true);
        }
    }

    private void LostGame(bool protest){
        ChangeGameSpeed(10);
        _end_game_image.SetActive(true);
        if(protest){
            _end_game.text = "Your people had enough of you after\n5 days of protests, better luck next time!";
        } else{
            _end_game.text = "Your last resident just died,\nbetter luck next time!";
        }
    }

    public void ChooseLeadingWay(int option){
        Policies.ActivatePolicy(42 + option, this);
    }

    public void ChangePoliciesDisplayed(int page){
        _policy_3x3.SetActive(false);
        _policy_4x3.SetActive(false);
        open_policy_tab = page;
        switch(page){
            case 0:
                _policy_4x3.SetActive(true);
                _policy_4x3_1x1.sprite = Sprites.resident_image;
                _policy_4x3_1x2.sprite = Sprites.resident_image;
                _policy_4x3_1x3.sprite = Sprites.resident_image;
                _policy_4x3_2x1.sprite = Sprites.resident_image;
                _policy_4x3_2x2.sprite = Sprites.resident_image;
                _policy_4x3_2x3.sprite = Sprites.resident_image;
                _policy_4x3_3x1.sprite = Sprites.happy_image;
                _policy_4x3_3x2.sprite = Sprites.happy_image;
                _policy_4x3_3x3.sprite = Sprites.happy_image;
                _policy_4x3_4x1.sprite = Sprites.child_image;
                _policy_4x3_4x2.sprite = Sprites.child_image;
                _policy_4x3_4x3.sprite = Sprites.child_image;
                break;
            case 1:
                _policy_3x3.SetActive(true);
                _policy_3x3_1x1.sprite = Sprites.sick_image;
                _policy_3x3_1x2.sprite = Sprites.sick_image;
                _policy_3x3_1x3.sprite = Sprites.sick_image;
                _policy_3x3_2x1.sprite = Sprites.sick_image;
                _policy_3x3_2x2.sprite = Sprites.sick_image;
                _policy_3x3_2x3.sprite = Sprites.sick_image;
                _policy_3x3_3x1.sprite = Sprites.child_image;
                _policy_3x3_3x2.sprite = Sprites.child_image;
                _policy_3x3_3x3.sprite = Sprites.child_image;
                break;
            case 2:
                _policy_4x3.SetActive(true);
                _policy_4x3_1x1.sprite = Sprites.food_image;
                _policy_4x3_1x2.sprite = Sprites.food_image;
                _policy_4x3_1x3.sprite = Sprites.food_image;
                _policy_4x3_2x1.sprite = Sprites.food_image;
                _policy_4x3_2x2.sprite = Sprites.food_image;
                _policy_4x3_2x3.sprite = Sprites.food_image;
                _policy_4x3_3x1.sprite = Sprites.food_image;
                _policy_4x3_3x2.sprite = Sprites.food_image;
                _policy_4x3_3x3.sprite = Sprites.food_image;
                _policy_4x3_4x1.sprite = Sprites.child_image;
                _policy_4x3_4x2.sprite = Sprites.child_image;
                _policy_4x3_4x3.sprite = Sprites.child_image;
                break;
            case 3:
                _policy_3x3.SetActive(true);
                _policy_3x3_1x1.sprite = Sprites.worker_image;
                _policy_3x3_1x2.sprite = Sprites.worker_image;
                _policy_3x3_1x3.sprite = Sprites.worker_image;
                _policy_3x3_2x1.sprite = Sprites.child_image;
                _policy_3x3_2x2.sprite = Sprites.child_image;
                _policy_3x3_2x3.sprite = Sprites.child_image;
                _policy_3x3_3x1.sprite = Sprites.sick_image;
                _policy_3x3_3x2.sprite = Sprites.sick_image;
                _policy_3x3_3x3.sprite = Sprites.sick_image;
                break;
        }
    }

    public void SetOpenPolicy(int id){
        switch(open_policy_tab){
            case 0:
                open_policy = id;
                break;
            case 1:
                open_policy = id + 12;
                break;
            case 2:
                open_policy = id + 21;
                break;
            case 3:
                open_policy = id + 33;
                break;
        }
        _policy_price.text = Policies.policies[open_policy].cooldown_time + " hours cooldown";
        _policy_description.text = Policies.policies[open_policy].description;
        _activate_policy.interactable = true;
        if(Policies.policies[open_policy].prerequisite != -1 && !Policies.active_policies[Policies.policies[open_policy].prerequisite] || Policies.active_policies[open_policy]){
            _activate_policy.interactable = false;
        }
    }

        public void ChoosePolicy(){
        Policies.ActivatePolicy(open_policy, this);
        Policies.next_policy = elapsed_hours + Policies.policies[open_policy].cooldown_time;
        _law_menu.GetComponent<Image>().color = Color.red;
        _law_menu.GetComponent<Button>().interactable = false;
    }

    public void ChangeTechnologiesDisplayed(int page){
        open_technology_tab = page;
        Technologies.ChangeTechnologyPage(page, this);
    }

    public void SetOpenTechnology(int id){
        open_technology = Technologies.SetOpenTechnology(id, this);
    }

    public void ChooseTechnology(){
        Technologies.currently_researching = open_technology;
        Technology technology = Technologies.technologies[open_technology];
        ResourcesManager.research_progress = 0;
        ResourcesManager.PayResources(0,0,technology.building_material_cost,technology.iron_cost);
        ResourcesManager.RefreshResourcesWidget(this);
        _technology_menu.GetComponent<Image>().color = Color.red;
        _technology_menu.GetComponent<Button>().interactable = false;
    }

    private void AdjustSideMenu(){
        if(Policies.next_policy == elapsed_hours){
            _law_menu.GetComponent<Image>().color = Color.black;
            _law_menu.GetComponent<Button>().interactable = true;
        }
        if(Technologies.technologies[Technologies.currently_researching].research_time <= ResourcesManager.research_progress && !Technologies.active_technologies[Technologies.currently_researching]){
            Technologies.ActivateTechnology(Technologies.currently_researching, this);
            _technology_menu.GetComponent<Image>().color = Color.black;
            _technology_menu.GetComponent<Button>().interactable = true;
        }
    }

    public void ChangeBuildingIntent(bool intent){
        build_intent = intent;
    }

    public void ChangeBuildingsDisplayed(int page){
        open_building_tab = page;
        Buildings.ChangeBuildingsDisplayed(page, this);
    }

    public void BuildBuilding(int slot){
        Buildings.BuildBuilding(slot, this);
        Buildings.ChangeBuildingsDisplayed(open_building_tab, this);
    }

    public void ChangePeoplePage(int page){
        open_people_tab = page+1;
        Buildings.ChangeBuildingsDisplayed(page+1, this);
    }

    public void AddWorker(int slot){
        Residents.ManageWorkers(slot, 0, this);
        Buildings.ChangeBuildingsDisplayed(open_people_tab, this);
        AdjustResidents();
        ResourcesManager.CalculateProduction(temperature, base_cooling, day_cycle);
        ResourcesManager.RefreshResourcesWidget(this);
    }

    public void RemoveWorker(int slot){
        Residents.ManageWorkers(slot, 1, this);
        Buildings.ChangeBuildingsDisplayed(open_people_tab, this);
        AdjustResidents();
        ResourcesManager.CalculateProduction(temperature, base_cooling, day_cycle);
        ResourcesManager.RefreshResourcesWidget(this);
    }

    public void AddChild(int slot){
        Residents.ManageWorkers(slot, 2, this);
        Buildings.ChangeBuildingsDisplayed(open_people_tab, this);
        AdjustResidents();
        ResourcesManager.CalculateProduction(temperature, base_cooling, day_cycle);
        ResourcesManager.RefreshResourcesWidget(this);
    }

    public void RemoveChild(int slot){
        Residents.ManageWorkers(slot, 3, this);
        Buildings.ChangeBuildingsDisplayed(open_people_tab, this);
        AdjustResidents();
        ResourcesManager.CalculateProduction(temperature, base_cooling, day_cycle);
        ResourcesManager.RefreshResourcesWidget(this);
    }
}
