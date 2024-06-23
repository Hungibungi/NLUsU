using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public static class Buildings
{
        public static Building[] buildings = new Building[1];
        public static PolicyBuilding.Pub pub = new PolicyBuilding.Pub();
        public static PolicyBuilding.HouseOfPleasure house_of_pleasure = new PolicyBuilding.HouseOfPleasure();
        public static Housing.Tent tent = new Housing.Tent();
        public static Housing.House house = new Housing.House();
        public static Housing.Apartment apartment = new Housing.Apartment();
        public static Workplace.Medical.MedicalTent medical_tent = new Workplace.Medical.MedicalTent();
        public static Workplace.Medical.Hospital hospital = new Workplace.Medical.Hospital();
        public static Workplace.Resource.IronMine iron_mine = new Workplace.Resource.IronMine();
        public static Workplace.Resource.SolarPanel solar_panel = new Workplace.Resource.SolarPanel();
        public static Workplace.Resource.CoalMine coal_mine = new Workplace.Resource.CoalMine();
        public static Workplace.Resource.FishermansHut fishermans_hut = new Workplace.Resource.FishermansHut();
        public static Workplace.Resource.AppleOrchard apple_orchard = new Workplace.Resource.AppleOrchard();
        public static Workplace.Resource.ChildCookery child_cookery = new Workplace.Resource.ChildCookery();
        public static Workplace.ScienceLab science_lab = new Workplace.ScienceLab();
        public static Workplace.ScoutStation scout_station = new Workplace.ScoutStation();
        public static Building.Warehouse warehouse = new Building.Warehouse();

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
            }
            if(building is PolicyBuilding.HouseOfPleasure temp_house_of_pleasure){
                temp_house_of_pleasure.happyness_bonus = house_of_pleasure.happyness_bonus;
            }
            if(building is Housing.Tent temp_tent){
                temp_tent.coolness = tent.coolness;
                temp_tent.coolness_modifier = tent.coolness_modifier;
                temp_tent.max_residents = tent.max_residents;
                temp_tent.happyness_modifier = tent.happyness_modifier;
            }
            if(building is Housing.House temp_house){
                temp_house.coolness = house.coolness;
                temp_house.coolness_modifier = house.coolness_modifier;
                temp_house.max_residents = house.max_residents;
                temp_house.happyness_modifier = house.happyness_modifier;
            }
            if(building is Housing.Apartment temp_apartment){
                temp_apartment.coolness = apartment.coolness;
                temp_apartment.coolness_modifier = apartment.coolness_modifier;
                temp_apartment.max_residents = apartment.max_residents;
                temp_apartment.happyness_modifier = apartment.happyness_modifier;
            }
            if(building is Workplace.ScoutStation temp_scout_station){
                temp_scout_station.movement_speed = scout_station.movement_speed;
                temp_scout_station.carrying_capacity = scout_station.carrying_capacity;
            }
            if(building is Workplace.ScienceLab temp_science_lab){
                temp_science_lab.coolness = science_lab.coolness;
                temp_science_lab.coolness_modifier = science_lab.coolness_modifier;
                temp_science_lab.workers_efficiency = science_lab.workers_efficiency;
                temp_science_lab.children_efficiency = science_lab.children_efficiency;
                temp_science_lab.sick_efficiency = science_lab.sick_efficiency;
            }
            if(building is Workplace.Medical.MedicalTent temp_medical_tent){
                temp_medical_tent.max_workers = medical_tent.max_workers;
                temp_medical_tent.coolness = medical_tent.coolness;
                temp_medical_tent.coolness_modifier = medical_tent.coolness_modifier;
                temp_medical_tent.workers_efficiency = medical_tent.workers_efficiency;
                temp_medical_tent.children_efficiency = medical_tent.children_efficiency;
                temp_medical_tent.sick_efficiency = medical_tent.sick_efficiency;
                temp_medical_tent.max_sick = medical_tent.max_sick;
                temp_medical_tent.treatment_speed = medical_tent.treatment_speed;
            }
            if(building is Workplace.Medical.Hospital temp_hospital){
                temp_hospital.max_workers = hospital.max_workers;
                temp_hospital.coolness = hospital.coolness;
                temp_hospital.coolness_modifier = hospital.coolness_modifier;
                temp_hospital.workers_efficiency = hospital.workers_efficiency;
                temp_hospital.children_efficiency = hospital.children_efficiency;
                temp_hospital.sick_efficiency = hospital.sick_efficiency;
                temp_hospital.max_sick = hospital.max_sick;
                temp_hospital.treatment_speed = hospital.treatment_speed;
            }
            if(building is Workplace.Resource.SolarPanel temp_solar_panel){
                temp_solar_panel.power_production = solar_panel.power_production;
                temp_solar_panel.power_efficiency = solar_panel.power_efficiency;
            }
            if(building is Workplace.Resource.CoalMine temp_coal_mine){
                temp_coal_mine.max_workers = coal_mine.max_workers;
                temp_coal_mine.coolness = coal_mine.coolness;
                temp_coal_mine.coolness_modifier = coal_mine.coolness_modifier;
                temp_coal_mine.building_material_production = coal_mine.building_material_production;
                temp_coal_mine.building_material_efficiency = coal_mine.building_material_efficiency;
                temp_coal_mine.power_production = coal_mine.power_production;
                temp_coal_mine.power_efficiency = coal_mine.power_efficiency;
                temp_coal_mine.workers_efficiency = coal_mine.workers_efficiency;
                temp_coal_mine.children_efficiency = coal_mine.children_efficiency;
                temp_coal_mine.sick_efficiency = coal_mine.sick_efficiency;
            }
            if(building is Workplace.Resource.IronMine temp_iron_mine){
                temp_iron_mine.max_workers = iron_mine.max_workers;
                temp_iron_mine.coolness = iron_mine.coolness;
                temp_iron_mine.coolness_modifier = iron_mine.coolness_modifier;
                temp_iron_mine.building_material_production = iron_mine.building_material_production;
                temp_iron_mine.building_material_efficiency = iron_mine.building_material_efficiency;
                temp_iron_mine.iron_production = iron_mine.iron_production;
                temp_iron_mine.iron_efficiency = iron_mine.iron_efficiency;
                temp_iron_mine.workers_efficiency = iron_mine.workers_efficiency;
                temp_iron_mine.children_efficiency = iron_mine.children_efficiency;
                temp_iron_mine.sick_efficiency = iron_mine.sick_efficiency;
            }
            if(building is Workplace.Resource.AppleOrchard temp_apple_orchard){
                temp_apple_orchard.max_workers = apple_orchard.max_workers;
                temp_apple_orchard.coolness = apple_orchard.coolness;
                temp_apple_orchard.coolness_modifier = apple_orchard.coolness_modifier;
                temp_apple_orchard.building_material_production = apple_orchard.building_material_production;
                temp_apple_orchard.building_material_efficiency = apple_orchard.building_material_efficiency;
                temp_apple_orchard.food_production = apple_orchard.food_production;
                temp_apple_orchard.food_efficiency = apple_orchard.food_efficiency;
                temp_apple_orchard.workers_efficiency = apple_orchard.workers_efficiency;
                temp_apple_orchard.children_efficiency = apple_orchard.children_efficiency;
                temp_apple_orchard.sick_efficiency = apple_orchard.sick_efficiency;
            }
            if(building is Workplace.Resource.FishermansHut temp_fishermans_hut){
                temp_fishermans_hut.max_workers = fishermans_hut.max_workers;
                temp_fishermans_hut.coolness = fishermans_hut.coolness;
                temp_fishermans_hut.coolness_modifier = fishermans_hut.coolness_modifier;
                temp_fishermans_hut.food_production = fishermans_hut.food_production;
                temp_fishermans_hut.food_efficiency = fishermans_hut.food_efficiency;
                temp_fishermans_hut.workers_efficiency = fishermans_hut.workers_efficiency;
                temp_fishermans_hut.children_efficiency = fishermans_hut.children_efficiency;
                temp_fishermans_hut.sick_efficiency = fishermans_hut.sick_efficiency;
            }
            if(building is Workplace.Resource.ChildCookery temp_child_cookery){
                temp_child_cookery.max_workers = child_cookery.max_workers;
                temp_child_cookery.coolness = child_cookery.coolness;
                temp_child_cookery.coolness_modifier = child_cookery.coolness_modifier;
                temp_child_cookery.food_multiplier = child_cookery.food_multiplier;
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
        game_controller._building_slot_2_button.interactable = false;
        game_controller._building_slot_2_add_worker.interactable = false;
        game_controller._building_slot_2_add_child.interactable = false;
        game_controller._building_slot_2_remove_worker.interactable = false;
        game_controller._building_slot_2_remove_child.interactable = false;
        game_controller._building_slot_3_button.interactable = false;
        game_controller._building_slot_3_add_worker.interactable = false;
        game_controller._building_slot_3_add_child.interactable = false;
        game_controller._building_slot_3_remove_worker.interactable = false;
        game_controller._building_slot_3_remove_child.interactable = false;
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
                            + "Current children: " + worker_info.Item3[0] + "\n"
                            + "Current sick: " + worker_info.Item4[0];
                        if(worker_info.Item1[0] - worker_info.Item2[0] - worker_info.Item3[0] > 0 && Residents.IsWorkerAvailable()){
                            game_controller._building_slot_1_add_worker.interactable = true;
                            if(medical_tent.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[0] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[0] != 0){
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
                            + "Current children: " + worker_info.Item3[1] + "\n"
                            + "Current sick: " + worker_info.Item4[1];
                        if(worker_info.Item1[1] - worker_info.Item2[1] - worker_info.Item3[1] > 0 && Residents.IsWorkerAvailable()){
                            game_controller._building_slot_1_add_worker.interactable = true;
                            if(hospital.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[1] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[1] != 0){
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
                            + "Current children: " + worker_info.Item3[2] + "\n"
                            + "Current sick: " + worker_info.Item4[2];
                        if(worker_info.Item1[2] - worker_info.Item2[2] - worker_info.Item3[2] > 0 && Residents.IsWorkerAvailable()){
                            game_controller._building_slot_1_add_worker.interactable = true;
                            if(science_lab.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[2] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[2] != 0){
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
                            + "Current children: " + worker_info.Item3[3] + "\n"
                            + "Current sick: " + worker_info.Item4[3];
                        if(worker_info.Item1[3] - worker_info.Item2[3] - worker_info.Item3[3] > 0 && Residents.IsWorkerAvailable()){
                            game_controller._building_slot_1_add_worker.interactable = true;
                            if(fishermans_hut.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[3] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[3] != 0){
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
                            + "Current children: " + worker_info.Item3[4] + "\n"
                            + "Current sick: " + worker_info.Item4[4];
                        if(worker_info.Item1[4] - worker_info.Item2[4] - worker_info.Item3[4] > 0 && Residents.IsWorkerAvailable()){
                            game_controller._building_slot_2_add_worker.interactable = true;
                            if(apple_orchard.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_2_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[4] != 0){
                            game_controller._building_slot_2_remove_worker.interactable = true;
                        }if(worker_info.Item3[4] != 0){
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
                            + "Current children: " + worker_info.Item3[5] + "\n"
                            + "Current sick: " + worker_info.Item4[5];
                        if(worker_info.Item1[5] - worker_info.Item2[5] - worker_info.Item3[5] > 0 && Residents.IsChildrenAvailable()){
                            game_controller._building_slot_3_add_child.interactable = true;
                        }
                        if(worker_info.Item3[5] != 0){
                            game_controller._building_slot_3_remove_child.interactable = true;
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
                            + "Current children: " + worker_info.Item3[6] + "\n"
                            + "Current sick: " + worker_info.Item4[6];
                        if(worker_info.Item1[6] - worker_info.Item2[6] - worker_info.Item3[6] > 0 && Residents.IsWorkerAvailable()){
                            game_controller._building_slot_2_add_worker.interactable = true;
                            if(coal_mine.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_2_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[6] != 0){
                            game_controller._building_slot_2_remove_worker.interactable = true;
                        }if(worker_info.Item3[6] != 0){
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
                            + "Max workers: " + coal_mine.max_workers + "\n"
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
                            + "Current children: " + worker_info.Item3[7] + "\n"
                            + "Current sick: " + worker_info.Item4[7];
                        if(worker_info.Item1[7] - worker_info.Item2[7] - worker_info.Item3[7] > 0 && Residents.IsWorkerAvailable()){
                            game_controller._building_slot_1_add_worker.interactable = true;
                            if(iron_mine.child_work && Residents.IsChildrenAvailable()){
                                game_controller._building_slot_1_add_child.interactable = true;
                            }
                        }
                        if(worker_info.Item2[7] != 0){
                            game_controller._building_slot_1_remove_worker.interactable = true;
                        }if(worker_info.Item3[7] != 0){
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
                        buildings[buildings.Length - 1] = new Housing.Tent();
                        ResourcesManager.PayResources(0,0,tent.building_material_cost, tent.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Housing.House();
                        ResourcesManager.PayResources(0,0,house.building_material_cost, house.iron_cost);
                        break;
                    case 2:
                        buildings[buildings.Length - 1] = new Housing.Apartment();
                        ResourcesManager.PayResources(0,0,apartment.building_material_cost, apartment.iron_cost);
                        break;
                }
                break;
            case 1:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.Medical.MedicalTent();
                        ResourcesManager.PayResources(0,0,medical_tent.building_material_cost, medical_tent.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Workplace.Medical.Hospital();
                        ResourcesManager.PayResources(0,0,hospital.building_material_cost, hospital.iron_cost);
                        break;
                }
                break;
            case 2:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.ScienceLab();
                        ResourcesManager.PayResources(0,0,science_lab.building_material_cost, science_lab.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Workplace.ScoutStation();
                        ResourcesManager.PayResources(0,0,scout_station.building_material_cost, scout_station.iron_cost);
                        break;
                }
                break;
            case 3:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.Resource.FishermansHut();
                        ResourcesManager.PayResources(0,0,fishermans_hut.building_material_cost, fishermans_hut.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Workplace.Resource.AppleOrchard();
                        ResourcesManager.PayResources(0,0,apple_orchard.building_material_cost, apple_orchard.iron_cost);
                        break;
                    case 2:
                        buildings[buildings.Length - 1] = new Workplace.Resource.ChildCookery();
                        ResourcesManager.PayResources(0,0,child_cookery.building_material_cost, child_cookery.iron_cost);
                        break;
                }
                break;
            case 4:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.Resource.SolarPanel();
                        ResourcesManager.PayResources(0,0,solar_panel.building_material_cost, solar_panel.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Workplace.Resource.CoalMine();
                        ResourcesManager.PayResources(0,0,coal_mine.building_material_cost, coal_mine.iron_cost);
                        break;
                }
                break;
            case 5:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new Workplace.Resource.IronMine();
                        ResourcesManager.PayResources(0,0,iron_mine.building_material_cost, iron_mine.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new Building.Warehouse();
                        ResourcesManager.PayResources(0,0,warehouse.building_material_cost, warehouse.iron_cost);
                        break;
                }
                break;
            case 6:
                switch(slot_id){
                    case 0:
                        buildings[buildings.Length - 1] = new PolicyBuilding.Pub();
                        ResourcesManager.PayResources(0,0,pub.building_material_cost, pub.iron_cost);
                        break;
                    case 1:
                        buildings[buildings.Length - 1] = new PolicyBuilding.HouseOfPleasure();
                        ResourcesManager.PayResources(0,0,house_of_pleasure.building_material_cost, house_of_pleasure.iron_cost);
                        break;
                }
                break;
        }
        UpdateBuildings();
        ResourcesManager.RefreshResourcesWidget(game_controller);
        game_controller.AdjustResidents();
    }

    public static System.Tuple<int[], int[], int[], int[]> GetWorkerInfoByWorkplace(){
        int[] max_workers = new int[8];
        int[] current_workers = new int[8];
        int[] current_children = new int[8];
        int[] current_sick = new int[8];
        foreach(Building building in buildings){
            if(building is Workplace.Medical.MedicalTent medical_tent){
                max_workers[0] += medical_tent.max_workers;
                current_workers[0] += medical_tent.current_workers;
                current_children[0] += medical_tent.children_workers;
                current_sick[0] += medical_tent.sick_workers;
            }
            if(building is Workplace.Medical.Hospital hospital){
                max_workers[1] += hospital.max_workers;
                current_workers[1] += hospital.current_workers;
                current_children[1] += hospital.children_workers;
                current_sick[1] += hospital.sick_workers;
            }
            if(building is Workplace.ScienceLab science_lab){
                max_workers[2] += science_lab.max_workers;
                current_workers[2] += science_lab.current_workers;
                current_children[2] += science_lab.children_workers;
                current_sick[2] += science_lab.sick_workers;
            }
            if(building is Workplace.Resource.FishermansHut fishermans_hut){
                max_workers[3] += fishermans_hut.max_workers;
                current_workers[3] += fishermans_hut.current_workers;
                current_children[3] += fishermans_hut.children_workers;
                current_sick[3] += fishermans_hut.sick_workers;
            }
            if(building is Workplace.Resource.AppleOrchard apple_orchard){
                max_workers[4] += apple_orchard.max_workers;
                current_workers[4] += apple_orchard.current_workers;
                current_children[4] += apple_orchard.children_workers;
                current_sick[4] += apple_orchard.sick_workers;
            }
            if(building is Workplace.Resource.ChildCookery child_cookery){
                max_workers[5] += child_cookery.max_workers;
                current_workers[5] += child_cookery.current_workers;
                current_children[5] += child_cookery.children_workers;
                current_sick[5] += child_cookery.sick_workers;
            }
            if(building is Workplace.Resource.CoalMine coal_mine){
                max_workers[6] += coal_mine.max_workers;
                current_workers[6] += coal_mine.current_workers;
                current_children[6] += coal_mine.children_workers;
                current_sick[6] += coal_mine.sick_workers;
            }
            if(building is Workplace.Resource.IronMine iron_mine){
                max_workers[7] += iron_mine.max_workers;
                current_workers[7] += iron_mine.current_workers;
                current_children[7] += iron_mine.children_workers;
                current_sick[7] += iron_mine.sick_workers;
            }
        }
        return new System.Tuple<int[], int[], int[], int[]>(max_workers, current_workers, current_children, current_sick);
    }
}