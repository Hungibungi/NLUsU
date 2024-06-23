using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident
    {
        public bool is_worker;
        public bool is_sick;
        public Workplace workplace;
        public int happyness;
        public int overall_temperature;
        public Workplace.Medical medical;
        public int start_treatment;
        public Resident(bool is_worker, bool is_sick){
            this.is_worker = is_worker;
            this.is_sick = is_sick;
            happyness=100;
            overall_temperature=0;
            start_treatment=0;
        }
    }

public static class Residents
{
    public static Resident[] residents = GetResidents();
    public static int overall_happyness_modifier = 0;
    public static float food_amount_modifier = 1F;
    public static int emergency_shift_happyness = -2;
    public static string happyness_state = "Neutral";

    private static Resident[] GetResidents(){
        Resident[] tempArray = new Resident[50];
        tempArray[0] = new Resident(false, false);
        tempArray[1] = new Resident(false, false);
        tempArray[2] = new Resident(false, false);
        tempArray[3] = new Resident(false, false);
        tempArray[4] = new Resident(false, false);
        tempArray[5] = new Resident(false, false);
        tempArray[6] = new Resident(false, false);
        tempArray[7] = new Resident(false, false);
        tempArray[8] = new Resident(false, false);
        tempArray[9] = new Resident(false, false);
        tempArray[10] = new Resident(false, false);
        tempArray[11] = new Resident(false, false);
        tempArray[12] = new Resident(false, false);
        tempArray[13] = new Resident(false, false);
        tempArray[14] = new Resident(false, false);
        tempArray[15] = new Resident(true, false);
        tempArray[16] = new Resident(true, false);
        tempArray[17] = new Resident(true, false);
        tempArray[18] = new Resident(true, false);
        tempArray[19] = new Resident(true, false);
        tempArray[20] = new Resident(true, false);
        tempArray[21] = new Resident(true, false);
        tempArray[22] = new Resident(true, false);
        tempArray[23] = new Resident(true, false);
        tempArray[24] = new Resident(true, false);
        tempArray[25] = new Resident(true, false);
        tempArray[26] = new Resident(true, false);
        tempArray[27] = new Resident(true, false);
        tempArray[28] = new Resident(true, false);
        tempArray[29] = new Resident(true, false);
        tempArray[30] = new Resident(true, false);
        tempArray[31] = new Resident(true, false);
        tempArray[32] = new Resident(true, false);
        tempArray[33] = new Resident(true, false);
        tempArray[34] = new Resident(true, false);
        tempArray[35] = new Resident(true, false);
        tempArray[36] = new Resident(true, false);
        tempArray[37] = new Resident(true, false);
        tempArray[38] = new Resident(true, false);
        tempArray[39] = new Resident(true, false);
        tempArray[40] = new Resident(true, false);
        tempArray[41] = new Resident(true, false);
        tempArray[42] = new Resident(true, false);
        tempArray[43] = new Resident(true, false);
        tempArray[44] = new Resident(true, false);
        tempArray[45] = new Resident(true, false);
        tempArray[46] = new Resident(true, false);
        tempArray[47] = new Resident(true, false);
        tempArray[48] = new Resident(true, false);
        tempArray[49] = new Resident(true, false);
        return tempArray;
    }
    public static int OverallHappyness(){
        int happyness = 0;
        foreach(Resident res in residents){
            happyness += res.happyness;
        }
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
    public static bool IsWorkerAvailable(){
        foreach(Resident res in residents){
            if(res.workplace == null && res.is_worker){
                return true;
            }
        }
        return false;
    }
    public static bool IsChildrenAvailable(){
        foreach(Resident res in residents){
            if(res.workplace == null && !res.is_worker){
                return true;
            }
        }
        return false;
    }
    public static void AssignWorker(Workplace workplace){
        foreach(Resident res in residents){
            if(res.workplace == null && res.is_worker){
                res.workplace = workplace;
                if(res.is_sick){
                    workplace.sick_workers++;
                } else{
                    workplace.current_workers++;
                }
                break;
            }
        }
    }
    public static void AssignChildren(Workplace workplace){
        foreach(Resident res in residents){
            if(res.workplace == null && !res.is_worker){
                res.workplace = workplace;
                if(res.is_sick){
                    workplace.sick_workers++;
                } else{
                    workplace.children_workers++;
                }
                break;
            }
        }
    }
    public static void DeAssignWorker(Workplace workplace){
        foreach(Resident res in residents){
            if(res.workplace == workplace && res.is_worker){
                res.workplace = null;
                if(res.is_sick){
                    workplace.sick_workers--;
                } else{
                    workplace.current_workers--;
                }
                break;
            }
        }
    }
    public static void DeAssignChildren(Workplace workplace){
        foreach(Resident res in residents){
            if(res.workplace == workplace && !res.is_worker){
                res.workplace = null;
                if(res.is_sick){
                    workplace.sick_workers--;
                } else{
                    workplace.children_workers--;
                }
                break;
            }
        }
    }
    public static void GotSick(Resident resident, int elapsed_hours){
        resident.is_sick = true;
        if(resident.is_worker && resident.workplace != null){
            resident.workplace.sick_workers++;
            resident.workplace.current_workers--;
        } else if(!resident.is_worker && resident.workplace != null){
            resident.workplace.sick_workers++;
            resident.workplace.children_workers--;
        }

        foreach(Building building in Buildings.buildings){
            if(building is Workplace.Medical medical){
                if(medical.max_sick > medical.current_sick){
                medical.current_sick++;
                resident.medical = medical;
                resident.start_treatment = elapsed_hours;
                break;
            }
            }
        }
    }
    public static void Recovered(Resident resident){
        resident.is_sick = false;
        if(resident.is_worker && resident.workplace != null){
            resident.workplace.sick_workers--;
            resident.workplace.current_workers++;
        } else if(!resident.is_worker && resident.workplace != null){
            resident.workplace.sick_workers--;
            resident.workplace.children_workers++;
        }

        foreach(Building building in Buildings.buildings){
            if(building is Workplace.Medical medical && resident.medical == medical){
                medical.current_sick--;
                resident.medical = null;
                break;
            }
        }
    }
    public static void Died(Resident resident){
        if(resident.workplace != null && resident.is_worker){
            DeAssignWorker(resident.workplace);
        }
        if(resident.workplace != null && !resident.is_worker){
            DeAssignChildren(resident.workplace);
        }
        int index = Array.IndexOf(residents, resident);
        Resident[] tempArray = new Resident[residents.Length - 1];
        for(int i = 0; i < residents.Length; i++){
            if(i < index){
                tempArray[i] = residents[i];
            } else if(i > index){
                tempArray[i - 1] = residents[i];
            }
        }
        residents = tempArray;
    }
    public static void AdjustHappyness(int temperature, int base_cooling){
        int homeless = Buildings.OverallHousingSpace() - residents.Length;
        int overall_temperature = 0;
        float overall_housing_happyness = 0;
        int housing_amount = 0;
        int policy_user = Buildings.OverallPolicySpace();
        int overall_policy_happyness = Buildings.OverallPolicyHappyness();
        foreach(Resident resident in residents){
            if(homeless < 0){
                homeless++;
                resident.happyness = 0;
                resident.overall_temperature = temperature - base_cooling;
            } else{
                foreach(Building building in Buildings.buildings){
                    if(building is Housing.Tent tent){
                        if(resident.workplace == null){
                            overall_temperature = temperature - base_cooling - (tent.coolness + tent.coolness_modifier);
                        } else{
                            overall_temperature = temperature - base_cooling - (resident.workplace.working_hours * (resident.workplace.coolness + resident.workplace.coolness_modifier) / 24) - (tent.coolness + tent.coolness_modifier) * (24 - resident.workplace.working_hours);
                        }
                        overall_housing_happyness += tent.happyness_modifier;
                        housing_amount++;
                    }
                    if(building is Housing.House house){
                        if(resident.workplace == null){
                            overall_temperature = temperature - base_cooling - (house.coolness + house.coolness_modifier);
                        } else{
                            overall_temperature = temperature - base_cooling - (resident.workplace.working_hours * (resident.workplace.coolness + resident.workplace.coolness_modifier) / 24) - (house.coolness + house.coolness_modifier) * (24 - resident.workplace.working_hours);
                        }
                        overall_housing_happyness += house.happyness_modifier;
                        housing_amount++;
                    }
                    if(building is Housing.Apartment apartment){
                        if(resident.workplace == null){
                            overall_temperature = temperature - base_cooling - (apartment.coolness + apartment.coolness_modifier);
                        } else{
                            overall_temperature = temperature - base_cooling - (resident.workplace.working_hours * (resident.workplace.coolness + resident.workplace.coolness_modifier) / 24) - (apartment.coolness + apartment.coolness_modifier) * (24 - resident.workplace.working_hours);
                        }
                        overall_housing_happyness += apartment.happyness_modifier;
                        housing_amount++;
                    }
                }
                if(overall_temperature <= 25){
                    resident.happyness = 100;
                } else{
                    resident.happyness = (overall_temperature > 45) ? resident.happyness = 0 : 100 + (25 - overall_temperature) * 5;
                }
                if(policy_user > 0){
                    policy_user--;
                    resident.happyness += overall_policy_happyness;
                }
                resident.overall_temperature = overall_temperature;
                resident.happyness += (int)(overall_housing_happyness / housing_amount);
            }
            if(resident.workplace != null && resident.workplace.working_hours != 8){
                resident.happyness += emergency_shift_happyness * resident.workplace.working_hours;
            }
            resident.happyness += overall_happyness_modifier;
            resident.happyness = ResourcesManager.food==0?resident.happyness-20:resident.happyness;
            resident.happyness = resident.happyness * (100 - GameOptions.overall_discontent * 2) / 100;
            if(!resident.is_worker && resident.workplace is Workplace.Resource && resident.workplace is not Workplace.Resource.ChildCookery){
                resident.happyness -= 50;
            }
        }
    }

    public static void ManageWorkers(int slot_id, int type, GameController game_controller){
        switch(game_controller.open_people_tab){
            case 1:
                switch(slot_id){
                    case 0:
                        foreach(Building building in Buildings.buildings){
                            if(building is Workplace.Medical.MedicalTent workplace){
                                switch(type){
                                        case 0:
                                            AssignWorker(workplace);
                                            break;
                                        case 1:
                                            DeAssignWorker(workplace);
                                            break;
                                        case 2:
                                            AssignChildren(workplace);
                                            break;
                                        case 3:
                                            DeAssignChildren(workplace);
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;
                    case 1:
                        foreach(Building building in Buildings.buildings){
                            if(building is Workplace.Medical.Hospital workplace){
                                switch(type){
                                        case 0:
                                            AssignWorker(workplace);
                                            break;
                                        case 1:
                                            DeAssignWorker(workplace);
                                            break;
                                        case 2:
                                            AssignChildren(workplace);
                                            break;
                                        case 3:
                                            DeAssignChildren(workplace);
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;
                }
                break;
            case 2:
                foreach(Building building in Buildings.buildings){
                        if(building is Workplace.ScienceLab workplace){
                            switch(type){
                                    case 0:
                                        AssignWorker(workplace);
                                        break;
                                    case 1:
                                        DeAssignWorker(workplace);
                                        break;
                                    case 2:
                                        AssignChildren(workplace);
                                        break;
                                    case 3:
                                        DeAssignChildren(workplace);
                                        break;
                                }
                                break;
                        }
                    }
                break;
            case 3:
                switch(slot_id){
                    case 0:
                        foreach(Building building in Buildings.buildings){
                            if(building is Workplace.Resource.FishermansHut workplace){
                                switch(type){
                                        case 0:
                                            AssignWorker(workplace);
                                            break;
                                        case 1:
                                            DeAssignWorker(workplace);
                                            break;
                                        case 2:
                                            AssignChildren(workplace);
                                            break;
                                        case 3:
                                            DeAssignChildren(workplace);
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;
                    case 1:
                        foreach(Building building in Buildings.buildings){
                            if(building is Workplace.Resource.AppleOrchard workplace){
                                switch(type){
                                        case 0:
                                            AssignWorker(workplace);
                                            break;
                                        case 1:
                                            DeAssignWorker(workplace);
                                            break;
                                        case 2:
                                            AssignChildren(workplace);
                                            break;
                                        case 3:
                                            DeAssignChildren(workplace);
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;
                    case 2:
                        foreach(Building building in Buildings.buildings){
                            if(building is Workplace.Resource.ChildCookery workplace){
                                switch(type){
                                        case 0:
                                            AssignWorker(workplace);
                                            break;
                                        case 1:
                                            DeAssignWorker(workplace);
                                            break;
                                        case 2:
                                            AssignChildren(workplace);
                                            break;
                                        case 3:
                                            DeAssignChildren(workplace);
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;
                }
                break;
            case 4:
                foreach(Building building in Buildings.buildings){
                    if(building is Workplace.Resource.CoalMine workplace){
                        switch(type){
                                case 0:
                                    AssignWorker(workplace);
                                    break;
                                case 1:
                                    DeAssignWorker(workplace);
                                    break;
                                case 2:
                                    AssignChildren(workplace);
                                    break;
                                case 3:
                                    DeAssignChildren(workplace);
                                    break;
                            }
                            break;
                    }
                }
                break;
            case 5:
                foreach(Building building in Buildings.buildings){
                    if(building is Workplace.Resource.IronMine workplace){
                        switch(type){
                                case 0:
                                    AssignWorker(workplace);
                                    break;
                                case 1:
                                    DeAssignWorker(workplace);
                                    break;
                                case 2:
                                    AssignChildren(workplace);
                                    break;
                                case 3:
                                    DeAssignChildren(workplace);
                                    break;
                            }
                            break;
                    }
                }
                break;
        }
    }
}