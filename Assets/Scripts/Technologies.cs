using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Technology
{
    public int building_material_cost;
    public int iron_cost;
    public int research_time;
    public int id;
    public int prerequisite;
    public string description;

    public Technology(int building_material_cost, int iron_cost, int research_time, int id, int prerequisite, string description){
        this.building_material_cost=building_material_cost;
        this.iron_cost=iron_cost;
        this.research_time=research_time;
        this.id=id;
        this.prerequisite=prerequisite;
        this.description=description;
    }
}

public static class Technologies
{
    public static Technology[] technologies = GetTechnologies();
    public static bool[] active_technologies = new bool[62];
    public static int[] current_tier = new int[7];
    public static int currently_researching = -1;

    public static void ResetTechnologies(){
        active_technologies = new bool[62];
        current_tier = new int[7];
        currently_researching = 8;
    }

    private static Technology[] GetTechnologies(){
        Technology[] tempArray = new Technology[62];
        // Cooling
        tempArray[0] = new Technology(10,0,40,0,-1,"Enables cooling for buildings.");
        tempArray[1] = new Technology(30,10,80,1,0,"Increases the overall city coolness.");
        tempArray[2] = new Technology(30,10,80,2,0,"Decreases the power usage of the cooling system.");
        tempArray[3] = new Technology(100,50,160,3,1,"Increases the overall city coolness.");
        tempArray[4] = new Technology(100,50,160,4,2,"Decreases the power usage of the cooling system.");
        tempArray[5] = new Technology(200,150,320,5,3,"Increases the overall city coolness.");
        tempArray[6] = new Technology(200,150,320,6,4,"Decreases the power usage of the cooling system.");
        tempArray[7] = new Technology(200,150,320,7,0,"Enables manual temperature target for buildings.");

        // Housing
        tempArray[8] = new Technology(10,0,40,8,-1,"Enables the building of tent buildings.");
        tempArray[9] = new Technology(30,10,80,9,8,"Increases the coolness of tents.");
        tempArray[10] = new Technology(30,10,80,10,8,"Decreases the build cost of tents.");
        tempArray[11] = new Technology(100,50,160,11,8,"Enables the building of family houses and upgrades your tents into them.");
        tempArray[12] = new Technology(100,50,160,12,8,"Enables the building of apartment buildings.");
        tempArray[13] = new Technology(100,50,160,13,9,"Increases the coolness of housing buildings.");
        tempArray[14] = new Technology(200,150,320,14,13,"Increases the resident limit of housing buildings.");
        tempArray[15] = new Technology(200,150,320,15,13,"Increases the coolness of housing buildings.");
        tempArray[16] = new Technology(200,150,320,16,11,"Decreases the build cost of family houses.");
        tempArray[17] = new Technology(200,150,320,17,12,"Decreases the build cost of apartment buildings.");

        // Health
        tempArray[18] = new Technology(10,0,40,18,-1,"Enables the building of medical tent buildings.");
        tempArray[19] = new Technology(30,10,80,19,18,"Increases the medical treatment's speed.");
        tempArray[20] = new Technology(30,10,80,20,18,"Decreases the required amount of workers in medical tents.");
        tempArray[21] = new Technology(100,50,160,21,18,"Enables the building of hospitals.");
        tempArray[22] = new Technology(100,50,160,22,19,"Increases the medical treatment's speed.");
        tempArray[23] = new Technology(200,150,320,23,21,"Decreases the required amount of workers in hospitals.");
        tempArray[24] = new Technology(200,150,320,24,22,"Increases the medical treatment's speed.");

        // Food
        tempArray[25] = new Technology(10,0,40,25,-1,"Enables the building of fisherman's hut buildings.");
        tempArray[26] = new Technology(30,10,80,26,25,"Decreases the required amount of workers in fisherman's huts.");
        tempArray[27] = new Technology(30,10,80,27,25,"Increases the food collecting efficiency of fisherman's huts.");
        tempArray[28] = new Technology(30,10,80,28,25,"Enables the building of apple orchard buildings.");
        tempArray[29] = new Technology(100,50,160,29,28,"Increases the food collecting efficiency of apple orchards.");
        tempArray[30] = new Technology(100,50,160,30,28,"Decreases the build cost of apple orchards.");
        tempArray[31] = new Technology(100,50,160,31,27,"Increases the food collecting efficiency of fisherman's huts.");
        tempArray[32] = new Technology(200,150,320,32,25,"Increases the food collecting efficiency of food buildings.");
        tempArray[33] = new Technology(200,150,320,33,31,"Increases the base food collecting speed of fisherman's huts.");

        // Resources
        tempArray[34] = new Technology(10,0,40,34,-1,"Enables the building of iron mine buildings.");
        tempArray[35] = new Technology(30,10,80,35,34,"Enables the building of warehouse buildings.");
        tempArray[36] = new Technology(30,10,80,36,34,"Increases the iron collecting efficiency of iron mines.");
        tempArray[37] = new Technology(30,10,80,37,34,"Increases the building material collecting efficiency of resource buildings.");
        tempArray[38] = new Technology(100,50,160,38,36,"Increases the iron collecting efficiency of iron mines.");
        tempArray[39] = new Technology(100,50,160,39,37,"Increases the building material collecting efficiency of resource buildings.");
        tempArray[40] = new Technology(100,50,160,40,35,"Increases the resource capacity of warehouses.");
        tempArray[41] = new Technology(100,50,160,41,35,"Decreases the build cost of warehouses.");
        tempArray[42] = new Technology(200,150,320,42,39,"Increases the building material collecting efficiency of resource buildings.");
        tempArray[43] = new Technology(200,150,320,43,38,"Increases the base iron collecting speed of iron mines.");

        // Power
        tempArray[44] = new Technology(10,0,40,44,-1,"Enables the building of solar panel buildings.");
        tempArray[45] = new Technology(30,10,80,45,44,"Increases the power collecting efficiency of solar panels.");
        tempArray[46] = new Technology(30,10,80,46,44,"Enables the building of coal mine buildings.");
        tempArray[47] = new Technology(100,50,160,47,46,"Increases the power collecting efficiency of coal mines.");
        tempArray[48] = new Technology(100,50,160,48,46,"Decreases the build cost of coal mines.");
        tempArray[49] = new Technology(100,50,160,49,45,"Increases the power collecting efficiency of solar panels.");
        tempArray[50] = new Technology(200,150,320,50,44,"Increases the power collecting efficiency of power buildings.");
        tempArray[51] = new Technology(200,150,320,51,49,"Increases the base power collecting speed of solar panels.");

        // Exploration
        tempArray[52] = new Technology(10,0,40,52,-1,"Enables the building of scout station buildings.");
        tempArray[53] = new Technology(30,10,80,53,52,"Increases the movement speed of scouts.");
        tempArray[54] = new Technology(30,10,80,54,52,"Increases the carrying capacity of scouts.");
        tempArray[59] = new Technology(30,10,80,59,52,"Unlocks the scouting for the East.");
        tempArray[55] = new Technology(100,50,160,55,53,"Increases the movement speed of scouts.");
        tempArray[56] = new Technology(100,50,160,56,54,"Increases the carrying capacity of scouts.");
        tempArray[60] = new Technology(100,50,160,60,59,"Unlocks the scouting for the South.");
        tempArray[57] = new Technology(200,150,320,57,55,"Increases the movement speed of scouts.");
        tempArray[58] = new Technology(200,150,320,58,56,"Increases the carrying capacity of scouts.");
        tempArray[61] = new Technology(200,150,320,61,60,"Unlocks the scouting for the West.");
        return tempArray;
    }

    public static void ActivateTechnology(int id, GameController game_controller){
        active_technologies[id] = true;
        switch(id){
            // Cooling
            case 0:
                // Enables cooling for buildings.
                Buildings.pub.enable_cooling = true;
                Buildings.house_of_pleasure.enable_cooling = true;
                Buildings.tent.enable_cooling = true;
                Buildings.house.enable_cooling = true;
                Buildings.apartment.enable_cooling = true;
                Buildings.medical_tent.enable_cooling = true;
                Buildings.hospital.enable_cooling = true;
                Buildings.iron_mine.enable_cooling = true;
                Buildings.coal_mine.enable_cooling = true;
                Buildings.fishermans_hut.enable_cooling = true;
                Buildings.apple_orchard.enable_cooling = true;
                Buildings.child_cookery.enable_cooling = true;
                Buildings.science_lab.enable_cooling = true;
                current_tier[0] = 1;
                break;
            case 1:
                // Increases the overall city coolness.
                game_controller.base_cooling += 5;
                current_tier[0] = 2;
                break;
            case 3:
                // Increases the overall city coolness.
                game_controller.base_cooling += 5;
                current_tier[0] = 3;
                break;
            case 5:
                // Increases the overall city coolness.
                game_controller.base_cooling += 5;
                current_tier[0] = 4;
                break;
            case 2:
                // Decreases the power usage of the cooling system.
                ResourcesManager.cooling_efficiency -= 0.1F;
                current_tier[0] = 2;
                break;
            case 4:
                // Decreases the power usage of the cooling system.
                ResourcesManager.cooling_efficiency -= 0.1F;
                current_tier[0] = 3;
                break;
            case 6:
                // Decreases the power usage of the cooling system.
                ResourcesManager.cooling_efficiency -= 0.1F;
                current_tier[0] = 4;
                break;
            case 7:
                // Enables manual temperature target for buildings.
                Buildings.pub.manual_cooling = true;
                Buildings.house_of_pleasure.manual_cooling = true;
                Buildings.tent.manual_cooling = true;
                Buildings.house.manual_cooling = true;
                Buildings.apartment.manual_cooling = true;
                Buildings.medical_tent.manual_cooling = true;
                Buildings.hospital.manual_cooling = true;
                Buildings.iron_mine.manual_cooling = true;
                Buildings.solar_panel.manual_cooling = true;
                Buildings.coal_mine.manual_cooling = true;
                Buildings.fishermans_hut.manual_cooling = true;
                Buildings.apple_orchard.manual_cooling = true;
                Buildings.child_cookery.manual_cooling = true;
                Buildings.science_lab.manual_cooling = true;
                current_tier[0] = 4;
                break;
            
            // Housing
            case 8:
                // Enables the building of tent buildings.
                Buildings.tent.active = true;
                current_tier[1] = 1;
                break;
            case 9:
                // Increases the coolness of tents.
                Buildings.tent.coolness_modifier += 10;
                current_tier[1] = 2;
                break;
            case 10:
                // Decreases the build cost of tents.
                Buildings.tent.building_material_cost -= 10;
                current_tier[1] = 2;
                break;
            case 11:
                // Enables the building of family houses and upgrades your tents into them.
                Buildings.tent.active = false;
                Buildings.house.active = true;
                int[] tiles = new int[0];
                int[] indexes = new int[0];
                for(int i=0;i<Buildings.buildings.Length;i++){
                    if(Buildings.buildings[i].name == "Tent"){
                        System.Array.Resize(ref tiles, tiles.Length + 1);
                        tiles[tiles.Length - 1] = Buildings.buildings[i].tile;
                        System.Array.Resize(ref indexes, indexes.Length + 1);
                        indexes[indexes.Length - 1] = i;
                    }
                }
                for(int i=0;i<tiles.Length;i++){
                    Buildings.buildings[indexes[i]] = new Housing.House(tiles[i]);
                }
                current_tier[1] = 3;
                break;
            case 12:
                // Enables the building of apartment buildings.
                Buildings.apartment.active = true;
                current_tier[1] = 3;
                break;
            case 13:
                // Increases the coolness of housing buildings.
                Buildings.tent.coolness_modifier += 10;
                Buildings.house.coolness_modifier += 10;
                Buildings.apartment.coolness_modifier += 10;
                current_tier[1] = 3;
                break;
            case 15:
                // Increases the coolness of housing buildings.
                Buildings.tent.coolness_modifier += 10;
                Buildings.house.coolness_modifier += 10;
                Buildings.apartment.coolness_modifier += 10;
                current_tier[1] = 4;
                break;
            case 14:
                // Increases the resident limit of housing buildings.
                Buildings.tent.max_residents += 5;
                Buildings.house.max_residents += 5;
                Buildings.apartment.max_residents += 10;
                current_tier[1] = 4;
                break;
            case 16:
                // Decreases the build cost of family houses.
                Buildings.house.building_material_cost -= 10;
                Buildings.house.iron_cost -= 5;
                current_tier[1] = 4;
                break;
            case 17:
                // Decreases the build cost of apartment buildings.
                Buildings.apartment.building_material_cost -= 20;
                Buildings.apartment.iron_cost -= 10;
                current_tier[1] = 4;
                break;
            
            // Health
            case 18:
                // Enables the building of medical tent buildings.
                Buildings.medical_tent.active = true;
                current_tier[2] = 1;
                break;
            case 19:
                // Increases the medical treatment's speed.
                Buildings.medical_tent.treatment_speed += 0.25F;
                Buildings.hospital.treatment_speed += 0.25F;
                current_tier[2] = 2;
                break;
            case 22:
                // Increases the medical treatment's speed.
                Buildings.medical_tent.treatment_speed += 0.25F;
                Buildings.hospital.treatment_speed += 0.25F;
                current_tier[2] = 3;
                break;
            case 24:
                // Increases the medical treatment's speed.
                Buildings.medical_tent.treatment_speed += 0.25F;
                Buildings.hospital.treatment_speed += 0.25F;
                current_tier[2] = 4;
                break;
            case 20:
                // Decreases the required amount of workers in medical tents.
                Buildings.medical_tent.max_workers -= 5;
                Buildings.UpdateBuildings();
                foreach(Building building in Buildings.buildings){
                    if(building is Workplace.Medical.MedicalTent medical_tent){
                        while(medical_tent.current_workers + medical_tent.children_workers + medical_tent.sick_workers + medical_tent.sick_child_workers > medical_tent.max_workers){
                            if(medical_tent.current_workers + medical_tent.sick_workers > 0){
                                Residents.DeAssignWorker(medical_tent);
                            } else{
                                Residents.DeAssignChildren(medical_tent);
                            }
                        }
                    }
                }
                current_tier[2] = 2;
                break;
            case 21:
                // Enables the building of hospitals.
                Buildings.hospital.active = true;
                current_tier[2] = 3;
                break;
            case 23:
                // Decreases the required amount of workers in hospitals.
                Buildings.hospital.max_workers -= 5;
                Buildings.UpdateBuildings();
                foreach(Building building in Buildings.buildings){
                    if(building is Workplace.Medical.Hospital hospital){
                        while(hospital.current_workers + hospital.children_workers + hospital.sick_workers + hospital.sick_child_workers > hospital.max_workers){
                            if(hospital.current_workers + hospital.sick_workers > 0){
                                Residents.DeAssignWorker(hospital);
                            } else{
                                Residents.DeAssignChildren(hospital);
                            }
                        }
                    }
                }
                current_tier[2] = 4;
                break;
            
            // Food
            case 25:
                // Enables the building of fisherman's hut buildings.
                Buildings.fishermans_hut.active = true;
                current_tier[3] = 1;
                break;
            case 26:
                // Decreases the required amount of workers in fisherman's huts.
                Buildings.fishermans_hut.max_workers -= 10;
                Buildings.UpdateBuildings();
                foreach(Building building in Buildings.buildings){
                    if(building is Workplace.Resource.FishermansHut fishermans_hut){
                        while(fishermans_hut.current_workers + fishermans_hut.children_workers + fishermans_hut.sick_workers + fishermans_hut.sick_child_workers > fishermans_hut.max_workers){
                            if(fishermans_hut.current_workers + fishermans_hut.sick_workers > 0){
                                Residents.DeAssignWorker(fishermans_hut);
                            } else{
                                Residents.DeAssignChildren(fishermans_hut);
                            }
                        }
                    }
                }
                current_tier[3] = 2;
                break;
            case 27:
                // Increases the fisherman's hut's food collecting efficiency.
                Buildings.fishermans_hut.food_efficiency += 0.15F;
                current_tier[3] = 2;
                break;
            case 31:
                // Increases the fisherman's hut's food collecting efficiency.
                Buildings.fishermans_hut.food_efficiency += 0.15F;
                current_tier[3] = 3;
                break;
            case 28:
                // Enables the building of apple orchard buildings.
                Buildings.apple_orchard.active = true;
                current_tier[3] = 2;
                break;
            case 29:
                // Increases the food collecting efficiency of apple orchards.
                Buildings.apple_orchard.food_efficiency += 0.15F;
                current_tier[3] = 3;
                break;
            case 30:
                // Decreases the build cost of apple orchards.
                Buildings.apple_orchard.building_material_cost -= 10;
                Buildings.apple_orchard.iron_cost -= 10;
                current_tier[3] = 3;
                break;
            case 32:
                // Increases the food collecting efficiency of food buildings.
                Buildings.fishermans_hut.food_efficiency += 0.15F;
                Buildings.apple_orchard.food_efficiency += 0.15F;
                current_tier[3] = 4;
                break;
            case 33:
                // Increases the base food collecting speed of fisherman's huts.
                Buildings.fishermans_hut.food_production += 10;
                current_tier[3] = 4;
                break;

            // Resources
            case 34:
                // Enables the building of iron mine buildings.
                Buildings.iron_mine.active = true;
                current_tier[4] = 1;
                break;
            case 35:
                // Enables the building of warehouse buildings.
                Buildings.warehouse.active = true;
                current_tier[4] = 2;
                break;
            case 36:
                // Increases the iron collecting efficiency of iron mines.
                Buildings.iron_mine.iron_efficiency += 0.15F;
                current_tier[4] = 2;
                break;
            case 38:
                // Increases the iron collecting efficiency of iron mines.
                Buildings.iron_mine.iron_efficiency += 0.15F;
                current_tier[4] = 3;
                break;
            case 37:
                // Increases the building material collecting efficiency of resource buildings.
                Buildings.apple_orchard.building_material_efficiency += 0.15F;
                Buildings.iron_mine.building_material_efficiency += 0.15F;
                Buildings.coal_mine.building_material_efficiency += 0.15F;
                current_tier[4] = 2;
                break;
            case 39:
                // Increases the building material collecting efficiency of resource buildings.
                Buildings.apple_orchard.building_material_efficiency += 0.15F;
                Buildings.iron_mine.building_material_efficiency += 0.15F;
                Buildings.coal_mine.building_material_efficiency += 0.15F;
                current_tier[4] = 3;
                break;
            case 42:
                // Increases the building material collecting efficiency of resource buildings.
                Buildings.apple_orchard.building_material_efficiency += 0.15F;
                Buildings.iron_mine.building_material_efficiency += 0.15F;
                Buildings.coal_mine.building_material_efficiency += 0.15F;
                current_tier[4] = 4;
                break;
            case 40:
                // Increases the resource capacity of warehouses.
                Buildings.warehouse.food_storage += 250;
                Buildings.warehouse.power_storage += 1000;
                Buildings.warehouse.building_material_storage += 500;
                Buildings.warehouse.iron_storage += 250;
                current_tier[4] = 3;
                break;
            case 41:
                // Decreases the build cost of warehouses.
                Buildings.warehouse.building_material_cost -= 20;
                current_tier[4] = 3;
                break;
            case 43:
                // Increases the base iron collecting speed of iron mines.
                Buildings.iron_mine.iron_production += 10;
                current_tier[4] = 4;
                break;

            // Power
            case 44:
                // Enables the building of solar panel buildings.
                Buildings.solar_panel.active = true;
                current_tier[5] = 1;
                break;
            case 45:
                // Increases the power collecting efficiency of solar panels.
                Buildings.solar_panel.power_efficiency += 0.15F;
                current_tier[5] = 2;
                break;
            case 49:
                // Increases the power collecting efficiency of solar panels.
                Buildings.solar_panel.power_efficiency += 0.15F;
                current_tier[5] = 3;
                break;
            case 46:
                // Enables the building of coal mine buildings.
                Buildings.coal_mine.active = true;
                current_tier[5] = 2;
                break;
            case 47:
                // Increases the power collecting efficiency of coal mines.
                Buildings.coal_mine.power_efficiency += 0.15F;
                current_tier[5] = 3;
                break;
            case 48:
                // Decreases the build cost of coal mines.
                Buildings.coal_mine.building_material_cost -= 10;
                Buildings.coal_mine.iron_cost -= 10;
                current_tier[5] = 3;
                break;
            case 50:
                // Increases the power collecting efficiency of power buildings.
                Buildings.solar_panel.power_efficiency += 0.15F;
                Buildings.coal_mine.power_efficiency += 0.15F;
                current_tier[5] = 4;
                break;
            case 51:
                // Increases the base power collecting speed of solar panels.
                Buildings.solar_panel.power_efficiency += 10;
                current_tier[5] = 4;
                break;

            // Exploration
            case 52:
                // Enables the building of scout station buildings.
                Buildings.scout_station.active = true;
                current_tier[6] = 1;
                break;
            case 53:
                // Increases the movement speed of scouts.
                Buildings.scout_station.movement_speed += 0.5F;
                current_tier[6] = 2;
                break;
            case 55:
                // Increases the movement speed of scouts.
                Buildings.scout_station.movement_speed += 0.5F;
                current_tier[6] = 3;
                break;
            case 57:
                // Increases the movement speed of scouts.
                Buildings.scout_station.movement_speed += 0.5F;
                current_tier[6] = 4;
                break;
            case 54:
                // Increases the carrying capacity of scouts.
                Buildings.scout_station.carrying_capacity += 500;
                current_tier[6] = 2;
                break;
            case 56:
                // Increases the carrying capacity of scouts.
                Buildings.scout_station.carrying_capacity += 500;
                current_tier[6] = 3;
                break;
            case 58:
                // Increases the carrying capacity of scouts.
                Buildings.scout_station.carrying_capacity += 500;
                current_tier[6] = 4;
                break;
            case 59:
                // Unlocks the scouting for the East.
                Scouting.direction[1] = true;
                Scouting.storm_direction[1] = true;
                current_tier[6] = 2;
                break;
            case 60:
                // Unlocks the scouting for the South.
                Scouting.direction[2] = true;
                Scouting.storm_direction[2] = true;
                current_tier[6] = 3;
                break;
            case 61:
                // Unlocks the scouting for the West.
                Scouting.direction[3] = true;
                Scouting.storm_direction[3] = true;
                current_tier[6] = 4;
                break;
        }
        Buildings.UpdateBuildings();
    }

    private static void DeactivateTechnologyIcons(GameController game_controller){
        game_controller._technology_2_1.SetActive(false);
        game_controller._technology_2_2.SetActive(false);
        game_controller._technology_2_3.SetActive(false);
        game_controller._technology_2_4.SetActive(false);
        game_controller._technology_2_5.SetActive(false);
        game_controller._technology_next_3_1.SetActive(false);
        game_controller._technology_3_1.SetActive(false);
        game_controller._technology_next_3_2.SetActive(false);
        game_controller._technology_3_2.SetActive(false);
        game_controller._technology_next_3_3.SetActive(false);
        game_controller._technology_3_3.SetActive(false);
        game_controller._technology_next_3_4.SetActive(false);
        game_controller._technology_3_4.SetActive(false);
        game_controller._technology_next_3_5.SetActive(false);
        game_controller._technology_3_5.SetActive(false);
        game_controller._technology_next_4_1.SetActive(false);
        game_controller._technology_4_1.SetActive(false);
        game_controller._technology_next_4_2.SetActive(false);
        game_controller._technology_4_2.SetActive(false);
        game_controller._technology_next_4_3.SetActive(false);
        game_controller._technology_4_3.SetActive(false);
        game_controller._technology_next_4_4.SetActive(false);
        game_controller._technology_4_4.SetActive(false);
        game_controller._technology_next_4_5.SetActive(false);
        game_controller._technology_4_5.SetActive(false);
    }

    public static void ChangeTechnologyPage(int page, GameController game_controller){
        DeactivateTechnologyIcons(game_controller);
        switch(page){
            case 0:
                game_controller._technology_2_2.SetActive(true);
                game_controller._technology_2_4.SetActive(true);
                game_controller._technology_next_3_2.SetActive(true);
                game_controller._technology_3_2.SetActive(true);
                game_controller._technology_next_3_4.SetActive(true);
                game_controller._technology_3_4.SetActive(true);
                game_controller._technology_4_1.SetActive(true);
                game_controller._technology_next_4_2.SetActive(true);
                game_controller._technology_4_2.SetActive(true);
                game_controller._technology_next_4_4.SetActive(true);
                game_controller._technology_4_4.SetActive(true);

                game_controller._technology_1_1.GetComponent<Image>().sprite=Sprites.temperature_image;
                game_controller._technology_2_2.GetComponent<Image>().sprite=Sprites.temperature_image;
                game_controller._technology_2_4.GetComponent<Image>().sprite=Sprites.power_image;
                game_controller._technology_3_2.GetComponent<Image>().sprite=Sprites.temperature_image;
                game_controller._technology_3_4.GetComponent<Image>().sprite=Sprites.power_image;
                game_controller._technology_4_1.GetComponent<Image>().sprite=Sprites.temperature_image;
                game_controller._technology_4_2.GetComponent<Image>().sprite=Sprites.temperature_image;
                game_controller._technology_4_4.GetComponent<Image>().sprite=Sprites.power_image;
                break;
            case 1:
                game_controller._technology_2_1.SetActive(true);
                game_controller._technology_2_3.SetActive(true);
                game_controller._technology_3_1.SetActive(true);
                game_controller._technology_next_3_3.SetActive(true);
                game_controller._technology_3_3.SetActive(true);
                game_controller._technology_3_5.SetActive(true);
                game_controller._technology_next_4_1.SetActive(true);
                game_controller._technology_4_1.SetActive(true);
                game_controller._technology_next_4_2.SetActive(true);
                game_controller._technology_4_2.SetActive(true);
                game_controller._technology_next_4_4.SetActive(true);
                game_controller._technology_4_4.SetActive(true);
                game_controller._technology_next_4_5.SetActive(true);
                game_controller._technology_4_5.SetActive(true);

                game_controller._technology_1_1.GetComponent<Image>().sprite=Sprites.tent_logo;
                game_controller._technology_2_1.GetComponent<Image>().sprite=Sprites.tent_logo;
                game_controller._technology_2_3.GetComponent<Image>().sprite=Sprites.tent_logo;
                game_controller._technology_3_1.GetComponent<Image>().sprite=Sprites.family_house_logo;
                game_controller._technology_3_3.GetComponent<Image>().sprite=Sprites.temperature_image;
                game_controller._technology_3_5.GetComponent<Image>().sprite=Sprites.apartment_logo;
                game_controller._technology_4_1.GetComponent<Image>().sprite=Sprites.family_house_logo;
                game_controller._technology_4_2.GetComponent<Image>().sprite=Sprites.resident_image;
                game_controller._technology_4_4.GetComponent<Image>().sprite=Sprites.temperature_image;
                game_controller._technology_4_5.GetComponent<Image>().sprite=Sprites.apartment_logo;
                break;
            case 2:
                game_controller._technology_2_2.SetActive(true);
                game_controller._technology_2_4.SetActive(true);
                game_controller._technology_3_1.SetActive(true);
                game_controller._technology_next_3_4.SetActive(true);
                game_controller._technology_3_4.SetActive(true);
                game_controller._technology_next_4_1.SetActive(true);
                game_controller._technology_4_1.SetActive(true);
                game_controller._technology_next_4_4.SetActive(true);
                game_controller._technology_4_4.SetActive(true);

                game_controller._technology_1_1.GetComponent<Image>().sprite=Sprites.medical_tent_logo;
                game_controller._technology_2_2.GetComponent<Image>().sprite=Sprites.medical_tent_logo;
                game_controller._technology_2_4.GetComponent<Image>().sprite=Sprites.sick_image;
                game_controller._technology_3_1.GetComponent<Image>().sprite=Sprites.hospital_logo;
                game_controller._technology_3_4.GetComponent<Image>().sprite=Sprites.sick_image;
                game_controller._technology_4_1.GetComponent<Image>().sprite=Sprites.hospital_logo;
                game_controller._technology_4_4.GetComponent<Image>().sprite=Sprites.sick_image;
                break;
            case 3:
                game_controller._technology_2_1.SetActive(true);
                game_controller._technology_2_3.SetActive(true);
                game_controller._technology_2_5.SetActive(true);
                game_controller._technology_next_3_1.SetActive(true);
                game_controller._technology_3_1.SetActive(true);
                game_controller._technology_next_3_2.SetActive(true);
                game_controller._technology_3_2.SetActive(true);
                game_controller._technology_next_3_4.SetActive(true);
                game_controller._technology_3_4.SetActive(true);
                game_controller._technology_next_4_1.SetActive(true);
                game_controller._technology_4_1.SetActive(true);
                game_controller._technology_4_5.SetActive(true);

                game_controller._technology_1_1.GetComponent<Image>().sprite=Sprites.fishermans_hut_logo;
                game_controller._technology_2_1.GetComponent<Image>().sprite=Sprites.fishermans_hut_logo;
                game_controller._technology_2_3.GetComponent<Image>().sprite=Sprites.apple_orchard_logo;
                game_controller._technology_2_5.GetComponent<Image>().sprite=Sprites.fishermans_hut_logo;
                game_controller._technology_3_1.GetComponent<Image>().sprite=Sprites.fishermans_hut_logo;
                game_controller._technology_3_2.GetComponent<Image>().sprite=Sprites.apple_orchard_logo;
                game_controller._technology_3_4.GetComponent<Image>().sprite=Sprites.apple_orchard_logo;
                game_controller._technology_4_1.GetComponent<Image>().sprite=Sprites.fishermans_hut_logo;
                game_controller._technology_4_5.GetComponent<Image>().sprite=Sprites.food_image;
                break;
            case 4:
                game_controller._technology_2_1.SetActive(true);
                game_controller._technology_2_3.SetActive(true);
                game_controller._technology_2_5.SetActive(true);
                game_controller._technology_next_3_1.SetActive(true);
                game_controller._technology_3_1.SetActive(true);
                game_controller._technology_next_3_2.SetActive(true);
                game_controller._technology_3_2.SetActive(true);
                game_controller._technology_next_3_4.SetActive(true);
                game_controller._technology_3_4.SetActive(true);
                game_controller._technology_next_3_5.SetActive(true);
                game_controller._technology_3_5.SetActive(true);
                game_controller._technology_next_4_1.SetActive(true);
                game_controller._technology_4_1.SetActive(true);
                game_controller._technology_next_4_5.SetActive(true);
                game_controller._technology_4_5.SetActive(true);

                game_controller._technology_1_1.GetComponent<Image>().sprite=Sprites.iron_mine_logo;
                game_controller._technology_2_1.GetComponent<Image>().sprite=Sprites.building_material_image;
                game_controller._technology_2_3.GetComponent<Image>().sprite=Sprites.warehouse_logo;
                game_controller._technology_2_5.GetComponent<Image>().sprite=Sprites.iron_mine_logo;
                game_controller._technology_3_1.GetComponent<Image>().sprite=Sprites.building_material_image;
                game_controller._technology_3_2.GetComponent<Image>().sprite=Sprites.warehouse_logo;
                game_controller._technology_3_4.GetComponent<Image>().sprite=Sprites.warehouse_logo;
                game_controller._technology_3_5.GetComponent<Image>().sprite=Sprites.iron_mine_logo;
                game_controller._technology_4_1.GetComponent<Image>().sprite=Sprites.building_material_image;
                game_controller._technology_4_5.GetComponent<Image>().sprite=Sprites.iron_mine_logo;
                break;
            case 5:
                game_controller._technology_2_1.SetActive(true);
                game_controller._technology_2_3.SetActive(true);
                game_controller._technology_next_3_1.SetActive(true);
                game_controller._technology_3_1.SetActive(true);
                game_controller._technology_next_3_2.SetActive(true);
                game_controller._technology_3_2.SetActive(true);
                game_controller._technology_next_3_4.SetActive(true);
                game_controller._technology_3_4.SetActive(true);
                game_controller._technology_next_4_1.SetActive(true);
                game_controller._technology_4_1.SetActive(true);
                game_controller._technology_4_5.SetActive(true);

                game_controller._technology_1_1.GetComponent<Image>().sprite=Sprites.solar_panel_logo;
                game_controller._technology_2_1.GetComponent<Image>().sprite=Sprites.solar_panel_logo;
                game_controller._technology_2_3.GetComponent<Image>().sprite=Sprites.coal_mine_logo;
                game_controller._technology_3_1.GetComponent<Image>().sprite=Sprites.solar_panel_logo;
                game_controller._technology_3_2.GetComponent<Image>().sprite=Sprites.coal_mine_logo;
                game_controller._technology_3_4.GetComponent<Image>().sprite=Sprites.coal_mine_logo;
                game_controller._technology_4_1.GetComponent<Image>().sprite=Sprites.solar_panel_logo;
                game_controller._technology_4_5.GetComponent<Image>().sprite=Sprites.power_image;
                break;
            case 6:
                game_controller._technology_2_1.SetActive(true);
                game_controller._technology_2_3.SetActive(true);
                game_controller._technology_2_5.SetActive(true);
                game_controller._technology_next_3_1.SetActive(true);
                game_controller._technology_3_1.SetActive(true);
                game_controller._technology_next_3_3.SetActive(true);
                game_controller._technology_3_3.SetActive(true);
                game_controller._technology_next_3_5.SetActive(true);
                game_controller._technology_3_5.SetActive(true);
                game_controller._technology_next_4_1.SetActive(true);
                game_controller._technology_4_1.SetActive(true);
                game_controller._technology_next_4_3.SetActive(true);
                game_controller._technology_4_3.SetActive(true);
                game_controller._technology_next_4_5.SetActive(true);
                game_controller._technology_4_5.SetActive(true);

                game_controller._technology_1_1.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_2_1.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_2_3.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_2_5.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_3_1.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_3_3.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_3_5.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_4_1.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_4_3.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                game_controller._technology_4_5.GetComponent<Image>().sprite=Sprites.scout_station_logo;
                break;
        }
    }
    public static int SetOpenTechnology(int id, GameController game_controller){
        int open_technology = 0;
        switch(game_controller.open_technology_tab){
            case 0:
                open_technology = id==11?0:open_technology;
                open_technology = id==22?1:open_technology;
                open_technology = id==24?2:open_technology;
                open_technology = id==32?3:open_technology;
                open_technology = id==34?4:open_technology;
                open_technology = id==41?7:open_technology;
                open_technology = id==42?5:open_technology;
                open_technology = id==44?6:open_technology;
                break;
            case 1:
                open_technology = id==11?8:open_technology;
                open_technology = id==21?10:open_technology;
                open_technology = id==23?9:open_technology;
                open_technology = id==31?11:open_technology;
                open_technology = id==33?13:open_technology;
                open_technology = id==35?12:open_technology;
                open_technology = id==41?16:open_technology;
                open_technology = id==42?14:open_technology;
                open_technology = id==44?15:open_technology;
                open_technology = id==45?17:open_technology;
                break;
            case 2:
                open_technology = id==11?18:open_technology;
                open_technology = id==22?20:open_technology;
                open_technology = id==24?19:open_technology;
                open_technology = id==31?21:open_technology;
                open_technology = id==34?22:open_technology;
                open_technology = id==41?23:open_technology;
                open_technology = id==44?24:open_technology;
                break;
            case 3:
                open_technology = id==11?25:open_technology;
                open_technology = id==21?27:open_technology;
                open_technology = id==23?28:open_technology;
                open_technology = id==25?26:open_technology;
                open_technology = id==31?31:open_technology;
                open_technology = id==32?29:open_technology;
                open_technology = id==34?30:open_technology;
                open_technology = id==41?33:open_technology;
                open_technology = id==45?32:open_technology;
                break;
            case 4:
                open_technology = id==11?34:open_technology;
                open_technology = id==21?37:open_technology;
                open_technology = id==23?35:open_technology;
                open_technology = id==25?36:open_technology;
                open_technology = id==31?39:open_technology;
                open_technology = id==32?40:open_technology;
                open_technology = id==34?41:open_technology;
                open_technology = id==35?38:open_technology;
                open_technology = id==41?42:open_technology;
                open_technology = id==45?43:open_technology;
                break;
            case 5:
                open_technology = id==11?44:open_technology;
                open_technology = id==21?45:open_technology;
                open_technology = id==23?46:open_technology;
                open_technology = id==31?49:open_technology;
                open_technology = id==32?48:open_technology;
                open_technology = id==34?47:open_technology;
                open_technology = id==41?51:open_technology;
                open_technology = id==45?50:open_technology;
                break;
            case 6:
                open_technology = id==11?52:open_technology;
                open_technology = id==21?53:open_technology;
                open_technology = id==23?54:open_technology;
                open_technology = id==25?59:open_technology;
                open_technology = id==31?55:open_technology;
                open_technology = id==33?56:open_technology;
                open_technology = id==35?60:open_technology;
                open_technology = id==41?57:open_technology;
                open_technology = id==43?58:open_technology;
                open_technology = id==45?61:open_technology;
                break;
        }
        game_controller._technology_price.text =
            technologies[open_technology].building_material_cost + " building materials\n"
            + technologies[open_technology].iron_cost + " iron\n"
            + technologies[open_technology].research_time + " hours";
        game_controller._technology_description.text = technologies[open_technology].description;
        game_controller._research_technology.interactable = true;
        if(!CanResearch(id,game_controller.open_technology_tab, open_technology)){
            game_controller._research_technology.interactable = false;
        }
        return open_technology;
    }

    private static bool CanResearch(int slot_id, int open_page, int open_technology){
        if(technologies[open_technology].prerequisite != -1 && !active_technologies[technologies[open_technology].prerequisite]){
            return false;
        }
        if(active_technologies[open_technology]){
            return false;
        }
        if(current_tier[open_page] + 1 < (slot_id / 10)){
            return false;
        }
        if(!ResourcesManager.CanAfford(0,0,technologies[open_technology].building_material_cost,technologies[open_technology].iron_cost)){
            return false;
        }
        return true;
    }
}