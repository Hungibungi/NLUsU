using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident
    {
        public bool is_worker;
        public bool is_sick;
        public Workplace workplace;
        public int happyness;
        public int temperature;
        public Resident(bool is_worker, bool is_sick){
            this.is_worker = is_worker;
            this.is_sick = is_sick;
            happyness=100;
            temperature=30;
        }
    }

public static class Residents
{
    public static Resident[] residents = GetResidents();

    private static Resident[] GetResidents(){
        Resident[] tempArray = new Resident[3];
        tempArray[0] = new Resident(true, false);
        tempArray[1] = new Resident(false, false);
        tempArray[2] = new Resident(true, true);
        return tempArray;
    }
    public static int OverallHappyness(){
        int happyness = 0;
        foreach(Resident res in residents){
            happyness += res.happyness;
        }
        Debug.Log((int)(happyness / residents.Length));
        return (int)(happyness / residents.Length);
    }
    public static int OverallWorkingWorkers(){
        int workers = 0;
        foreach(Resident res in residents){
            if(res.workplace != null && res.is_worker){
                workers++;
            }
        }
        return workers;
    }
    public static int OverallWorkers(){
        int workers = 0;
        foreach(Resident res in residents){
            if(res.is_worker){
                workers++;
            }
        }
        return workers;
    }
    public static int OverallChildWorkers(){
        int child = 0;
        foreach(Resident res in residents){
            if(res.workplace != null && !res.is_worker){
                child++;
            }
        }
        return child;
    }
    public static int OverallChildren(){
        int child = 0;
        foreach(Resident res in residents){
            if(!res.is_worker){
                child++;
            }
        }
        return child;
    }
    public static int OverallSick(){
        int sick = 0;
        foreach(Resident res in residents){
            if(res.is_sick){
                sick++;
            }
        }
        return sick;
    }
    public static void AdjustHappyness(int temperature){
        int homeless = Buildings.OverallHousingSpace() - residents.Length;
        int overall_temperature = 0;
        foreach(Resident res in residents){
            if(homeless < 0){
                homeless++;
                res.happyness = 0;
            } else{
                if(res.workplace == null){
                    foreach(Building building in Buildings.buildings){
                        if(building is House house){
                            overall_temperature = temperature - (int)(house.coolness * house.coolness_modifier);
                        }
                    }
                } else{
                    foreach(Building building in Buildings.buildings){
                        if(building is House house){
                            overall_temperature = temperature - (int)(res.workplace.working_hours * res.workplace.coolness * res.workplace.coolness_modifier / 24) - (int)(house.coolness * house.coolness_modifier * (24 - res.workplace.working_hours));
                        }
                    }
                }
                if(overall_temperature <=25){
                    res.happyness = 100;
                } else{
                    res.happyness = (overall_temperature > 45) ? res.happyness = 0 : 100 + (25 - overall_temperature) * 5;
                }
            }
            res.happyness = res.is_sick ? (int)(res.happyness / 2) : res.happyness;
        }
    }
}