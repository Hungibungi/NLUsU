public class Policy
{
    public int cooldown_time;
    public int id;
    public int prerequisite;
    public string description;

    public Policy(int cooldown_time, int id, int prerequisite, string description){
        this.cooldown_time=cooldown_time;
        this.id=id;
        this.prerequisite=prerequisite;
        this.description=description;
    }
}

public static class Policies
{
    public static Policy[] policies = GetPolicies();
    public static bool[] active_policies = new bool[45];
    public static int next_policy = 0;

    public static void ResetPolicies(){
        policies = GetPolicies();
        active_policies = new bool[45];
        next_policy = 0;
    }

    private static Policy[] GetPolicies(){
        Policy[] tempArray = new Policy[45];
        // People
        tempArray[0] = new Policy(24,0,-1,"Increases the amount of residents in apartment buildings, but reduces happyness.");
        tempArray[1] = new Policy(48,1,0,"Decreases the happyness penalty.");
        tempArray[2] = new Policy(72,2,1,"Negates the happyness penalty.");
        tempArray[3] = new Policy(24,3,-1,"Decreases the amount of residents in family houses, but increases happyness.");
        tempArray[4] = new Policy(48,4,3,"Increases the happyness bonus.");
        tempArray[5] = new Policy(72,5,4,"Increases the amount of residents in family houses back to normal, while keeping the happyness bonus.");
        tempArray[6] = new Policy(24,6,-1,"Enables the building of pub buildings.");
        tempArray[7] = new Policy(48,7,6,"Enables the building of house of pleasure buildings.");
        tempArray[8] = new Policy(72,8,7,"Increases the happyness bonus.");
        tempArray[9] = new Policy(24,9,-1,"Enables the use of science apprentices in science labs.");
        tempArray[10] = new Policy(48,10,9,"Increases the efficiency of apprentices.");
        tempArray[11] = new Policy(72,11,10,"Increases the working efficiency of child workers to match the adult workers.");

        // Health
        tempArray[12] = new Policy(24,12,-1,"Increases the maximum amount of sick being treated at the same time, but decreases the treatment speed.");
        tempArray[13] = new Policy(48,13,12,"Decreases the treatment speed penalty.");
        tempArray[14] = new Policy(72,14,13,"Negates the treatment speed penalty.");
        tempArray[15] = new Policy(24,15,-1,"Decreases the maximum amount of sick being treated at the same time, but increases the treatment speed.");
        tempArray[16] = new Policy(48,16,15,"Increases the treatment speed bonus.");
        tempArray[17] = new Policy(72,17,16,"Increases the maximum amount of sick being treated at the same time back to normal, while keeping the treatment speed bonus.");
        tempArray[18] = new Policy(24,18,-1,"Enables the use of medical apprentices in medical buildings.");
        tempArray[19] = new Policy(48,19,18,"Increases the efficiency of apprentices.");
        tempArray[20] = new Policy(72,20,19,"Increases the working efficiency of child workers to match the adult workers.");

        // Food
        tempArray[21] = new Policy(24,21,-1,"Decreases the food portion per resident, but decreases happyness.");
        tempArray[22] = new Policy(48,22,21,"Decreases the happyness penalty.");
        tempArray[23] = new Policy(72,23,22,"Negates the happyness penalty.");
        tempArray[24] = new Policy(24,24,-1,"Increases the food portion per resident and their happyness.");
        tempArray[25] = new Policy(48,25,24,"Increases the happyness bonus.");
        tempArray[26] = new Policy(72,26,25,"Increases the food portion per resident back to normal, while keeping the happyness bonus.");
        tempArray[27] = new Policy(24,27,-1,"Activates the use of sawdust while creating food to make 1.5x as much, but decreases happyness.");
        tempArray[28] = new Policy(48,28,27,"Increases the extra food multiplier to 1.75x.");
        tempArray[29] = new Policy(72,29,28,"Increases the extra food multiplier to 2x.");
        tempArray[30] = new Policy(24,30,-1,"Enables the building of the children cookery building.");
        tempArray[31] = new Policy(48,31,30,"Increases the extra food multiplier to 1.3x.");
        tempArray[32] = new Policy(72,32,31,"Increases the extra food multiplier to 1.5x.");

        // Resources
        tempArray[33] = new Policy(24,33,-1,"Enables the use of emergency 24 hour shifts, but heavily decreases happyness when in use.");
        tempArray[34] = new Policy(48,34,33,"Decreases the happyness penalty for the use of emergency/extended shifts.");
        tempArray[35] = new Policy(72,35,34,"Enables the use of extended 12 hour shifts, but decreases the happyness when in use.");
        tempArray[36] = new Policy(24,36,-1,"Enables the use of children in resource workplaces, but heavily decreases happyness when in use.");
        tempArray[37] = new Policy(48,37,36,"Increases the working efficiency of child workers.");
        tempArray[38] = new Policy(72,38,37,"Increases the working efficiency of child workers to match the adult workers.");
        tempArray[39] = new Policy(24,39,-1,"Activates the use of sick workers in workplaces");
        tempArray[40] = new Policy(48,40,39,"Increases the working efficiency of sick workers.");
        tempArray[41] = new Policy(72,41,40,"Increases the working efficiency of sick workers to match the healthy workers.");

        // Leading
        tempArray[42] = new Policy(0,42,-1,"Please the already happy residents, change the neutral state to being happy.");
        tempArray[43] = new Policy(0,43,-1,"Try to negotiate, change the sad state to being neutral.");
        tempArray[44] = new Policy(0,44,-1,"Massacre the protesters, disables protests but residents are always sad.");
        return tempArray;
    }

    public static void ActivatePolicy(int id, GameController game_controller){
        active_policies[id] = true;
        switch(id){
            // People
            case 0:
                // Increases the amount of residents in apartment buildings, but reduces happyness.
                Buildings.apartment.max_residents += 5;
                Buildings.apartment.happyness_modifier -= 10;
                break;
            case 1:
                // Decreases the happyness penalty.
            case 2:
                // Negates the happyness penalty.
                Buildings.apartment.happyness_modifier += 5;
                break;
            case 3:
                // Decreases the amount of residents in family houses, but increases happyness.
                Buildings.house.max_residents -= 5;
                Buildings.house.happyness_modifier += 5;
                break;
            case 4:
                // Increases the happyness bonus.
                Buildings.house.happyness_modifier += 5;
                break;
            case 5:
                // Increases the amount of residents in family houses back to normal, while keeping the happyness bonus.
                Buildings.house.max_residents += 5;
                break;
            case 6:
                // Enables the building of pub buildings.
                Buildings.pub.active = true;
                break;
            case 7:
                // Enables the building of house of pleasure buildings.
                Buildings.house_of_pleasure.active = true;
                break;
            case 8:
                // Increases the happyness bonus.
                Buildings.pub.happyness_bonus += 5;
                Buildings.house_of_pleasure.happyness_bonus += 10;
                break;
            case 9:
                // Enables the use of science apprentices in science labs.
                Buildings.science_lab.child_work = true;
                break;
            case 10:
                // Increases the efficiency of apprentices.
                Buildings.science_lab.children_efficiency = 0.75F;
                break;
            case 11:
                // Increases the working efficiency of child workers to match the adult workers.
                Buildings.science_lab.children_efficiency = 1F;
                break;

            // Health
            case 12:
                // Increases the maximum amount of sick being treated at the same time, but decreases the treatment speed.
                Buildings.medical_tent.max_sick += 5;
                Buildings.medical_tent.treatment_speed -= 0.5F;
                Buildings.hospital.max_sick += 10;
                Buildings.hospital.treatment_speed -= 0.5F;
                break;
            case 13:
                // Decreases the treatment speed penalty.
            case 14:
                // Negates the treatment speed penalty.
                Buildings.medical_tent.treatment_speed += 0.25F;
                Buildings.hospital.treatment_speed += 0.25F;
                break;
            case 15:
                // Decreases the maximum amount of sick being treated at the same time, but increases the treatment speed.
                Buildings.medical_tent.max_sick -= 5;
                Buildings.medical_tent.treatment_speed += 0.25F;
                Buildings.hospital.max_sick -= 10;
                Buildings.hospital.treatment_speed += 0.25F;
                break;
            case 16:
                // Increases the treatment speed bonus.
                Buildings.medical_tent.treatment_speed += 0.25F;
                Buildings.hospital.treatment_speed += 0.25F;
                break;
            case 17:
                // Increases the maximum amount of sick being treated at the same time back to normal, while keeping the treatment speed bonus.
                Buildings.medical_tent.max_sick += 5;
                Buildings.hospital.max_sick += 10;
                break;
            case 18:
                // Enables the use of medical apprentices in medical buildings.
                Buildings.medical_tent.child_work = true;
                Buildings.hospital.child_work = true;
                break;
            case 19:
                // Increases the efficiency of apprentices.
                Buildings.medical_tent.children_efficiency = 0.75F;
                Buildings.hospital.children_efficiency = 0.75F;
                break;
            case 20:
                // Increases the working efficiency of child workers to match the adult workers.
                Buildings.medical_tent.children_efficiency = 1F;
                Buildings.hospital.children_efficiency = 1F;
                break;

            // Food
            case 21:
                // Decreases the food portion per resident, but decreases happyness.
                Residents.food_amount_modifier -= 0.2F;
                Residents.overall_happyness_modifier -= 20;
                break;
            case 22:
                // Decreases the happyness penalty.
            case 23:
                // Negates the happyness penalty.
                Residents.overall_happyness_modifier += 10;
                break;
            case 24:
                // Increases the food portion per resident and their happyness.
                Residents.food_amount_modifier += 0.2F;
                Residents.overall_happyness_modifier += 5;
                break;
            case 25:
                // Increases the happyness bonus.
                Residents.overall_happyness_modifier += 5;
                break;
            case 26:
                // Increases the food portion per resident back to normal, while keeping the happyness bonus.
                Residents.food_amount_modifier -= 0.2F;
                break;
            case 27:
                // Activates the use of sawdust while creating food to make 1.5x as much, but decreases happyness.
                ResourcesManager.food_production_modifier *= 1.5F;
                Residents.overall_happyness_modifier -= 20;
                break;
            case 28:
                // Increases the extra food multiplier to 1.75x.
                ResourcesManager.food_production_modifier *= 1.75F / 1.5F;
                break;
            case 29:
                // Increases the extra food multiplier to 2x.
                ResourcesManager.food_production_modifier *= 2F / 1.75F;
                break;
            case 30:
                // Enables the building of the children cookery building.
                Buildings.child_cookery.active = true;
                break;
            case 31:
                // Increases the extra food multiplier to 1.3x.
                Buildings.child_cookery.food_multiplier = 1.3F;
                break;
            case 32:
                // Increases the extra food multiplier to 1.5x.
                Buildings.child_cookery.food_multiplier = 1.5F;
                break;

            // Resources
            case 33:
                // Enables the use of emergency 24 hour shifts, but heavily decreases happyness when in use.
                Buildings.medical_tent.emergency_work = true;
                Buildings.hospital.emergency_work = true;
                Buildings.iron_mine.emergency_work = true;
                Buildings.coal_mine.emergency_work = true;
                Buildings.fishermans_hut.emergency_work = true;
                Buildings.apple_orchard.emergency_work = true;
                Buildings.science_lab.emergency_work = true;
                break;
            case 34:
                // Decreases the happyness penalty for the use of emergency/extended shifts.
                Residents.emergency_shift_happyness = -1;
                break;
            case 35:
                // Enables the use of extended 12 hour shifts, but decreases the happyness when in use.
                Buildings.medical_tent.extended_work = true;
                Buildings.hospital.extended_work = true;
                Buildings.iron_mine.extended_work = true;
                Buildings.coal_mine.extended_work = true;
                Buildings.fishermans_hut.extended_work = true;
                Buildings.apple_orchard.extended_work = true;
                Buildings.science_lab.extended_work = true;
                break;
            case 36:
                // Enables the use of children in resource workplaces, but heavily decreases happyness when in use.
                Buildings.iron_mine.child_work = true;
                Buildings.coal_mine.child_work = true;
                Buildings.fishermans_hut.child_work = true;
                Buildings.apple_orchard.child_work = true;
                break;
            case 37:
                // Increases the working efficiency of child workers.
            case 38:
                // Increases the working efficiency of child workers to match the adult workers.
                Buildings.iron_mine.children_efficiency += 0.25F;
                Buildings.coal_mine.children_efficiency += 0.25F;
                Buildings.fishermans_hut.children_efficiency += 0.25F;
                Buildings.apple_orchard.children_efficiency += 0.25F;
                break;
            case 39:
                // Activates the use of sick workers in workplaces, but decreases happyness when in use.
                Buildings.medical_tent.sick_efficiency = 0.5F;
                Buildings.hospital.sick_efficiency = 0.5F;
                Buildings.iron_mine.sick_efficiency = 0.5F;
                Buildings.coal_mine.sick_efficiency = 0.5F;
                Buildings.fishermans_hut.sick_efficiency = 0.5F;
                Buildings.apple_orchard.sick_efficiency = 0.5F;
                Buildings.child_cookery.sick_efficiency = 0.5F;
                Buildings.science_lab.sick_efficiency = 0.5F;
                break;
            case 40:
                // Increases the working efficiency of sick workers.
            case 41:
                // Increases the working efficiency of child workers to match the healthy workers.
                Buildings.medical_tent.sick_efficiency += 0.25F;
                Buildings.hospital.sick_efficiency += 0.25F;
                Buildings.iron_mine.sick_efficiency += 0.25F;
                Buildings.coal_mine.sick_efficiency += 0.25F;
                Buildings.fishermans_hut.sick_efficiency += 0.25F;
                Buildings.apple_orchard.sick_efficiency += 0.25F;
                Buildings.child_cookery.sick_efficiency += 0.25F;
                Buildings.science_lab.sick_efficiency += 0.25F;
                break;

            // Leading
            case 42:
                // Please the already happy residents, change the neutral state to being happy.
                game_controller.leader_type = 1;
                break;
            case 43:
                // Try to negotiate, change the sad state to being neutral.
                game_controller.leader_type = 2;
                break;
            case 44:
                // Massacre the protesters, disables protests but residents are always sad.
                game_controller.leader_type = 3;
                break;
        }
        Buildings.UpdateBuildings();
    }
}