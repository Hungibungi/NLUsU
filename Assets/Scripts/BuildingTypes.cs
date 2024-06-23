using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    public int building_material_cost;
    public int iron_cost;
    public int coolness;
    public int coolness_modifier;
    public bool enable_cooling;
    public bool active;
    public int target_temperature;
    public string description;
    
    public Building(){
        building_material_cost = 0;
        iron_cost = 0;
        coolness = 0;
        coolness_modifier = 1;
        enable_cooling = false;
        active = true;
        target_temperature = -1;
    }

    public class Warehouse : Building{
        public int food_storage;
        public int power_storage;
        public int building_material_storage;
        public int iron_storage;
        public Warehouse(){
            building_material_cost = 50;
            iron_cost = 10;
            food_storage = 250;
            power_storage = 1000;
            building_material_storage = 500;
            iron_storage = 250;
            description = "Stores your resources.";
        }
    }
}

public class PolicyBuilding : Building{
    public int customers;
    public int happyness_bonus;

    public class Pub : PolicyBuilding{
        public Pub(){
            building_material_cost = 15;
            iron_cost = 5;
            customers = 10;
            happyness_bonus = 10;
            description = "The pub... is well... a pub. Children not allowed!";
        }
    }

    public class HouseOfPleasure : PolicyBuilding{
        public HouseOfPleasure(){
            building_material_cost = 35;
            iron_cost = 20;
            customers = 20;
            happyness_bonus = 20;
            description = "The house of pleasures is every adult's dreamplace.";
        }
    }
}

public class Housing : Building{
        public int max_residents;
        public int happyness_modifier;

    public class Tent : Housing{
        public Tent(){
            building_material_cost = 20;
            coolness = 10;
            max_residents = 10;
            happyness_modifier = 0;
            description = "The tent. I don't like camping, but gotta live with it.";
        }
    }

    public class House : Housing{
        public House(){
            building_material_cost = 30;
            iron_cost = 10;
            coolness = 30;
            max_residents = 10;
            happyness_modifier = 10;
            description = "The family house is a small cozy home. Really comfy!";
        }
    }

    public class Apartment : Housing{
        public Apartment(){
            building_material_cost = 60;
            iron_cost = 20;
            coolness = 30;
            max_residents = 30;
            happyness_modifier = -10;
            description = "The apartment house has a lot of residents. Booooring.";
        }
    }
}

public class Workplace : Building{
    public int max_workers;
    public int current_workers;
    public float workers_efficiency;
    public int children_workers;
    public float children_efficiency;
    public int sick_workers;
    public float sick_efficiency;
    public int working_hours;
    public bool child_work;
    public bool emergency_work;
    public bool extended_work;
    public Workplace(){
        max_workers = 10;
        current_workers = 0;
        workers_efficiency = 1F;
        children_workers = 0;
        children_efficiency = 0.5F;
        sick_workers = 0;
        sick_efficiency = 0F;
        working_hours = 8;
        child_work = false;
        emergency_work = false;
        extended_work = false;
    }

    public class Medical : Workplace{
        public int max_sick;
        public int current_sick;
        public float treatment_speed;
        public Medical(){
            max_sick = 0;
            current_sick = 0;
            treatment_speed = 1F;
        }

        public class MedicalTent : Medical{
            public MedicalTent(){
                building_material_cost = 15;
                iron_cost = 5;
                coolness = 10;
                max_sick = 10;
                description = "I hate tents and being sick. The medical tent has both...";
            }
        }

        public class Hospital : Medical{
            public Hospital(){
                building_material_cost = 50;
                iron_cost = 50;
                coolness = 40;
                max_workers = 20;
                max_sick = 30;
                description = "The hospital will provide you a fast recovery!";
            }
        }
    }

    public class Resource : Workplace{
        public int building_material_production;
        public float building_material_efficiency;
        public int iron_production;
        public float iron_efficiency;
        public int power_production;
        public float power_efficiency;
        public int food_production;
        public float food_efficiency;
        public Resource(){
            building_material_production = 0;
            building_material_efficiency = 1F;
            iron_production = 0;
            iron_efficiency = 1F;
            power_production = 0;
            power_efficiency = 1F;
            food_production = 0;
            food_efficiency = 1F;
        }

        public class IronMine : Resource{
            public IronMine(){
                building_material_cost = 20;
                iron_cost = 5;
                building_material_production = 20;
                iron_production = 10;
                coolness = 20;
                description = "It's a cool iron mine.";
            }
        }

        public class SolarPanel : Resource{
            public SolarPanel(){
                building_material_cost = 5;
                iron_cost = 25;
                max_workers = 1;
                current_workers = 1;
                power_production = 20;
                working_hours = 12;
                description = "The pinnacle of human engineering, the solar panel!";
            }
        }

        public class CoalMine : Resource{
            public CoalMine(){
                building_material_cost = 50;
                iron_cost = 50;
                building_material_production = 20;
                power_production = 10;
                coolness = 20;
                description = "Santa's coal mine.";
            }
        }

        public class FishermansHut : Resource{
            public FishermansHut(){
                building_material_cost = 20;
                iron_cost = 5;
                max_workers = 20;
                food_production = 20;
                coolness = 20;
                description = "Every grandpa's dreamjob, the fisherman's hut!";
            }
        }

        public class AppleOrchard : Resource{
            public AppleOrchard(){
                building_material_cost = 50;
                iron_cost = 50;
                building_material_production = 20;
                food_production = 10;
                coolness = 30;
                description = "The source of apple juice.";
            }
        }

        public class ChildCookery : Resource{
            public float food_multiplier;
            public ChildCookery(){
                building_material_cost = 50;
                iron_cost = 50;
                coolness = 30;
                child_work = true;
                food_multiplier = 1.15F;
                description = "A safe job for kids, they seem to be having fun as well.";
            }
        }
    }

    public class ScienceLab : Workplace{
        public int science_production;
        public ScienceLab(){
            building_material_cost = 25;
            iron_cost = 10;
            coolness = 20;
            description = "The nerd's place, or umm... Science lab, sorry.";
        }
    }

    public class ScoutStation : Workplace{
        public float movement_speed;
        public int carrying_capacity;
        public ScoutStation(){
            building_material_cost = 25;
            iron_cost = 10;
            movement_speed = 1F;
            carrying_capacity = 1000;
            description = "The adventurer's guild..? That's what the scouts call it.";
        }
    }
}