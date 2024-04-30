using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Buildings
{
    public static Building[] buildings = GetBuildings();
    
    private static Building[] GetBuildings(){
        Building[] tempArray = new Building[2];
        tempArray[0] = new Mine();
        tempArray[0] = new House();
        return tempArray;
    }

    public static int OverallHousingSpace(){
        int space = 0;
        foreach(Building building in buildings){
            if(building is House house){
                space += (int)(house.max_residents * house.max_residents_modifier);
            }
        }
        return space;
    }

    public static int OverallSickSpace(){
        int space = 0;
        foreach(Building building in buildings){
            if(building is Hospital hospital){
                space += (int)(hospital.max_sick * hospital.max_sick_modifier);
            }
        }
        return space;
    }
}