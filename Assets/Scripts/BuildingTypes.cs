public class Building
{
    public int building_material_cost;
    public int iron_cost;
    public int coolness;
    public int coolness_modifier;
    public bool enable_cooling;
    public bool active;
    public int target_temperature;
    public bool manual_cooling;
    public string description;
    public int tile;
    public string name;
    public UnityEngine.Sprite icon;
    public string special_info;
    
    public Building(){
        building_material_cost = 0;
        iron_cost = 0;
        coolness = 0;
        coolness_modifier = 0;
        enable_cooling = false;
        active = false;
        target_temperature = 25;
        tile = -1;
        manual_cooling = false;
        name = "Building";
        icon = Sprites.graveyard;
        special_info = "Special info";
    }

    public class Warehouse : Building{
        public int food_storage;
        public int power_storage;
        public int building_material_storage;
        public int iron_storage;
        public Warehouse(int tile){
            building_material_cost = 50;
            iron_cost = 10;
            food_storage = 250;
            power_storage = 1000;
            building_material_storage = 500;
            iron_storage = 250;
            description = "Stores your resources.";
            name = "Warehouse";
            icon = Sprites.warehouse_logo;
            special_info = "It's quite mysterious how this thing actually works...\nResources we gather magically appear inside;\nmeanwhile resources we think of pop up in front of our own eyes...";
            this.tile = tile;
        }
    }
}

public class PolicyBuilding : Building{
    public int customers;
    public int happyness_bonus;

    public class Pub : PolicyBuilding{
        public Pub(int tile){
            building_material_cost = 15;
            iron_cost = 5;
            customers = 10;
            happyness_bonus = 10;
            description = "The pub... is well... a pub. Children not allowed!";
            name = "Pub";
            icon = Sprites.pub_logo;
            special_info = "Contradictory to popular belief, a beer a day\nactually does keep the doctor away!\nUnless you drink with one...";
            this.tile = tile;
        }
    }

    public class HouseOfPleasure : PolicyBuilding{
        public HouseOfPleasure(int tile){
            building_material_cost = 35;
            iron_cost = 20;
            customers = 20;
            happyness_bonus = 20;
            description = "The house of pleasure is every adult's dreamplace.";
            name = "House of pleasure";
            icon = Sprites.house_of_pleasure_logo;
            special_info = "Some people want to get a policy in place\nthat would enable children to work here...\nThankfully they are not in power... right?";
            this.tile = tile;
        }
    }
}

public class Housing : Building{
        public int max_residents;
        public int happyness_modifier;

    public class Tent : Housing{
        public Tent(int tile){
            building_material_cost = 20;
            coolness = 10;
            max_residents = 10;
            happyness_modifier = 0;
            description = "The tent. I don't like camping, but gotta live with it.";
            name = "Tent";
            icon = Sprites.tent_logo;
            special_info = "Call Hungi to set it up for you;\nno way you do it on your own!";
            this.tile = tile;
        }
    }

    public class House : Housing{
        public House(int tile){
            building_material_cost = 30;
            iron_cost = 10;
            coolness = 30;
            max_residents = 10;
            happyness_modifier = 10;
            description = "The family house is a small cozy home. Really comfy!";
            name = "House";
            icon = Sprites.family_house_logo;
            special_info = "It comes pre-furnitured,\nalso includes dog toys.\nNO CATS ALLOWED!";
            this.tile = tile;
        }
    }

    public class Apartment : Housing{
        public Apartment(int tile){
            building_material_cost = 60;
            iron_cost = 20;
            coolness = 30;
            max_residents = 30;
            happyness_modifier = -10;
            description = "The apartment house has a lot of residents. Booooring.";
            name = "Apartment";
            icon = Sprites.apartment_logo;
            special_info = "Small text on the contract:,\nIt is not only booooring because it is a flat,\nbut also it is haunted. BOOO!";
            this.tile = tile;
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
    public int sick_child_workers;
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
        sick_child_workers = 0;
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
            public MedicalTent(int tile){
                building_material_cost = 15;
                iron_cost = 5;
                coolness = 10;
                max_sick = 10;
                description = "I hate tents and being sick. The medical tent has both...";
                name = "Medical tent";
                icon = Sprites.medical_tent_logo;
                this.tile = tile;
            }
        }

        public class Hospital : Medical{
            public Hospital(int tile){
                building_material_cost = 50;
                iron_cost = 50;
                coolness = 40;
                max_workers = 20;
                max_sick = 30;
                description = "The hospital will provide you a fast recovery!";
                name = "Hospital";
                icon = Sprites.hospital_logo;
                this.tile = tile;
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
            public IronMine(int tile){
                building_material_cost = 20;
                iron_cost = 5;
                building_material_production = 20;
                iron_production = 10;
                coolness = 20;
                description = "It's a cool iron mine.";
                name = "Iron mine";
                icon = Sprites.iron_mine_logo;
                this.tile = tile;
            }
        }

        public class SolarPanel : Resource{
            public SolarPanel(int tile){
                building_material_cost = 5;
                iron_cost = 25;
                max_workers = 1;
                current_workers = 1;
                power_production = 20;
                working_hours = 12;
                description = "The pinnacle of human engineering, the solar panel!";
                name = "Solar panel";
                icon = Sprites.solar_panel_logo;
                this.tile = tile;
            }
        }

        public class CoalMine : Resource{
            public CoalMine(int tile){
                building_material_cost = 50;
                iron_cost = 50;
                building_material_production = 20;
                power_production = 10;
                coolness = 20;
                description = "Santa's coal mine.";
                name = "Coal mine";
                icon = Sprites.coal_mine_logo;
                this.tile = tile;
            }
        }

        public class FishermansHut : Resource{
            public FishermansHut(int tile){
                building_material_cost = 20;
                iron_cost = 5;
                max_workers = 20;
                food_production = 20;
                coolness = 20;
                description = "Every grandpa's dreamjob, the fisherman's hut!";
                name = "Fisherman's hut";
                icon = Sprites.fishermans_hut_logo;
                this.tile = tile;
            }
        }

        public class AppleOrchard : Resource{
            public AppleOrchard(int tile){
                building_material_cost = 50;
                iron_cost = 50;
                building_material_production = 20;
                food_production = 10;
                coolness = 30;
                description = "The source of apple juice.";
                name = "Apple orchard";
                icon = Sprites.apple_orchard_logo;
                this.tile = tile;
            }
        }

        public class ChildCookery : Resource{
            public float food_multiplier;
            public ChildCookery(int tile){
                building_material_cost = 50;
                iron_cost = 50;
                coolness = 30;
                child_work = true;
                food_multiplier = 1.15F;
                description = "A safe job for kids, they seem to be having fun as well.";
                name = "Child cookery";
                icon = Sprites.child_cookery_logo;
                special_info = "Children have the capabilities to cook\nmore grams of food than raw material!";
                this.tile = tile;
            }
        }
    }

    public class ScienceLab : Workplace{
        public int science_production;
        public ScienceLab(int tile){
            building_material_cost = 25;
            iron_cost = 10;
            coolness = 20;
            description = "The nerd's place, or umm... Science lab, sorry.";
            name = "Science lab";
            icon = Sprites.science_lab_logo;
            special_info = "They want us to believe they research new things,\nbut we all know they are just replicating old inventions.";
            this.tile = tile;
        }
    }

    public class ScoutStation : Workplace{
        public float movement_speed;
        public int carrying_capacity;
        public ScoutStation(int tile){
            building_material_cost = 25;
            iron_cost = 10;
            movement_speed = 1F;
            carrying_capacity = 1000;
            description = "The adventurer's guild..? That's what the scouts call it.";
            name = "Scout station";
            icon = Sprites.scout_station_logo;
            special_info = "Don't ask how they can scout and work at the same time...";
            this.tile = tile;
        }
    }
}