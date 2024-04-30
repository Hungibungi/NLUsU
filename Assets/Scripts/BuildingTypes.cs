using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    public int building_material_cost;
    public int iron_cost;
    public int amount_built;
    public int amount_max;
    public int coolness;
    public float coolness_modifier;
    
    public Building(){
        building_material_cost = 0;
        iron_cost = 0;
        amount_built = 0;
        amount_max = 0;
        coolness = 0;
        coolness_modifier = 1;
    }
}

public class House : Building{
    public int max_residents;
    public float max_residents_modifier;

    public House(){
        building_material_cost = 10;
        iron_cost = 0;
        amount_built = 0;
        amount_max = 999;
        coolness = 0;
        coolness_modifier = 1;
        max_residents = 10;
        max_residents_modifier = 1;
    }
}

public class Workplace : Building{
    public int max_workers;
    public int current_workers;
    public int children_workers;
    public int sick_workers;
    public int efficiency;
    public int working_hours;

    public Workplace(){
        building_material_cost = 0;
        iron_cost = 0;
        amount_built = 0;
        amount_max = 0;
        max_workers = 0;
        current_workers = 0;
        children_workers = 0;
        sick_workers = 0;
        efficiency = 0;
        working_hours = 8;
    }
}

public class Mine : Workplace{
    public int building_material_efficiency;
    public int iron_efficiency;
    public int power_efficiency;

    public Mine(){
        building_material_cost = 0;
        iron_cost = 0;
        amount_built = 0;
        amount_max = 999;
        max_workers = 0;
        current_workers = 0;
        children_workers = 0;
        sick_workers = 0;
        efficiency = 0;
        working_hours = 8;
        building_material_efficiency = 1;
        iron_efficiency = 1;
        power_efficiency = 1;
        coolness = 0;
        coolness_modifier = 1;
    }
}

public class Hospital : Workplace{
    public int max_sick;
    public float max_sick_modifier;

    public Hospital(){
        building_material_cost = 0;
        iron_cost = 0;
        amount_built = 0;
        amount_max = 999;
        max_workers = 0;
        current_workers = 0;
        children_workers = 0;
        sick_workers = 0;
        efficiency = 0;
        working_hours = 8;
        max_sick = 5;
        max_sick_modifier = 1;
    }
}