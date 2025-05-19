using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public static class Buildings
{
        public static Building[] buildings = new Building[1];
        public static PolicyBuilding.Pub pub = new PolicyBuilding.Pub(-1);
        public static PolicyBuilding.HouseOfPleasure house_of_pleasure = new PolicyBuilding.HouseOfPleasure(-1);
        public static Housing.Tent tent = new Housing.Tent(-1);
        public static Housing.House house = new Housing.House(-1);
        public static Housing.Apartment apartment = new Housing.Apartment(-1);
        public static Workplace.Medical.MedicalTent medical_tent = new Workplace.Medical.MedicalTent(-1);
        public static Workplace.Medical.Hospital hospital = new Workplace.Medical.Hospital(-1);
        public static Workplace.Resource.IronMine iron_mine = new Workplace.Resource.IronMine(-1);
        public static Workplace.Resource.SolarPanel solar_panel = new Workplace.Resource.SolarPanel(-1);
        public static Workplace.Resource.CoalMine coal_mine = new Workplace.Resource.CoalMine(-1);
        public static Workplace.Resource.FishermansHut fishermans_hut = new Workplace.Resource.FishermansHut(-1);
        public static Workplace.Resource.AppleOrchard apple_orchard = new Workplace.Resource.AppleOrchard(-1);
        public static Workplace.Resource.ChildCookery child_cookery = new Workplace.Resource.ChildCookery(-1);
        public static Workplace.ScienceLab science_lab = new Workplace.ScienceLab(-1);
        public static Workplace.ScoutStation scout_station = new Workplace.ScoutStation(-1);
        public static Building.Warehouse warehouse = new Building.Warehouse(-1);
        public static bool able_to_cool = false;

    public static void ResetBuildings(){
        buildings = new Building[1];
        pub = new PolicyBuilding.Pub(-1);
        house_of_pleasure = new PolicyBuilding.HouseOfPleasure(-1);
        tent = new Housing.Tent(-1);
        house = new Housing.House(-1);
        apartment = new Housing.Apartment(-1);
        medical_tent = new Workplace.Medical.MedicalTent(-1);
        hospital = new Workplace.Medical.Hospital(-1);
        iron_mine = new Workplace.Resource.IronMine(-1);
        solar_panel = new Workplace.Resource.SolarPanel(-1);
        coal_mine = new Workplace.Resource.CoalMine(-1);
        fishermans_hut = new Workplace.Resource.FishermansHut(-1);
        apple_orchard = new Workplace.Resource.AppleOrchard(-1);
        child_cookery = new Workplace.Resource.ChildCookery(-1);
        science_lab = new Workplace.ScienceLab(-1);
        scout_station = new Workplace.ScoutStation(-1);
        warehouse = new Building.Warehouse(-1);
        buildings[0] = new Building.Warehouse(-1);
    }

    public static int OverallHousingSpace(){
        int space = 0;
        foreach(Building building in buildings){
            if(building is Housing.Tent tent){
                space += tent.max_residents;
            }
            if(building is Housing.House house){
                space += house.max_residents;
            }
            if(building is Housing.Apartment apartment){
                space += apartment.max_residents;
            }
        }
        return space;
    }

    public static int OverallTentSpace(){
        int space = 0;
        foreach(Building building in buildings){
            if(building is Housing.Tent tent){
                space += tent.max_residents;
            }
        }
        return space;
    }

    public static int OverallHouseSpace(){
        int space = 0;
        foreach(Building building in buildings){
            if(building is Housing.House house){
                space += house.max_residents;
            }
        }
        return space;
    }

    public static int OverallApartmentSpace(){
        int space = 0;
        foreach(Building building in buildings){
            if(building is Housing.Apartment apartment){
                space += apartment.max_residents;
            }
        }
        return space;
    }

    public static int OverallSickSpace(){
        int space = 0;
        foreach(Building building in buildings){
            if(building is Workplace.Medical.MedicalTent medical_tent){
                space += medical_tent.max_sick;
            }
            if(building is Workplace.Medical.Hospital hospital){
                space += hospital.max_sick;
            }
        }
        return space;
    }

    public static int OverallPolicySpace(){
        int space = 0;
        foreach(Building building in buildings){
            if(building is PolicyBuilding.Pub pub){
                space += pub.customers;
            }
            if(building is PolicyBuilding.HouseOfPleasure house_of_pleasure){
                space += house_of_pleasure.customers;
            }
        }
        return space;
    }

    public static int OverallPolicyHappyness(){
        float happyness = 0;
        int policy_amount = 0;
        foreach(Building building in buildings){
            if(building is PolicyBuilding.Pub pub){
                happyness += pub.happyness_bonus;
                policy_amount++;
            }
            if(building is PolicyBuilding.HouseOfPleasure house_of_pleasure){
                happyness += house_of_pleasure.happyness_bonus;
                policy_amount++;
            }
        }
        return (int)(happyness / policy_amount);
    }

    public static void UpdateBuildings(){
        foreach(Building building in buildings){
            if(building is Building.Warehouse temp_warehouse){
                temp_warehouse.food_storage = warehouse.food_storage;
                temp_warehouse.power_storage = warehouse.power_storage;
                temp_warehouse.building_material_storage = warehouse.building_material_storage;
                temp_warehouse.iron_storage = warehouse.iron_storage;
            }
            if(building is PolicyBuilding.Pub temp_pub){
                temp_pub.happyness_bonus = pub.happyness_bonus;
                temp_pub.enable_cooling = pub.enable_cooling;
            }
            if(building is PolicyBuilding.HouseOfPleasure temp_house_of_pleasure){
                temp_house_of_pleasure.happyness_bonus = house_of_pleasure.happyness_bonus;
                temp_house_of_pleasure.enable_cooling = house_of_pleasure.enable_cooling;
            }
            if(building is Housing.Tent temp_tent){
                temp_tent.coolness_modifier = tent.coolness_modifier;
                temp_tent.max_residents = tent.max_residents;
                temp_tent.happyness_modifier = tent.happyness_modifier;
                temp_tent.enable_cooling = tent.enable_cooling;
                temp_tent.manual_cooling = tent.manual_cooling;
            }
            if(building is Housing.House temp_house){
                temp_house.coolness_modifier = house.coolness_modifier;
                temp_house.max_residents = house.max_residents;
                temp_house.happyness_modifier = house.happyness_modifier;
                temp_house.enable_cooling = house.enable_cooling;
                temp_house.manual_cooling = house.manual_cooling;
            }
            if(building is Housing.Apartment temp_apartment){
                temp_apartment.coolness_modifier = apartment.coolness_modifier;
                temp_apartment.max_residents = apartment.max_residents;
                temp_apartment.happyness_modifier = apartment.happyness_modifier;
                temp_apartment.enable_cooling = apartment.enable_cooling;
                temp_apartment.manual_cooling = apartment.manual_cooling;
            }
            if(building is Workplace.ScoutStation temp_scout_station){
                temp_scout_station.movement_speed = scout_station.movement_speed;
                temp_scout_station.carrying_capacity = scout_station.carrying_capacity;
            }
            if(building is Workplace.ScienceLab temp_science_lab){
                temp_science_lab.workers_efficiency = science_lab.workers_efficiency;
                temp_science_lab.children_efficiency = science_lab.children_efficiency;
                temp_science_lab.child_work = science_lab.child_work;
                temp_science_lab.sick_efficiency = science_lab.sick_efficiency;
                temp_science_lab.enable_cooling = science_lab.enable_cooling;
                temp_science_lab.working_hours = science_lab.working_hours;
                temp_science_lab.manual_cooling = science_lab.manual_cooling;
                temp_science_lab.extended_work = science_lab.extended_work;
                temp_science_lab.emergency_work = science_lab.emergency_work;
            }
            if(building is Workplace.Medical.MedicalTent temp_medical_tent){
                temp_medical_tent.max_workers = medical_tent.max_workers;
                temp_medical_tent.workers_efficiency = medical_tent.workers_efficiency;
                temp_medical_tent.children_efficiency = medical_tent.children_efficiency;
                temp_medical_tent.child_work = medical_tent.child_work;
                temp_medical_tent.sick_efficiency = medical_tent.sick_efficiency;
                temp_medical_tent.max_sick = medical_tent.max_sick;
                temp_medical_tent.treatment_speed = medical_tent.treatment_speed;
                temp_medical_tent.enable_cooling = medical_tent.enable_cooling;
                temp_medical_tent.working_hours = medical_tent.working_hours;
                temp_medical_tent.manual_cooling = medical_tent.manual_cooling;
                temp_medical_tent.extended_work = medical_tent.extended_work;
                temp_medical_tent.emergency_work = medical_tent.emergency_work;
            }
            if(building is Workplace.Medical.Hospital temp_hospital){
                temp_hospital.max_workers = hospital.max_workers;
                temp_hospital.workers_efficiency = hospital.workers_efficiency;
                temp_hospital.children_efficiency = hospital.children_efficiency;
                temp_hospital.child_work = hospital.child_work;
                temp_hospital.sick_efficiency = hospital.sick_efficiency;
                temp_hospital.max_sick = hospital.max_sick;
                temp_hospital.treatment_speed = hospital.treatment_speed;
                temp_hospital.enable_cooling = hospital.enable_cooling;
                temp_hospital.working_hours = hospital.working_hours;
                temp_hospital.manual_cooling = hospital.manual_cooling;
                temp_hospital.extended_work = hospital.extended_work;
                temp_hospital.emergency_work = hospital.emergency_work;
            }
            if(building is Workplace.Resource.SolarPanel temp_solar_panel){
                temp_solar_panel.power_production = solar_panel.power_production;
                temp_solar_panel.power_efficiency = solar_panel.power_efficiency;
            }
            if(building is Workplace.Resource.CoalMine temp_coal_mine){
                temp_coal_mine.max_workers = coal_mine.max_workers;
                temp_coal_mine.building_material_production = coal_mine.building_material_production;
                temp_coal_mine.building_material_efficiency = coal_mine.building_material_efficiency;
                temp_coal_mine.power_production = coal_mine.power_production;
                temp_coal_mine.power_efficiency = coal_mine.power_efficiency;
                temp_coal_mine.workers_efficiency = coal_mine.workers_efficiency;
                temp_coal_mine.children_efficiency = coal_mine.children_efficiency;
                temp_coal_mine.child_work = coal_mine.child_work;
                temp_coal_mine.sick_efficiency = coal_mine.sick_efficiency;
                temp_coal_mine.enable_cooling = coal_mine.enable_cooling;
                temp_coal_mine.working_hours = coal_mine.working_hours;
                temp_coal_mine.manual_cooling = coal_mine.manual_cooling;
                temp_coal_mine.extended_work = coal_mine.extended_work;
                temp_coal_mine.emergency_work = coal_mine.emergency_work;
            }
            if(building is Workplace.Resource.IronMine temp_iron_mine){
                temp_iron_mine.max_workers = iron_mine.max_workers;
                temp_iron_mine.building_material_production = iron_mine.building_material_production;
                temp_iron_mine.building_material_efficiency = iron_mine.building_material_efficiency;
                temp_iron_mine.iron_production = iron_mine.iron_production;
                temp_iron_mine.iron_efficiency = iron_mine.iron_efficiency;
                temp_iron_mine.workers_efficiency = iron_mine.workers_efficiency;
                temp_iron_mine.children_efficiency = iron_mine.children_efficiency;
                temp_iron_mine.child_work = iron_mine.child_work;
                temp_iron_mine.sick_efficiency = iron_mine.sick_efficiency;
                temp_iron_mine.enable_cooling = iron_mine.enable_cooling;
                temp_iron_mine.working_hours = iron_mine.working_hours;
                temp_iron_mine.manual_cooling = iron_mine.manual_cooling;
                temp_iron_mine.extended_work = iron_mine.extended_work;
                temp_iron_mine.emergency_work = iron_mine.emergency_work;
            }
            if(building is Workplace.Resource.AppleOrchard temp_apple_orchard){
                temp_apple_orchard.max_workers = apple_orchard.max_workers;
                temp_apple_orchard.building_material_production = apple_orchard.building_material_production;
                temp_apple_orchard.building_material_efficiency = apple_orchard.building_material_efficiency;
                temp_apple_orchard.food_production = apple_orchard.food_production;
                temp_apple_orchard.food_efficiency = apple_orchard.food_efficiency;
                temp_apple_orchard.workers_efficiency = apple_orchard.workers_efficiency;
                temp_apple_orchard.children_efficiency = apple_orchard.children_efficiency;
                temp_apple_orchard.child_work = apple_orchard.child_work;
                temp_apple_orchard.sick_efficiency = apple_orchard.sick_efficiency;
                temp_apple_orchard.enable_cooling = apple_orchard.enable_cooling;
                temp_apple_orchard.working_hours = apple_orchard.working_hours;
                temp_apple_orchard.manual_cooling = apple_orchard.manual_cooling;
                temp_apple_orchard.extended_work = apple_orchard.extended_work;
                temp_apple_orchard.emergency_work = apple_orchard.emergency_work;
            }
            if(building is Workplace.Resource.FishermansHut temp_fishermans_hut){
                temp_fishermans_hut.max_workers = fishermans_hut.max_workers;
                temp_fishermans_hut.food_production = fishermans_hut.food_production;
                temp_fishermans_hut.food_efficiency = fishermans_hut.food_efficiency;
                temp_fishermans_hut.workers_efficiency = fishermans_hut.workers_efficiency;
                temp_fishermans_hut.children_efficiency = fishermans_hut.children_efficiency;
                temp_fishermans_hut.child_work = fishermans_hut.child_work;
                temp_fishermans_hut.sick_efficiency = fishermans_hut.sick_efficiency;
                temp_fishermans_hut.enable_cooling = fishermans_hut.enable_cooling;
                temp_fishermans_hut.working_hours = fishermans_hut.working_hours;
                temp_fishermans_hut.manual_cooling = fishermans_hut.manual_cooling;
                temp_fishermans_hut.extended_work = fishermans_hut.extended_work;
                temp_fishermans_hut.emergency_work = fishermans_hut.emergency_work;
            }
            if(building is Workplace.Resource.ChildCookery temp_child_cookery){
                temp_child_cookery.max_workers = child_cookery.max_workers;
                temp_child_cookery.food_multiplier = child_cookery.food_multiplier;
                temp_child_cookery.enable_cooling = child_cookery.enable_cooling;
                temp_child_cookery.manual_cooling = child_cookery.manual_cooling;
            }
        }
    }

    public static void ChangeBuildingsDisplayed(int page, GameController game_controller){
        game_controller._building_slot_1.SetActive(false);
        game_controller._building_slot_2.SetActive(false);
        game_controller._building_slot_3.SetActive(false);
        game_controller._building_slot_1_button.interactable = false;
        game_controller._building_slot_1_add_worker.interactable = false;
        game_controller._building_slot_1_add_child.interactable = false;
        game_controller._building_slot_1_remove_worker.interactable = false;
        game_controller._building_slot_1_remove_child.interactable = false;
        game_controller._working_hours_slot1.text = "";
        game_controller._building_slot_2_button.interactable = false;
        game_controller._building_slot_2_add_worker.interactable = false;
        game_controller._building_slot_2_add_child.interactable = false;
        game_controller._building_slot_2_remove_worker.interactable = false;
        game_controller._building_slot_2_remove_child.interactable = false;
        game_controller._working_hours_slot2.text = "";
        game_controller._building_slot_3_button.interactable = false;
        game_controller._building_slot_3_add_worker.interactable = false;
        game_controller._building_slot_3_add_child.interactable = false;
        game_controller._building_slot_3_remove_worker.interactable = false;
        game_controller._building_slot_3_remove_child.interactable = false;
        game_controller._working_hours_slot3.text = "";
        var worker_info = GetWorkerInfoByWorkplace();
        switch(page){
            case 0:
                if(tent.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_1.SetActive(true);
                        game_controller._building_slot_1.transform.Find("slot_1_icon").GetComponent<Image>().sprite = Sprites.tent_logo;
                        game_controller._building_slot_1_text.text =
                            tent.description + "\n"
                            + "Resident space: " + tent.max_residents + "\n"
                            + "Happyness modifier: " + tent.happyness_modifier + "\n"
                            + tent.building_material_cost + " building materials, " + tent.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,tent.building_material_cost, tent.iron_cost)){
                            game_controller._building_slot_1_button.interactable = true;
                        }
                    }
                }
                if(house.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_2.SetActive(true);
                        game_controller._building_slot_2.transform.Find("slot_2_icon").GetComponent<Image>().sprite = Sprites.family_house_logo;
                        game_controller._building_slot_2_text.text =
                            house.description + "\n"
                            + "Resident space: " + house.max_residents + "\n"
                            + "Happyness modifier: " + house.happyness_modifier + "\n"
                            + house.building_material_cost + " building materials, " + house.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,house.building_material_cost, house.iron_cost)){
                            game_controller._building_slot_2_button.interactable = true;
                        }
                    }
                }
                if(apartment.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_3.SetActive(true);
                        game_controller._building_slot_3.transform.Find("slot_3_icon").GetComponent<Image>().sprite = Sprites.apartment_logo;
                        game_controller._building_slot_3_text.text =
                            apartment.description + "\n"
                            + "Resident space: " + apartment.max_residents + "\n"
                            + "Happyness modifier: " + apartment.happyness_modifier + "\n"
                            + apartment.building_material_cost + " building materials, " + apartment.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,apartment.building_material_cost, apartment.iron_cost)){
                            game_controller._building_slot_3_button.interactable = true;
                        }
                    }
                }
                break;
            case 1:
                if(medical_tent.active){
                    game_controller._building_slot_1.SetActive(true);
                    game_controller._building_slot_1.transform.Find("slot_1_icon").GetComponent<Image>().sprite = Sprites.medical_tent_logo;
                    if(game_controller.build_intent){
                        game_controller._building_slot_1_text.text =
                            medical_tent.description + "\n"
                            + "Sick space: " + medical_tent.max_sick + "\n"
                            + "Max workers: " + medical_tent.max_workers + "\n"
                            + medical_tent.building_material_cost + " building materials, " + medical_tent.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,medical_tent.building_material_cost, medical_tent.iron_cost)){
                            game_controller._building_slot_1_button.interactable = true;
                        }
                    } else{
                        game_controller._building_slot_1_text.text =
                            "Max workers: " + worker_info.Item1[0] + "\n"
                            + "Current workers: " + worker_info.Item2[0] + "\n"
                            + "Current sick workers: " + worker_info.Item4[0] + "\n"
                            + "Current children: " + worker_info.Item3[0] + "\n"
                            + "Current sick children: " + worker_info.Item5[0];
                        game_controller._working_hours_slot1.text = medical_tent.working_hours + "h shifts";
                        if(worker_info.Item1[0] - worker_info.Item2[0] - worker_info.Item3[0] - worker_info.Item4[0] - worker_info.Item5[0] > 0){
                            if(Residents.IsWorkerAvailable()){
                                game_controller._building_slot_1_add_worker.interactable = true;
                            }
                            if(medical_tent.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[0] != 0 || worker_info.Item4[0] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[0] != 0 || worker_info.Item5[0] != 0){
                            game_controller._building_slot_1_remove_child.interactable = true;
                        }
                    }
                }
                if(hospital.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_2.SetActive(true);
                        game_controller._building_slot_2.transform.Find("slot_2_icon").GetComponent<Image>().sprite = Sprites.hospital_logo;
                        game_controller._building_slot_2_text.text =
                            hospital.description + "\n"
                            + "Sick space: " + hospital.max_sick + "\n"
                            + "Max workers: " + hospital.max_workers + "\n"
                            + hospital.building_material_cost + " building materials, " + hospital.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,hospital.building_material_cost, hospital.iron_cost)){
                            game_controller._building_slot_2_button.interactable = true;
                        }
                    } else{
                        game_controller._building_slot_1_text.text =
                            "Max workers: " + worker_info.Item1[1] + "\n"
                            + "Current workers: " + worker_info.Item2[1] + "\n"
                            + "Current sick workers: " + worker_info.Item4[1] + "\n"
                            + "Current children: " + worker_info.Item3[1] + "\n"
                            + "Current sick children: " + worker_info.Item5[1];
                            game_controller._working_hours_slot2.text = hospital.working_hours + "h shifts";
                        if(worker_info.Item1[1] - worker_info.Item2[1] - worker_info.Item3[1] - worker_info.Item4[1] - worker_info.Item5[1] > 0){
                            if(Residents.IsWorkerAvailable()){
                                game_controller._building_slot_1_add_worker.interactable = true;
                            }
                            if(hospital.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[1] != 0 || worker_info.Item4[1] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[1] != 0 || worker_info.Item5[1] != 0){
                            game_controller._building_slot_1_remove_child.interactable = true;
                        }
                    }
                }
                break;
            case 2:
                if(science_lab.active){
                    game_controller._building_slot_1.SetActive(true);
                    game_controller._building_slot_1.transform.Find("slot_1_icon").GetComponent<Image>().sprite = Sprites.science_lab_logo;
                    if(game_controller.build_intent){
                        game_controller._building_slot_1_text.text =
                            science_lab.description + "\n"
                            + "Max workers: " + science_lab.max_workers + "\n"
                            + "Hourly max production: " + science_lab.science_production + "\n"
                            + science_lab.building_material_cost + " building materials, " + science_lab.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,science_lab.building_material_cost, science_lab.iron_cost)){
                            game_controller._building_slot_1_button.interactable = true;
                        }
                    } else{
                        game_controller._building_slot_1_text.text =
                            "Max workers: " + worker_info.Item1[2] + "\n"
                            + "Current workers: " + worker_info.Item2[2] + "\n"
                            + "Current sick workers: " + worker_info.Item4[2] + "\n"
                            + "Current children: " + worker_info.Item3[2] + "\n"
                            + "Current sick children: " + worker_info.Item5[2];
                            game_controller._working_hours_slot1.text = science_lab.working_hours + "h shifts";
                        if(worker_info.Item1[2] - worker_info.Item2[2] - worker_info.Item3[2] - worker_info.Item4[2] - worker_info.Item5[2] > 0){
                            if(Residents.IsWorkerAvailable()){
                                game_controller._building_slot_1_add_worker.interactable = true;
                            }
                            if(science_lab.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[2] != 0 || worker_info.Item4[2] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[2] != 0 || worker_info.Item5[2] != 0){
                            game_controller._building_slot_1_remove_child.interactable = true;
                        }
                    }
                }
                if(scout_station.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_2.SetActive(true);
                        game_controller._building_slot_2.transform.Find("slot_2_icon").GetComponent<Image>().sprite = Sprites.scout_station_logo;
                        game_controller._building_slot_2_text.text =
                            scout_station.description + "\n"
                            + "Scout movement speed: " + scout_station.movement_speed + "\n"
                            + "Scout carrying capacity: " + scout_station.carrying_capacity + "\n"
                            + scout_station.building_material_cost + " building materials, " + scout_station.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,scout_station.building_material_cost, scout_station.iron_cost)){
                            game_controller._building_slot_2_button.interactable = true;
                        }
                    }
                }
                break;
            case 3:
                if(fishermans_hut.active){
                    game_controller._building_slot_1.SetActive(true);
                    game_controller._building_slot_1.transform.Find("slot_1_icon").GetComponent<Image>().sprite = Sprites.fishermans_hut_logo;
                    if(game_controller.build_intent){
                        game_controller._building_slot_1_text.text =
                            fishermans_hut.description + "\n"
                            + "Max workers: " + fishermans_hut.max_workers + "\n"
                            + "Hourly max production: " + fishermans_hut.food_production + "\n"
                            + fishermans_hut.building_material_cost + " building materials, " + fishermans_hut.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,fishermans_hut.building_material_cost, fishermans_hut.iron_cost)){
                            game_controller._building_slot_1_button.interactable = true;
                        }
                    } else{
                        game_controller._building_slot_1_text.text =
                            "Max workers: " + worker_info.Item1[3] + "\n"
                            + "Current workers: " + worker_info.Item2[3] + "\n"
                            + "Current sick workers: " + worker_info.Item4[3] + "\n"
                            + "Current children: " + worker_info.Item3[3] + "\n"
                            + "Current sick children: " + worker_info.Item5[3];
                            game_controller._working_hours_slot1.text = fishermans_hut.working_hours + "h shifts";
                        if(worker_info.Item1[3] - worker_info.Item2[3] - worker_info.Item3[3] - worker_info.Item4[3] - worker_info.Item5[3] > 0){
                            if(Residents.IsWorkerAvailable()){
                                game_controller._building_slot_1_add_worker.interactable = true;
                            }
                            if(fishermans_hut.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[3] != 0 || worker_info.Item4[3] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[3] != 0 || worker_info.Item5[3] != 0){
                            game_controller._building_slot_1_remove_child.interactable = true;
                        }
                    }
                }
                if(apple_orchard.active){
                    game_controller._building_slot_2.SetActive(true);
                    game_controller._building_slot_2.transform.Find("slot_2_icon").GetComponent<Image>().sprite = Sprites.apple_orchard_logo;
                    if(game_controller.build_intent){
                        game_controller._building_slot_2_text.text =
                            apple_orchard.description + "\n"
                            + "Max workers: " + apple_orchard.max_workers + "\n"
                            + "Hourly max production:\n"
                            + apple_orchard.food_production + " food, " + apple_orchard.building_material_production + " building material\n"
                            + apple_orchard.building_material_cost + " building materials, " + apple_orchard.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,apple_orchard.building_material_cost, apple_orchard.iron_cost)){
                            game_controller._building_slot_2_button.interactable = true;
                        }
                    } else{
                        game_controller._building_slot_2_text.text =
                            "Max workers: " + worker_info.Item1[4] + "\n"
                            + "Current workers: " + worker_info.Item2[4] + "\n"
                            + "Current sick workers: " + worker_info.Item4[4] + "\n"
                            + "Current children: " + worker_info.Item3[4] + "\n"
                            + "Current sick children: " + worker_info.Item5[4];
                            game_controller._working_hours_slot2.text = apple_orchard.working_hours + "h shifts";
                        if(worker_info.Item1[4] - worker_info.Item2[4] - worker_info.Item3[4] - worker_info.Item4[4] - worker_info.Item5[4] > 0){
                            if(Residents.IsWorkerAvailable()){
                                game_controller._building_slot_2_add_worker.interactable = true;
                            }
                            if(apple_orchard.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_2_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[4] != 0 || worker_info.Item4[4] != 0){
                            game_controller._building_slot_2_remove_worker.interactable = true;
                        }if(worker_info.Item3[4] != 0 || worker_info.Item5[4] != 0){
                            game_controller._building_slot_2_remove_child.interactable = true;
                        }
                    }
                }
                if(child_cookery.active){
                    game_controller._building_slot_3.SetActive(true);
                    game_controller._building_slot_3.transform.Find("slot_3_icon").GetComponent<Image>().sprite = Sprites.child_cookery_logo;
                    if(game_controller.build_intent){
                        game_controller._building_slot_3_text.text =
                            child_cookery.description + "\n"
                            + "Max children: " + child_cookery.max_workers + "\n"
                            + "Max food modifier: " + child_cookery.food_multiplier + "\n"
                            + child_cookery.building_material_cost + " building materials, " + child_cookery.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,child_cookery.building_material_cost, child_cookery.iron_cost)){
                            game_controller._building_slot_3_button.interactable = true;
                        }
                    } else{
                        game_controller._building_slot_3_text.text =
                            "Max workers: " + worker_info.Item1[5] + "\n"
                            + "Current workers: " + worker_info.Item2[5] + "\n"
                            + "Current sick workers: " + worker_info.Item4[5] + "\n"
                            + "Current children: " + worker_info.Item3[5] + "\n"
                            + "Current sick children: " + worker_info.Item5[5];
                            game_controller._working_hours_slot2.text = "Active all day";
                        if(worker_info.Item1[5] - worker_info.Item2[5] - worker_info.Item3[5] - worker_info.Item4[5] - worker_info.Item5[5] > 0){
                            if(Residents.IsChildrenAvailable()){
                                game_controller._building_slot_3_add_child.interactable = true;
                            }
                            if(worker_info.Item3[5] != 0 || worker_info.Item5[5] != 0){
                                game_controller._building_slot_3_remove_child.interactable = true;
                            }
                        }
                    }
                }
                break;
            case 4:
                if(solar_panel.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_1.SetActive(true);
                        game_controller._building_slot_1.transform.Find("slot_1_icon").GetComponent<Image>().sprite = Sprites.solar_panel_logo;
                        game_controller._building_slot_1_text.text =
                            solar_panel.description + "\n"
                            + "Max workers: automatic\n"
                            + "Hourly max production: " + solar_panel.power_production + "\n"
                            + solar_panel.building_material_cost + " building materials, " + solar_panel.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,solar_panel.building_material_cost, solar_panel.iron_cost)){
                            game_controller._building_slot_1_button.interactable = true;
                        }
                    }
                }
                if(coal_mine.active){
                    game_controller._building_slot_2.SetActive(true);
                    game_controller._building_slot_2.transform.Find("slot_2_icon").GetComponent<Image>().sprite = Sprites.coal_mine_logo;
                    if(game_controller.build_intent){
                        game_controller._building_slot_2_text.text =
                            coal_mine.description + "\n"
                            + "Max workers: " + coal_mine.max_workers + "\n"
                            + "Hourly max production:\n"
                            + coal_mine.power_production + " power, " + coal_mine.building_material_production + " building material\n"
                            + coal_mine.building_material_cost + " building materials, " + coal_mine.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,coal_mine.building_material_cost, coal_mine.iron_cost)){
                            game_controller._building_slot_2_button.interactable = true;
                        }
                    } else{
                        game_controller._building_slot_2_text.text =
                            "Max workers: " + worker_info.Item1[6] + "\n"
                            + "Current workers: " + worker_info.Item2[6] + "\n"
                            + "Current sick workers: " + worker_info.Item4[6] + "\n"
                            + "Current children: " + worker_info.Item3[6] + "\n"
                            + "Current sick children: " + worker_info.Item5[6];
                            game_controller._working_hours_slot2.text = coal_mine.working_hours + "h shifts";
                        if(worker_info.Item1[6] - worker_info.Item2[6] - worker_info.Item3[6] - worker_info.Item4[6] - worker_info.Item5[6] > 0){
                            if(Residents.IsWorkerAvailable()){
                                game_controller._building_slot_2_add_worker.interactable = true;
                            }
                            if(coal_mine.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_2_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[6] != 0 || worker_info.Item4[6] != 0){
                            game_controller._building_slot_2_remove_worker.interactable = true;
                        }if(worker_info.Item3[6] != 0 || worker_info.Item5[6] != 0){
                            game_controller._building_slot_2_remove_child.interactable = true;
                        }
                    }
                }
                break;
            case 5:
                if(iron_mine.active){
                    game_controller._building_slot_1.SetActive(true);
                    game_controller._building_slot_1.transform.Find("slot_1_icon").GetComponent<Image>().sprite = Sprites.iron_mine_logo;
                    if(game_controller.build_intent){
                        game_controller._building_slot_1_text.text =
                            iron_mine.description + "\n"
                            + "Max workers: " + iron_mine.max_workers + "\n"
                            + "Hourly max production:\n"
                            + iron_mine.iron_production + " iron, " + iron_mine.building_material_production + " building material\n"
                            + iron_mine.building_material_cost + " building materials, " + iron_mine.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,iron_mine.building_material_cost, iron_mine.iron_cost)){
                            game_controller._building_slot_1_button.interactable = true;
                        }
                    } else{
                        game_controller._building_slot_1_text.text =
                            "Max workers: " + worker_info.Item1[7] + "\n"
                            + "Current workers: " + worker_info.Item2[7] + "\n"
                            + "Current sick workers: " + worker_info.Item4[7] + "\n"
                            + "Current children: " + worker_info.Item3[7] + "\n"
                            + "Current sick children: " + worker_info.Item5[7];
                            game_controller._working_hours_slot1.text = iron_mine.working_hours + "h shifts";
                        if(worker_info.Item1[7] - worker_info.Item2[7] - worker_info.Item3[7] - worker_info.Item4[7] - worker_info.Item5[7] > 0){
                            if(Residents.IsWorkerAvailable()){
                                game_controller._building_slot_1_add_worker.interactable = true;
                            }
                            if(iron_mine.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[7] != 0 || worker_info.Item4[7] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[7] != 0 || worker_info.Item5[7] != 0){
                            game_controller._building_slot_1_remove_child.interactable = true;
                        }
                    }
                }
                if(warehouse.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_2.SetActive(true);
                        game_controller._building_slot_2.transform.Find("slot_2_icon").GetComponent<Image>().sprite = Sprites.warehouse_logo;
                        game_controller._building_slot_2_text.text =
                            warehouse.description + "\n"
                            + "Storage space: " + warehouse.food_storage + " food,\n"
                            + warehouse.power_storage + " power, " + warehouse.iron_storage + " iron,\n"
                            + warehouse.building_material_storage + " building material\n"
                            + warehouse.building_material_cost + " building materials, " + warehouse.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,warehouse.building_material_cost, warehouse.iron_cost)){
                            game_controller._building_slot_2_button.interactable = true;
                        }
                    }
                }
                break;
            case 6:
                if(pub.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_1.SetActive(true);
                        game_controller._building_slot_1.transform.Find("slot_1_icon").GetComponent<Image>().sprite = Sprites.pub_logo;
                        game_controller._building_slot_1_text.text =
                            pub.description + "\n"
                            + "Max customers: " + pub.customers + "\n"
                            + "Happyness bonus :" + pub.happyness_bonus + "\n"
                            + pub.building_material_cost + " building materials, " + pub.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,pub.building_material_cost, pub.iron_cost)){
                            game_controller._building_slot_1_button.interactable = true;
                        }
                    }
                }
                if(house_of_pleasure.active){
                    if(game_controller.build_intent){
                        game_controller._building_slot_2.SetActive(true);
                        game_controller._building_slot_2.transform.Find("slot_2_icon").GetComponent<Image>().sprite = Sprites.house_of_pleasure_logo;
                        game_controller._building_slot_2_text.text =
                            house_of_pleasure.description + "\n"
                            + "Max customers: " + house_of_pleasure.customers + "\n"
                            + "Happyness bonus :" + house_of_pleasure.happyness_bonus + "\n"
                            + house_of_pleasure.building_material_cost + " building materials, " + house_of_pleasure.iron_cost + " iron";
                        if(ResourcesManager.CanAfford(0,0,house_of_pleasure.building_material_cost, house_of_pleasure.iron_cost)){
                            game_controller._building_slot_2_button.interactable = true;
                        }
                    }
                }
                break;
        }
    }

    public static void BuildBuilding(int slot_id, GameController game_controller){
        Building[] tempArray = new Building[buildings.Length + 1];
        for(int i = 0; i < buildings.Length; i++){
            tempArray[i] = buildings[i];
        }
        buildings = tempArray;
        switch(game_controller.open_building_tab){
            case 0:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Housing.Tent(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,tent.building_material_cost, tent.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Housing.House(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,house.building_material_cost, house.iron_cost);
                        break;
                    case 2:
                        buildings[buildings.Length - 1] = new Housing.Apartment(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,apartment.building_material_cost, apartment.iron_cost);
                        break;
                }
                break;
            case 1:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.Medical.MedicalTent(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,medical_tent.building_material_cost, medical_tent.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Workplace.Medical.Hospital(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,hospital.building_material_cost, hospital.iron_cost);
                        break;
                }
                break;
            case 2:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.ScienceLab(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,science_lab.building_material_cost, science_lab.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Workplace.ScoutStation(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,scout_station.building_material_cost, scout_station.iron_cost);
                        game_controller._scouting_menu.GetComponent<Button>().interactable = true;
                        game_controller._scouting_menu.GetComponent<Image>().color = Color.black;
                        scout_station.active = false;
                        Scouting.direction[0] = true;
                        Scouting.storm_direction[0] = true;
                        break;
                }
                break;
            case 3:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.Resource.FishermansHut(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,fishermans_hut.building_material_cost, fishermans_hut.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Workplace.Resource.AppleOrchard(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,apple_orchard.building_material_cost, apple_orchard.iron_cost);
                        break;
                    case 2:
                        buildings[buildings.Length - 1] = new Workplace.Resource.ChildCookery(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,child_cookery.building_material_cost, child_cookery.iron_cost);
                        child_cookery.active = false;
                        break;
                }
                break;
            case 4:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.Resource.SolarPanel(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,solar_panel.building_material_cost, solar_panel.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Workplace.Resource.CoalMine(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,coal_mine.building_material_cost, coal_mine.iron_cost);
                        break;
                }
                break;
            case 5:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.Resource.IronMine(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,iron_mine.building_material_cost, iron_mine.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Building.Warehouse(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,warehouse.building_material_cost, warehouse.iron_cost);
                        break;
                }
                break;
            case 6:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new PolicyBuilding.Pub(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,pub.building_material_cost, pub.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new PolicyBuilding.HouseOfPleasure(game_controller.open_tile);
                        ResourcesManager.PayResources(0,0,house_of_pleasure.building_material_cost, house_of_pleasure.iron_cost);
                        break;
                }
                break;
        }
        UpdateBuildings();
        ResourcesManager.RefreshResourcesWidget(game_controller);
        game_controller.AdjustResidents();
    }

    public static System.Tuple<int[], int[], int[], int[], int[]> GetWorkerInfoByWorkplace(){
        int[] max_workers = new int[8];
        int[] current_workers = new int[8];
        int[] current_children = new int[8];
        int[] current_sick = new int[8];
        int[] current_child_sick = new int[8];
        foreach(Building building in buildings){
            if(building is Workplace.Medical.MedicalTent medical_tent){
                max_workers[0] += medical_tent.max_workers;
                current_workers[0] += medical_tent.current_workers;
                current_children[0] += medical_tent.children_workers;
                current_sick[0] += medical_tent.sick_workers;
                current_child_sick[0] += medical_tent.sick_child_workers;
            }
            if(building is Workplace.Medical.Hospital hospital){
                max_workers[1] += hospital.max_workers;
                current_workers[1] += hospital.current_workers;
                current_children[1] += hospital.children_workers;
                current_sick[1] += hospital.sick_workers;
                current_child_sick[1] += hospital.sick_child_workers;
            }
            if(building is Workplace.ScienceLab science_lab){
                max_workers[2] += science_lab.max_workers;
                current_workers[2] += science_lab.current_workers;
                current_children[2] += science_lab.children_workers;
                current_sick[2] += science_lab.sick_workers;
                current_child_sick[2] += science_lab.sick_child_workers;
            }
            if(building is Workplace.Resource.FishermansHut fishermans_hut){
                max_workers[3] += fishermans_hut.max_workers;
                current_workers[3] += fishermans_hut.current_workers;
                current_children[3] += fishermans_hut.children_workers;
                current_sick[3] += fishermans_hut.sick_workers;
                current_child_sick[3] += fishermans_hut.sick_child_workers;
            }
            if(building is Workplace.Resource.AppleOrchard apple_orchard){
                max_workers[4] += apple_orchard.max_workers;
                current_workers[4] += apple_orchard.current_workers;
                current_children[4] += apple_orchard.children_workers;
                current_sick[4] += apple_orchard.sick_workers;
                current_child_sick[4] += apple_orchard.sick_child_workers;
            }
            if(building is Workplace.Resource.ChildCookery child_cookery){
                max_workers[5] += child_cookery.max_workers;
                current_workers[5] += child_cookery.current_workers;
                current_children[5] += child_cookery.children_workers;
                current_sick[5] += child_cookery.sick_workers;
                current_child_sick[5] += child_cookery.sick_child_workers;
            }
            if(building is Workplace.Resource.CoalMine coal_mine){
                max_workers[6] += coal_mine.max_workers;
                current_workers[6] += coal_mine.current_workers;
                current_children[6] += coal_mine.children_workers;
                current_sick[6] += coal_mine.sick_workers;
                current_child_sick[6] += coal_mine.sick_child_workers;
            }
            if(building is Workplace.Resource.IronMine iron_mine){
                max_workers[7] += iron_mine.max_workers;
                current_workers[7] += iron_mine.current_workers;
                current_children[7] += iron_mine.children_workers;
                current_sick[7] += iron_mine.sick_workers;
                current_child_sick[7] += iron_mine.sick_child_workers;
            }
        }
        return new System.Tuple<int[], int[], int[], int[], int[]>(max_workers, current_workers, current_children, current_sick, current_child_sick);
    }

    public static int GetCurrentWorkHours(int slot_id, GameController game_controller){
        switch(game_controller.open_building_tab){
            case 1:
                switch(slot_id){
                    case 0:
                        return medical_tent.working_hours;
                    case 1:
                        return hospital.working_hours;
                }
                break;
            case 2:
                switch(slot_id){
                    case 0:
                        return science_lab.working_hours;
                }
                break;
            case 3:
                switch(slot_id){
                    case 0:
                        return fishermans_hut.working_hours;
                    case 1:
                        return apple_orchard.working_hours;
                }
                break;
            case 4:
                switch(slot_id){
                    case 1:
                        return coal_mine.working_hours;
                }
                break;
            case 5:
                switch(slot_id){
                    case 0:
                        return iron_mine.working_hours;
                }
                break;
        }
        return -1;
    }

    public static void ChangeWorkHours(int slot_id, GameController game_controller){
        switch(game_controller.open_people_tab){
            case 1:
                switch(slot_id){
                    case 0:
                        if(medical_tent.working_hours == 8 && medical_tent.extended_work){
                            medical_tent.working_hours = 12;
                        } else if(medical_tent.working_hours == 8 && !medical_tent.extended_work && medical_tent.emergency_work){
                            medical_tent.working_hours = 24;
                        } else if(medical_tent.working_hours == 12 && medical_tent.emergency_work){
                            medical_tent.working_hours = 24;
                        } else{
                            medical_tent.working_hours = 8;
                        }
                        break;
                    case 1:
                        if(hospital.working_hours == 8 && hospital.extended_work){
                            hospital.working_hours = 12;
                        } else if(hospital.working_hours == 8 && !hospital.extended_work && hospital.emergency_work){
                            hospital.working_hours = 24;
                        } else if(hospital.working_hours == 12 && hospital.emergency_work){
                            hospital.working_hours = 24;
                        } else{
                            hospital.working_hours = 8;
                        }
                        break;
                }
                break;
            case 2:
                switch(slot_id){
                    case 0:
                        if(science_lab.working_hours == 8 && science_lab.extended_work){
                            science_lab.working_hours = 12;
                        } else if(science_lab.working_hours == 8 && !science_lab.extended_work && science_lab.emergency_work){
                            science_lab.working_hours = 24;
                        } else if(science_lab.working_hours == 12 && science_lab.emergency_work){
                            science_lab.working_hours = 24;
                        } else{
                            science_lab.working_hours = 8;
                        }
                        break;
                }
                break;
            case 3:
                switch(slot_id){
                    case 0:
                        if(fishermans_hut.working_hours == 8 && fishermans_hut.extended_work){
                            fishermans_hut.working_hours = 12;
                        } else if(fishermans_hut.working_hours == 8 && !fishermans_hut.extended_work && fishermans_hut.emergency_work){
                            fishermans_hut.working_hours = 24;
                        } else if(fishermans_hut.working_hours == 12 && fishermans_hut.emergency_work){
                            fishermans_hut.working_hours = 24;
                        } else{
                            fishermans_hut.working_hours = 8;
                        }
                        break;
                    case 1:
                        if(apple_orchard.working_hours == 8 && apple_orchard.extended_work){
                            apple_orchard.working_hours = 12;
                        } else if(apple_orchard.working_hours == 8 && !apple_orchard.extended_work && apple_orchard.emergency_work){
                            apple_orchard.working_hours = 24;
                        } else if(apple_orchard.working_hours == 12 && apple_orchard.emergency_work){
                            apple_orchard.working_hours = 24;
                        } else{
                            apple_orchard.working_hours = 8;
                        }
                        break;
                }
                break;
            case 4:
                switch(slot_id){
                    case 1:
                        if(coal_mine.working_hours == 8 && coal_mine.extended_work){
                            coal_mine.working_hours = 12;
                        } else if(coal_mine.working_hours == 8 && !coal_mine.extended_work && coal_mine.emergency_work){
                            coal_mine.working_hours = 24;
                        } else if(coal_mine.working_hours == 12 && coal_mine.emergency_work){
                            coal_mine.working_hours = 24;
                        } else{
                            coal_mine.working_hours = 8;
                        }
                        break;
                }
                break;
            case 5:
                switch(slot_id){
                    case 0:
                        if(iron_mine.working_hours == 8 && iron_mine.extended_work){
                            iron_mine.working_hours = 12;
                        } else if(iron_mine.working_hours == 8 && !iron_mine.extended_work && iron_mine.emergency_work){
                            iron_mine.working_hours = 24;
                        } else if(iron_mine.working_hours == 12 && iron_mine.emergency_work){
                            iron_mine.working_hours = 24;
                        } else{
                            iron_mine.working_hours = 8;
                        }
                        break;
                }
                break;
        }
        UpdateBuildings();
        ChangeBuildingsDisplayed(game_controller.open_people_tab, game_controller);
    }

    public static void ChangeBuildingWorkHours(GameController game_controller){
        foreach(Building building in buildings){
            if(building.tile == game_controller.open_tile && building is Workplace workplace){
                if(workplace.working_hours == 8 && workplace.extended_work){
                    workplace.working_hours = 12;
                } else if(workplace.working_hours == 8 && !workplace.extended_work && workplace.emergency_work){
                    workplace.working_hours = 24;
                } else if(workplace.working_hours == 12 && workplace.emergency_work){
                    workplace.working_hours = 24;
                } else{
                    workplace.working_hours = 8;
                }
            }
        }
        GetTileInfo(game_controller.open_tile, game_controller);
    }

    public static void GetTileInfo(int tile, GameController game_controller){
        game_controller.open_tile = tile;
        bool empty = true;
        foreach(Building building in buildings){
            if(building.tile == tile){
                game_controller.open_building = building;
                game_controller.building_info.SetActive(true);
                game_controller.building_info.transform.Find("building_name").GetComponent<Text>().text = building.name;
                game_controller.building_info.transform.Find("slot_1").gameObject.SetActive(false);
                game_controller.building_info.transform.Find("slot_2").gameObject.SetActive(false);
                game_controller.building_info.transform.Find("slot_2").Find("slot_2_people_buttons").Find("slot_2_add_worker").GetComponent<Button>().interactable = false;
                game_controller.building_info.transform.Find("slot_2").Find("slot_2_people_buttons").Find("slot_2_add_children").GetComponent<Button>().interactable = false;
                game_controller.building_info.transform.Find("slot_2").Find("slot_2_people_buttons").Find("slot_2_remove_worker").GetComponent<Button>().interactable = false;
                game_controller.building_info.transform.Find("slot_2").Find("slot_2_people_buttons").Find("slot_2_remove_children").GetComponent<Button>().interactable = false;
                game_controller.building_info.transform.Find("slot_2_warehouse").gameObject.SetActive(false);
                game_controller.building_info.transform.Find("slot_2_housing").gameObject.SetActive(false);
                game_controller.building_info.transform.Find("slot_2_policy").gameObject.SetActive(false);
                game_controller.building_info.transform.Find("slot_3").gameObject.SetActive(false);
                game_controller.building_info.transform.Find("slot_3").Find("slot_3_temperature_buttons").Find("slot_3_increase_temperature").GetComponent<Button>().interactable = false;
                game_controller.building_info.transform.Find("slot_3").Find("slot_3_temperature_buttons").Find("slot_3_decrease_temperature").GetComponent<Button>().interactable = false;

                // Slot 1
                game_controller.building_info.transform.Find("slot_1").gameObject.SetActive(true);
                game_controller.building_info.transform.Find("slot_1").Find("slot_1_icon").GetComponent<Image>().sprite = building.icon;
                game_controller.building_info.transform.Find("slot_1").Find("slot_1_text").GetComponent<Text>().text = building.description;
                game_controller.building_info.transform.Find("slot_1").Find("slot_1_text").GetComponent<Text>().text = building.description + "\n" + building.special_info;
                if(building is Workplace.Medical medical){
                    game_controller.building_info.transform.Find("slot_1").Find("slot_1_text").GetComponent<Text>().text = building.description + "\nCurrect patients: " + medical.current_sick + "\nMax patients : " + medical.max_sick + "\nSick treatment speed: " + (medical.treatment_speed * (medical.current_workers * medical.workers_efficiency + medical.children_workers * medical.children_efficiency + medical.sick_workers * medical.sick_efficiency + medical.sick_child_workers * medical.sick_efficiency) / medical.max_workers * medical.working_hours / 24) + "x";
                }
                if(building is Workplace.Resource resource){
                    float happyness_multiplier = 0;
                    happyness_multiplier = Residents.happyness_state=="happy"?1.25F:happyness_multiplier;
                    happyness_multiplier = Residents.happyness_state=="neutral"?1F:happyness_multiplier;
                    happyness_multiplier = Residents.happyness_state=="sad"?0.75F:happyness_multiplier;
                    float actual_food_production_modifier = 1F;
                    foreach(Building temp_building in buildings){
                        if(temp_building is Workplace.Resource.ChildCookery temp_child_cookery){
                            actual_food_production_modifier = ResourcesManager.food_production_modifier * (1 + (temp_child_cookery.food_multiplier - 1) / temp_child_cookery.max_workers * (temp_child_cookery.children_workers + temp_child_cookery.sick_child_workers * temp_child_cookery.sick_efficiency));
                        }
                    }
                    int actual_food_production = (int)(resource.food_production / resource.max_workers * (resource.current_workers * resource.workers_efficiency + resource.children_workers * resource.children_efficiency + resource.sick_workers * resource.sick_efficiency + resource.sick_child_workers * resource.sick_efficiency));
                    int food_production = (int)(actual_food_production * resource.food_efficiency * happyness_multiplier * actual_food_production_modifier * (float)(100F - GameOptions.overall_costs * 2F) / 100F);
                    float food_multiplier = (resource.current_workers * resource.workers_efficiency + resource.children_workers * resource.children_efficiency + resource.sick_workers * resource.sick_efficiency + resource.sick_child_workers * resource.sick_efficiency) / resource.max_workers * resource.food_efficiency * happyness_multiplier * actual_food_production_modifier;
                    int actual_power_production = (int)(resource.power_production / resource.max_workers * (resource.current_workers * resource.workers_efficiency + resource.children_workers * resource.children_efficiency + resource.sick_workers * resource.sick_efficiency + resource.sick_child_workers * resource.sick_efficiency));
                    int power_production = (int)(actual_power_production * resource.power_efficiency * happyness_multiplier * (100 - GameOptions.overall_costs * 2) / 100);
                    float power_multiplier = (resource.current_workers * resource.workers_efficiency + resource.children_workers * resource.children_efficiency + resource.sick_workers * resource.sick_efficiency + resource.sick_child_workers * resource.sick_efficiency) / resource.max_workers * resource.power_efficiency * happyness_multiplier;
                    int actual_building_material_production = (int)(resource.building_material_production / resource.max_workers * (resource.current_workers * resource.workers_efficiency + resource.children_workers * resource.children_efficiency + resource.sick_workers * resource.sick_efficiency + resource.sick_child_workers * resource.sick_efficiency));
                    int building_material_production = (int)(actual_building_material_production * resource.building_material_efficiency * happyness_multiplier * (100 - GameOptions.overall_costs * 2) / 100);
                    float building_material_multiplier = (resource.current_workers * resource.workers_efficiency + resource.children_workers * resource.children_efficiency + resource.sick_workers * resource.sick_efficiency + resource.sick_child_workers * resource.sick_efficiency) / resource.max_workers * resource.building_material_efficiency * happyness_multiplier;
                    int actual_iron_production = (int)(resource.iron_production / resource.max_workers * (resource.current_workers * resource.workers_efficiency + resource.children_workers * resource.children_efficiency + resource.sick_workers * resource.sick_efficiency + resource.sick_child_workers * resource.sick_efficiency));
                    int iron_production = (int)(actual_iron_production * resource.iron_efficiency * happyness_multiplier * (100 - GameOptions.overall_costs * 2) / 100);
                    float iron_multiplier = (resource.current_workers * resource.workers_efficiency + resource.children_workers * resource.children_efficiency + resource.sick_workers * resource.sick_efficiency + resource.sick_child_workers * resource.sick_efficiency) / resource.max_workers * resource.iron_efficiency * happyness_multiplier;

                    String building_material = resource.building_material_production>0?"Building material production: " + building_material_production + "/h":"";
                    String building_material_efficiency = resource.building_material_production>0?"Building material production efficiency: " + building_material_multiplier + "x":"";
                    String iron = resource.iron_production>0?"Iron production: " + iron_production + "/h":"";
                    String iron_production_efficiency = resource.iron_production>0?"Iron production efficiency: " + iron_multiplier + "x":"";
                    String power = resource.power_production>0?"Power production: " + power_production + "/h":"";
                    String power_production_efficiency = resource.power_production>0?"Power production efficiency: " + power_multiplier + "x":"";
                    String food = resource.food_production>0?"Food production: " + food_production + "/h":"";
                    String food_production_efficiency = resource.food_production>0?"Food production efficiency: " + food_multiplier + "x":"";
                    String final_text = building_material==""?"":building_material + "\n";
                    final_text = building_material_efficiency==""?final_text:final_text + building_material_efficiency + "\n";
                    final_text = iron==""?final_text:final_text + iron + "\n";
                    final_text = iron_production_efficiency==""?final_text:final_text + iron_production_efficiency + "\n";
                    final_text = power==""?final_text:final_text + power + "\n";
                    final_text = power_production_efficiency==""?final_text:final_text + power_production_efficiency + "\n";
                    final_text = food==""?final_text:final_text + food + "\n";
                    final_text = food_production_efficiency==""?final_text:final_text + food_production_efficiency;
                    game_controller.building_info.transform.Find("slot_1").Find("slot_1_text").GetComponent<Text>().text = final_text;
                }
                if(building is Workplace.Resource.ChildCookery child_cookery){
                    game_controller.building_info.transform.Find("slot_1").Find("slot_1_text").GetComponent<Text>().text = child_cookery.description + "\n" + child_cookery.special_info + "\nFood production multiplier: " + (1 + (child_cookery.food_multiplier - 1) / child_cookery.max_workers * (child_cookery.children_workers + child_cookery.sick_child_workers * child_cookery.sick_efficiency)) + "x";
                }
                if(building is Workplace.ScienceLab science_lab){
                    game_controller.building_info.transform.Find("slot_1").Find("slot_1_text").GetComponent<Text>().text = science_lab.description + "\n" + science_lab.special_info + "\nWork efficiency: " + ((science_lab.current_workers * science_lab.workers_efficiency + science_lab.children_workers * science_lab.children_efficiency + science_lab.sick_workers * science_lab.sick_efficiency + science_lab.sick_child_workers * science_lab.sick_efficiency) / science_lab.max_workers) + "x";
                }
                if(building is Workplace.ScoutStation scout_station){
                    game_controller.building_info.transform.Find("slot_1").Find("slot_1_text").GetComponent<Text>().text = scout_station.description + "\n" + scout_station.special_info + "\nMovement speed: " + scout_station.movement_speed + "x" + "\nCarrying capacity: " + scout_station.carrying_capacity;
                }

                // Slot 2
                if(building is Building.Warehouse warehouse){
                    game_controller.building_info.transform.Find("slot_2_warehouse").gameObject.SetActive(true);
                    game_controller.building_info.transform.Find("slot_2_warehouse").Find("slot_2_text").GetComponent<Text>().text = "Food capacity: " + warehouse.food_storage + "\nPower capacity: " + warehouse.power_storage + "\nBuilding material capacity: " + warehouse.building_material_storage + "\n Iron capacity" + warehouse.iron_storage;
                }
                if(building is Housing housing){
                    game_controller.building_info.transform.Find("slot_2_housing").gameObject.SetActive(true);
                    game_controller.building_info.transform.Find("slot_2_housing").Find("slot_2_text").GetComponent<Text>().text = "Housing base cooling: " + (housing.coolness + housing.coolness_modifier) + "°C\nMax residents: " + housing.max_residents + "\nHousing happyness modifier: " + housing.happyness_modifier;
                }
                if(building is PolicyBuilding policy_building){
                    game_controller.building_info.transform.Find("slot_2_policy").gameObject.SetActive(true);
                    game_controller.building_info.transform.Find("slot_2_policy").Find("slot_2_text").GetComponent<Text>().text = "Max customers: " + policy_building.customers + "\nHappyness bonus: " + policy_building.happyness_bonus;
                }
                if(building is Workplace workplace && workplace.name != "Scout station"  && workplace.name != "Solar panel"){
                    game_controller.building_info.transform.Find("slot_2").gameObject.SetActive(true);
                    Sprite icon = workplace.working_hours==8?Sprites.day:Sprites.extended_day;
                    icon = workplace.working_hours==24?Sprites.night:icon;
                    game_controller.building_info.transform.Find("slot_2").Find("slot_2_icon").GetComponent<Image>().sprite = icon;
                    game_controller.building_info.transform.Find("slot_2").Find("slot_2_working_hours").GetComponent<Text>().text = workplace.working_hours + "h shifts";
                    game_controller.building_info.transform.Find("slot_2").Find("slot_2_text").GetComponent<Text>().text = "Max workers: " + workplace.max_workers + "\nCurrent workers: " + workplace.current_workers + "\nCurrent children: " + workplace.children_workers + "\nCurrent sick: " + (workplace.sick_workers + workplace.sick_child_workers);
                    if(workplace.max_workers - workplace.current_workers - workplace.children_workers - workplace.sick_workers - workplace.sick_child_workers > 0){
                        if(Residents.IsWorkerAvailable() && workplace.name != "Child cookery"){
                            game_controller.building_info.transform.Find("slot_2").Find("slot_2_people_buttons").Find("slot_2_add_worker").GetComponent<Button>().interactable = true;
                        }
                        if(workplace.child_work && Residents.IsChildrenAvailable()){
                            game_controller.building_info.transform.Find("slot_2").Find("slot_2_people_buttons").Find("slot_2_add_children").GetComponent<Button>().interactable = true;
                        }
                    }
                    if(workplace.current_workers + workplace.sick_workers != 0){
                        game_controller.building_info.transform.Find("slot_2").Find("slot_2_people_buttons").Find("slot_2_remove_worker").GetComponent<Button>().interactable = true;
                    }
                    if(workplace.children_workers + workplace.sick_child_workers != 0){
                        game_controller.building_info.transform.Find("slot_2").Find("slot_2_people_buttons").Find("slot_2_remove_children").GetComponent<Button>().interactable = true;
                    }
                }

                // Slot 3
                if(building is Housing temp_housing){
                    game_controller.building_info.transform.Find("slot_3").gameObject.SetActive(true);
                    if(temp_housing.manual_cooling){
                        game_controller.building_info.transform.Find("slot_3").Find("slot_3_temperature_buttons").Find("slot_3_increase_temperature").GetComponent<Button>().interactable = true;
                        game_controller.building_info.transform.Find("slot_3").Find("slot_3_temperature_buttons").Find("slot_3_decrease_temperature").GetComponent<Button>().interactable = true;
                    }
                    int power_consumption = (int)((game_controller.temperature - game_controller.base_cooling - temp_housing.coolness - temp_housing.coolness_modifier - temp_housing.target_temperature) * ResourcesManager.cooling_efficiency);
                    if(power_consumption < 0 || !temp_housing.enable_cooling){
                        power_consumption = 0;
                    }
                    int current_temperature = temp_housing.enable_cooling?temp_housing.target_temperature:game_controller.temperature-(temp_housing.coolness + temp_housing.coolness_modifier);
                    current_temperature = ResourcesManager.power>0?current_temperature:game_controller.temperature-(temp_housing.coolness + temp_housing.coolness_modifier);
                    game_controller.building_info.transform.Find("slot_3").Find("slot_3_text").GetComponent<Text>().text = "Target temperature: " + temp_housing.target_temperature + "\nBase cooling: " + (temp_housing.coolness + temp_housing.coolness_modifier + game_controller.base_cooling) + "\nPower consumption: " + power_consumption + "\nCurrent temperature: " + current_temperature;
                }
                if(building is Workplace temp_workplace && temp_workplace.name != "Scout station" && temp_workplace.name != "Solar panel"){
                    game_controller.building_info.transform.Find("slot_3").gameObject.SetActive(true);
                    if(temp_workplace.manual_cooling){
                        game_controller.building_info.transform.Find("slot_3").Find("slot_3_temperature_buttons").Find("slot_3_increase_temperature").GetComponent<Button>().interactable = true;
                        game_controller.building_info.transform.Find("slot_3").Find("slot_3_temperature_buttons").Find("slot_3_decrease_temperature").GetComponent<Button>().interactable = true;
                    }
                    int power_consumption = (int)((game_controller.temperature - game_controller.base_cooling - temp_workplace.coolness - temp_workplace.coolness_modifier - temp_workplace.target_temperature) * ResourcesManager.cooling_efficiency);
                    if(power_consumption < 0 || !temp_workplace.enable_cooling){
                        power_consumption = 0;
                    }
                    int current_temperature = temp_workplace.enable_cooling?temp_workplace.target_temperature:game_controller.temperature-(temp_workplace.coolness + temp_workplace.coolness_modifier);
                    current_temperature = ResourcesManager.power>0?current_temperature:game_controller.temperature-(temp_workplace.coolness + temp_workplace.coolness_modifier);
                    game_controller.building_info.transform.Find("slot_3").Find("slot_3_text").GetComponent<Text>().text = "Target temperature: " + temp_workplace.target_temperature + "\nBase cooling: " + (temp_workplace.coolness + temp_workplace.coolness_modifier + game_controller.base_cooling) + "\nPower consumption: " + power_consumption + "\nCurrent temperature: " + current_temperature;
                }
                empty = false;
                break;
            }
        }
        if(empty){
            game_controller.building_menu.SetActive(true);
            game_controller.building_menu.transform.Find("type_selector").gameObject.SetActive(true);
            game_controller.building_menu.transform.Find("type_selector_people").gameObject.SetActive(false);
            game_controller.building_menu.transform.Find("slot_1").Find("slot_1_build").gameObject.SetActive(true);
            game_controller.building_menu.transform.Find("slot_1").Find("slot_1_people_buttons").gameObject.SetActive(false);
            game_controller.building_menu.transform.Find("slot_2").Find("slot_2_build").gameObject.SetActive(true);
            game_controller.building_menu.transform.Find("slot_2").Find("slot_2_people_buttons").gameObject.SetActive(false);
            game_controller.building_menu.transform.Find("slot_3").Find("slot_3_build").gameObject.SetActive(true);
            game_controller.building_menu.transform.Find("slot_3").Find("slot_3_people_buttons").gameObject.SetActive(false);
            game_controller.ChangeBuildingIntent(true);
            game_controller.ChangeBuildingsDisplayed(0);
            game_controller.building_menu.transform.Find("type_selector").gameObject.GetComponent<TMP_Dropdown>().value = 0;
        }
    }
}