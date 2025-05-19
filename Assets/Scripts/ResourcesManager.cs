using UnityEngine;

public static class ResourcesManager
{
    public static int food;
    public static int food_production;
    public static float food_production_modifier = 1F;
    public static int food_consumption;
    public static int power;
    public static int power_production;
    public static int power_consumption;
    public static int building_material;
    public static int building_material_production;
    public static int building_material_consumption;
    public static int iron;
    public static int iron_production;
    public static int iron_consumption;
    public static float cooling_efficiency = 1F;
    public static int research_speed;
    public static int research_progress;

    public static int GetFoodStorage(){
        int storage = 0;
        foreach(Building building in Buildings.buildings){
            if(building is Building.Warehouse warehouse){
                storage += warehouse.food_storage;
            }
        }
        return storage;
    }

    public static int GetPowerStorage(){
        int storage = 0;
        foreach(Building building in Buildings.buildings){
            if(building is Building.Warehouse warehouse){
                storage += warehouse.power_storage;
            }
        }
        return storage;
    }

    public static int GetBuildingMaterialStorage(){
        int storage = 0;
        foreach(Building building in Buildings.buildings){
            if(building is Building.Warehouse warehouse){
                storage += warehouse.building_material_storage;
            }
        }
        return storage;
    }

    public static int GetIronStorage(){
        int storage = 0;
        foreach(Building building in Buildings.buildings){
            if(building is Building.Warehouse warehouse){
                storage += warehouse.iron_storage;
            }
        }
        return storage;
    }

    public static void CalculateProduction(int temperature, int base_cooling, int day_cycle){
        int actual_production = 0;
        food_production = 0;
        power_production = 0;
        power_consumption = 0;
        building_material_production = 0;
        iron_production = 0;
        research_speed = 0;
        float actual_food_production_modifier = food_production_modifier;
        float happyness_multiplier = 1F;
        happyness_multiplier = Residents.happyness_state=="happy"?1.25F:happyness_multiplier;
        happyness_multiplier = Residents.happyness_state=="neutral"?1F:happyness_multiplier;
        happyness_multiplier = Residents.happyness_state=="sad"?0.75F:happyness_multiplier;

        foreach(Building building in Buildings.buildings){
            if(building is Workplace.Resource.ChildCookery child_cookery){
                actual_food_production_modifier = food_production_modifier * (1 + (child_cookery.food_multiplier - 1) / child_cookery.max_workers * (child_cookery.children_workers + child_cookery.sick_child_workers * child_cookery.sick_efficiency));
            }
        }

        foreach(Building building in Buildings.buildings){
            if(building is Workplace.Resource workplace && (workplace.working_hours == 24 || (workplace.working_hours == 12 && day_cycle > 0) || (workplace.working_hours == 8 && day_cycle == 2))){
                actual_production = (int)(workplace.food_production / workplace.max_workers * (workplace.current_workers * workplace.workers_efficiency + workplace.children_workers * workplace.children_efficiency + workplace.sick_workers * workplace.sick_efficiency + workplace.sick_child_workers * workplace.sick_efficiency));
                food_production += (int)(actual_production * workplace.food_efficiency * happyness_multiplier * actual_food_production_modifier * (float)(100F - GameOptions.overall_costs * 2F) / 100F);
                actual_production = (int)(workplace.power_production / workplace.max_workers * (workplace.current_workers * workplace.workers_efficiency + workplace.children_workers * workplace.children_efficiency + workplace.sick_workers * workplace.sick_efficiency + workplace.sick_child_workers * workplace.sick_efficiency));
                power_production += (int)(actual_production * workplace.power_efficiency * happyness_multiplier * (100 - GameOptions.overall_costs * 2) / 100);
                actual_production = (int)(workplace.building_material_production / workplace.max_workers * (workplace.current_workers * workplace.workers_efficiency + workplace.children_workers * workplace.children_efficiency + workplace.sick_workers * workplace.sick_efficiency + workplace.sick_child_workers * workplace.sick_efficiency));
                building_material_production += (int)(actual_production * workplace.building_material_efficiency * happyness_multiplier * (100 - GameOptions.overall_costs * 2) / 100);
                actual_production = (int)(workplace.iron_production / workplace.max_workers * (workplace.current_workers * workplace.workers_efficiency + workplace.children_workers * workplace.children_efficiency + workplace.sick_workers * workplace.sick_efficiency + workplace.sick_child_workers * workplace.sick_efficiency));
                iron_production += (int)(actual_production * workplace.iron_efficiency * happyness_multiplier * (100 - GameOptions.overall_costs * 2) / 100);
                if(workplace.enable_cooling){
                    int temp_consumption = (int)((temperature - base_cooling - workplace.coolness - workplace.coolness_modifier - workplace.target_temperature) * cooling_efficiency);
                    temp_consumption = temp_consumption > 0 ? -temp_consumption : 0;
                    power_consumption += temp_consumption;
                }
            }
            if(building is Housing housing){
                if(housing.enable_cooling){
                    int temp_consumption = (int)((temperature - base_cooling - housing.coolness - housing.coolness_modifier - housing.target_temperature) * cooling_efficiency);
                    temp_consumption = temp_consumption > 0 ? -temp_consumption : 0;
                    power_consumption += temp_consumption;
                }
            }
            if(building is Workplace.ScienceLab science_lab && (science_lab.working_hours == 24 || (science_lab.working_hours == 12 && day_cycle > 0) || (science_lab.working_hours == 8 && day_cycle == 2))){
                science_lab.science_production = (int)(science_lab.current_workers * science_lab.workers_efficiency + science_lab.children_workers * science_lab.children_efficiency + science_lab.sick_workers * science_lab.sick_efficiency + science_lab.sick_child_workers * science_lab.sick_efficiency);
                research_speed += science_lab.science_production;
            }
        }
        food_consumption = (int)(Residents.residents.Length * Residents.food_amount_modifier * -0.1);
        building_material_consumption = 0;
        iron_consumption = 0;
    }

    public static void GainHourlyResources(){
        food += food_consumption + food_production;
        food = food<0?0:food;
        food = food>GetFoodStorage()?GetFoodStorage():food;
        power += power_consumption + power_production;
        power = power<0?0:power;
        power = power>GetPowerStorage()?GetPowerStorage():power;
        building_material += building_material_consumption + building_material_production;
        building_material = building_material<0?0:building_material;
        building_material = building_material>GetBuildingMaterialStorage()?GetBuildingMaterialStorage():building_material;
        iron += iron_consumption + iron_production;
        iron = iron<0?0:iron;
        iron = iron>GetIronStorage()?GetIronStorage():iron;
        research_progress += research_speed;

        if(power == 0){
            Buildings.able_to_cool = false;
        } else{
            Buildings.able_to_cool = true;
        }
    }

    public static bool CanAfford(int required_food, int required_power, int required_building_material, int required_iron){
        if(food >= required_food && power >= required_power && building_material >= required_building_material && iron >= required_iron){
            return true;
        }
        return false;
    }

    public static void PayResources(int required_food, int required_power, int required_building_material, int required_iron){
        if(CanAfford(required_food, required_power, required_building_material, required_iron)){
            food = food - required_food;
            power = power - required_power;
            building_material = building_material - required_building_material;
            iron = iron - required_iron;
        }
    }

    public static void RefreshResourcesWidget(GameController game_controller){
        int food_storage = GetFoodStorage();
        food = food>food_storage?food_storage:food;
        int power_storage = GetPowerStorage();
        power = power>power_storage?power_storage:power;
        int building_material_storage = GetBuildingMaterialStorage();
        building_material = building_material>building_material_storage?building_material_storage:building_material;
        int iron_storage = GetIronStorage();
        iron = iron>iron_storage?iron_storage:iron;

        game_controller._food.text = food + "\n----\n" + food_storage;
        game_controller._food.color = food - food_storage < 0 ? Color.black : Color.yellow;
        game_controller._food.color = food == 0 ? Color.red : game_controller._food.color;
        game_controller._food_image.color = food - food_storage < 0 ? Color.black : Color.yellow;
        game_controller._food_image.color = food == 0 ? Color.red : game_controller._food_image.color;
        game_controller._power.text = power + "\n----\n" + power_storage;
        game_controller._power.color = power - power_storage < 0 ? Color.black : Color.yellow;
        game_controller._power.color = power == 0 ? Color.red : game_controller._power.color;
        game_controller._power_image.color = power - power_storage < 0 ? Color.black : Color.yellow;
        game_controller._power_image.color = power == 0 ? Color.red : game_controller._power_image.color;
        game_controller._building_material.text = building_material + "\n----\n" + building_material_storage;
        game_controller._building_material.color = building_material - building_material_storage < 0 ? Color.black : Color.yellow;
        game_controller._building_material.color = building_material == 0 ? Color.red : game_controller._building_material.color;
        game_controller._building_material_image.color = building_material - building_material_storage < 0 ? Color.black : Color.yellow;
        game_controller._building_material_image.color = building_material == 0 ? Color.red : game_controller._building_material_image.color;
        game_controller._iron.text = iron + "\n----\n" + iron_storage;
        game_controller._iron.color = iron - iron_storage < 0 ? Color.black : Color.yellow;
        game_controller._iron.color = iron == 0 ? Color.red : game_controller._iron.color;
        game_controller._iron_image.color = iron - iron_storage < 0 ? Color.black : Color.yellow;
        game_controller._iron_image.color = iron == 0 ? Color.red : game_controller._iron_image.color;
        game_controller._food_production.text =
            "Production: " + food_production + "\n"
            + "Consumption: " + food_consumption + "\n"
            + "Overall surplus: " + (food_production + food_consumption);
        game_controller._food_production.color = food_production + food_consumption > 0 ? Color.black : Color.red;
        game_controller._power_production.text =
            "Production: " + power_production + "\n"
            + "Consumption: " + power_consumption + "\n"
            + "Overall surplus: " + (power_production + power_consumption);
        game_controller._power_production.color = power_production + power_consumption > 0 ? Color.black : Color.red;
        game_controller._building_material_production.text =
            "Production: " + building_material_production + "\n"
            + "Consumption: " + building_material_consumption + "\n"
            + "Overall surplus: " + (building_material_production + building_material_consumption);
        game_controller._building_material_production.color = building_material_production + building_material_consumption > 0 ? Color.black : Color.red;
        game_controller._iron_production.text =
            "Production: " + iron_production + "\n"
            + "Consumption: " + iron_consumption + "\n"
            + "Overall surplus: " + (iron_production + iron_consumption);
        game_controller._iron_production.color = iron_production + iron_consumption > 0 ? Color.black : Color.red;
    }
}