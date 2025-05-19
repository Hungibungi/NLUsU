using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    //GameObjects
    [SerializeField]
    private Text _coordination_name;
    [SerializeField]
    private Image _coordination_image;
    [SerializeField]
    private Text _coordination_text;
    [SerializeField] 
    private Text _difficulty;
    [SerializeField]
    private Slider _difficulty_slider;
    [SerializeField]
    private Text _first_storm_timer;
    [SerializeField]
    private Slider _first_storm_timer_slider;
    [SerializeField]
    private Text _starting_resources;
    [SerializeField]
    private Slider _starting_resources_slider;
    [SerializeField]
    private Text _starting_technologies;
    [SerializeField]
    private Slider _starting_technologies_slider;
    [SerializeField]
    private Text _starting_temperature;
    [SerializeField]
    private Slider _starting_temperature_slider;
    [SerializeField]
    private Text _overall_costs;
    [SerializeField]
    private Slider _overall_costs_slider;
    [SerializeField]
    private Text _overall_discontent;
    [SerializeField]
    private Slider _overall_discontent_slider;
    [SerializeField]
    private Text _storm_duration;
    [SerializeField]
    private Slider _storm_duration_slider;
    [SerializeField]
    private Text _storm_intensity;
    [SerializeField]
    private Slider _storm_intensity_slider;

    //Variables
    private int coordinate = 0;

    void Start()
    {
        ChangeCoordinate(Coordinates.coordinates.Length);
        LoadUserSettings();
    }

    public void ChangeCoordinate(int direction){
        if(coordinate + direction < 0){
            coordinate = Coordinates.coordinates.Length - 1;
        } else if(coordinate + direction == Coordinates.coordinates.Length){
            coordinate = 0;
        } else{
            coordinate = coordinate + direction;
        }
        GameOptions.coordinate = coordinate;
        _coordination_image.sprite = Coordinates.coordinates[coordinate].image;
        _coordination_text.text = Coordinates.coordinates[coordinate].text;
        _coordination_name.text = Coordinates.coordinates[coordinate].name;
    }

    public void SaveUserSettings(){
        GameOptions.SaveUserSettings();
    }

    public void LoadUserSettings(){
        _difficulty.text = "Difficulty: " + GameOptions.difficulty;
        _difficulty_slider.value = GameOptions.difficulty;
        UpdateFirstStormTimer(GameOptions.first_storm_timer);
        UpdateStartingResources(GameOptions.starting_resources);
        UpdateStartingTechnologies(GameOptions.starting_technologies);
        UpdateStartingTemperature(GameOptions.starting_temperature);
        UpdateOverallCosts(GameOptions.overall_costs);
        UpdateOverallDiscontent(GameOptions.overall_discontent);
        UpdateStormDuration(GameOptions.storm_duration);
        UpdateStormIntensity(GameOptions.storm_intensity);
    }

    public void UpdateDifficulty(float difficulty){
        GameOptions.difficulty = (int)difficulty;
        _difficulty.text = "Difficulty: " + (difficulty!=0?difficulty:"custom");
        if(difficulty != 0){
            UpdateFirstStormTimer(6 - (int)difficulty);
            UpdateStartingResources(6 - (int)difficulty);
            UpdateStartingTemperature((int)difficulty);
            UpdateOverallCosts((int)difficulty);
            UpdateOverallDiscontent((int)difficulty);
            UpdateStormDuration((int)difficulty);
            UpdateStormIntensity((int)difficulty);
            switch((int)difficulty){
                case 1:
                case 2:
                    UpdateStartingTechnologies(2);
                    break;
                case 3:
                case 4:
                    UpdateStartingTechnologies(1);
                    break;
                case 5:
                    UpdateStartingTechnologies(0);
                    break;
            }
        }
    }

    public void UpdateFirstStormTimer(float first_storm_timer){
        GameOptions.first_storm_timer = (int)first_storm_timer;
        _first_storm_timer.text = "First storm timer: " + GameOptions.first_storm_timer;
        _first_storm_timer_slider.value = GameOptions.first_storm_timer;
        if (GameOptions.first_storm_timer != 6 - GameOptions.difficulty){
            _difficulty_slider.value = 0;
        }
    }

    public void UpdateStartingResources(float starting_resources){
        GameOptions.starting_resources = (int)starting_resources;
        _starting_resources.text = "Starting resources: " + GameOptions.starting_resources;
        _starting_resources_slider.value = GameOptions.starting_resources;
        if (GameOptions.starting_resources != 6 - GameOptions.difficulty){
            _difficulty_slider.value = 0;
        }
    }

    public void UpdateStartingTechnologies(float starting_technologies){
        GameOptions.starting_technologies = (int)starting_technologies;
        _starting_technologies.text = "Starting technologies: " + GameOptions.starting_technologies;
        _starting_technologies_slider.value = GameOptions.starting_technologies;
        switch(GameOptions.starting_technologies){
            case 0:
                if(GameOptions.difficulty != 5){
                    _difficulty_slider.value = 0;
                }
                break;
            case 1:
                if(GameOptions.difficulty != 3 && GameOptions.difficulty != 4){
                    _difficulty_slider.value = 0;
                }
                break;
            case 2:
                if(GameOptions.difficulty != 1 && GameOptions.difficulty != 2){
                    _difficulty_slider.value = 0;
                }
                break;
        }
    }

    public void UpdateStartingTemperature(float starting_temperature){
        GameOptions.starting_temperature = (int)starting_temperature;
        _starting_temperature.text = "Starting temperature: " + GameOptions.starting_temperature;
        _starting_temperature_slider.value = GameOptions.starting_temperature;
        if (GameOptions.starting_temperature != GameOptions.difficulty){
            _difficulty_slider.value = 0;
        }
    }

    public void UpdateOverallCosts(float overall_costs){
        GameOptions.overall_costs = (int)overall_costs;
        _overall_costs.text = "Overall costs: " + GameOptions.overall_costs;
        _overall_costs_slider.value = GameOptions.overall_costs;
        if (GameOptions.overall_costs != GameOptions.difficulty){
            _difficulty_slider.value = 0;
        }
    }

    public void UpdateOverallDiscontent(float overall_discontent){
        GameOptions.overall_discontent = (int)overall_discontent;
        _overall_discontent.text = "Overall discontent: " + GameOptions.overall_discontent;
        _overall_discontent_slider.value = GameOptions.overall_discontent;
        if (GameOptions.overall_discontent != GameOptions.difficulty){
            _difficulty_slider.value = 0;
        }
    }

    public void UpdateStormDuration(float storm_duration){
        GameOptions.storm_duration = (int)storm_duration;
        _storm_duration.text = "Storm duration: " + GameOptions.storm_duration;
        _storm_duration_slider.value = GameOptions.storm_duration;
        if (GameOptions.storm_duration != GameOptions.difficulty){
            _difficulty_slider.value = 0;
        }
    }

    public void UpdateStormIntensity(float storm_intensity){
        GameOptions.storm_intensity = (int)storm_intensity;
        _storm_intensity.text = "Storm intensity: " + GameOptions.storm_intensity;
        _storm_intensity_slider.value = GameOptions.storm_intensity;
        if (GameOptions.storm_intensity != GameOptions.difficulty){
            _difficulty_slider.value = 0;
        }
    }
}
