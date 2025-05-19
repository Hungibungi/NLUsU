using UnityEngine;
using UnityEngine.UI;

public class ScoutingNode
{
    public float rngType;
    public float workers;
    public float children;
    public float food;
    public float building_material;
    public float iron;
    public float rng_success;
    public int hours_to_complete;
    public string[] descriptions = new string[5];
    public Sprite[] icons = new Sprite[5];
    public string used_description;
    public bool visited;
    public Sprite icon;
    public int rngEvent;

    public ScoutingNode(){
        visited = false;
        rngType = UnityEngine.Random.Range(0, 100);
        switch(rngType){
            case <= 60:
                workers = 0;
                children = 0;
                food = 125 * UnityEngine.Random.Range(0, 1000) / 1000;
                building_material = 250 * UnityEngine.Random.Range(0, 1000) / 1000;
                iron = 125 * UnityEngine.Random.Range(0, 1000) / 1000;
                rng_success = 1F;
                hours_to_complete = (int)((food / 125 + building_material / 250 + iron / 125) / 3 * 48);
                descriptions[0] = "An abandoned old town. There's no-one to be seen.";
                descriptions[1] = "An ever-burning town. Everyone seems to have crisped away...";
                descriptions[2] = "A huge graveyard with a skeleton. It's unfortunate to be the last one.";
                descriptions[3] = "A lighthouse near the old shoreline. There's no one around anymore.";
                descriptions[4] = "A truck with some bones. Hope their destination is alright...";
                icons[0] = Sprites.abandoned_town;
                icons[1] = Sprites.burning_town;
                icons[2] = Sprites.graveyard;
                icons[3] = Sprites.lighthouse;
                icons[4] = Sprites.truck_bones;
                rngEvent=(int)UnityEngine.Random.Range(0, 4.999F);
                used_description = descriptions[rngEvent];
                icon = icons[rngEvent];
                break;
            case <= 90:
                workers = 20 * UnityEngine.Random.Range(0, 20) / 20;
                children = 10 * UnityEngine.Random.Range(0, 10) / 10;
                food = 0;
                building_material = 0;
                iron = 0;
                rng_success = 1F;
                hours_to_complete = (int)((workers / 20 + children / 10) / 2 * 48);
                descriptions[0]= "Smoke is coming from here, but there are no buildings in sight.";
                descriptions[1]= "And old church. Surprisingly, movement can be seen inside.";
                descriptions[2]= "An entrance to an underground city with a huge HELP sign.";
                icons[0] = Sprites.smoke;
                icons[1] = Sprites.old_church;
                icons[2] = Sprites.help_city;
                rngEvent=(int)UnityEngine.Random.Range(0, 2.999F);
                used_description = descriptions[rngEvent];
                icon = icons[rngEvent];
                break;
            case < 99:
                workers = 40 * UnityEngine.Random.Range(0, 40) / 40;
                children = 20 * UnityEngine.Random.Range(0, 20) / 20;
                food = 250 * UnityEngine.Random.Range(0, 1000) / 1000;
                building_material = 500 * UnityEngine.Random.Range(0, 1000) / 1000;
                iron = 250 * UnityEngine.Random.Range(0, 1000) / 1000;
                rng_success = 0.33F;
                hours_to_complete = (int)((food / 250 + building_material / 500 + iron / 250 + workers / 40 + children / 20) / 5 * 96);
                used_description = "A barely functional underground city with civil unrest.";
                icon = Sprites.sad_city;
                break;
            case >= 99:
                workers = 80 * UnityEngine.Random.Range(40, 80) / 80;
                children = 40 * UnityEngine.Random.Range(20, 40) / 40;
                food = 500 * UnityEngine.Random.Range(500, 1000) / 1000;
                building_material = 1000 * UnityEngine.Random.Range(500, 1000) / 1000;
                iron = 500 * UnityEngine.Random.Range(500, 1000) / 1000;
                rng_success = 0.67F;
                hours_to_complete = (int)((food / 500 + building_material / 1000 + iron / 500 + workers / 80 + children / 40) / 5 * 192);
                used_description = "A small underground city with stable economy and happy people.";
                icon = Sprites.happy_city;
                break;
        }
    }
}

public static class Scouting
{
    public static int[] carried_workers = new int[4];
    public static int[] carried_children = new int[4];
    public static int[] carried_food = new int[4];
    public static int[] carried_building_material = new int[4];
    public static int[] carried_iron = new int[4];
    public static bool[] direction = new bool[4];
    public static bool[] storm_direction = new bool[4];
    public static ScoutingNode[][] nodes = new ScoutingNode[4][];
    public static int[] current_location = new int[4];
    public static bool[] traveling = new bool[4];
    public static int[] finish_travel = new int[4];
    private static int temp_time = 0;

    public static void ResetScouting(GameController game_controller){
        for(int i = 0; i < 4; i++){
            direction[i] = false;
            storm_direction[i] = false;
            traveling[i] = false;
            carried_workers[i] = 0;
            carried_children[i] = 0;
            carried_food[i] = 0;
            carried_building_material[i] = 0;
            carried_iron[i] = 0;
            finish_travel[i] = 0;
            current_location[i] = -1;
        }
        StormReset(game_controller);
    }

    public static void StormReset(GameController game_controller){
        for(int i = 0; i < 4; i++){
            direction[i] = false;
        }
        game_controller._scouting_menu.GetComponent<Image>().color = Color.black;
        int[] possible_counts = { 6, 9, 12 };
        for(int i = 0;i<4;i++){
            nodes[i] = new ScoutingNode[possible_counts[(int)UnityEngine.Random.Range(0, 2.999F)]];
            current_location[i] = -1;
        }
        GenerateNodes();
    }

    public static void EndStorm(){
        for(int i = 0; i < 4; i++){
            direction[i] = storm_direction[i];
        }
    }

    private static void GenerateNodes(){
        for(int i = 0;i<4;i++){
            for(int j = 0;j<nodes[i].Length;j++){
                nodes[i][j] = new ScoutingNode();
            }
        }
    }

    public static void ChangeScoutingDisplayed(int page, GameController game_controller){
        game_controller._scouting_1_1.SetActive(false);
        game_controller._scouting_2_1.SetActive(false);
        game_controller._scouting_2_1.GetComponent<Button>().interactable = false;
        game_controller._scouting_2_2.SetActive(false);
        game_controller._scouting_2_2.GetComponent<Button>().interactable = false;
        game_controller._scouting_2_3.SetActive(false);
        game_controller._scouting_2_3.GetComponent<Button>().interactable = false;
        game_controller._scouting_2_4.SetActive(false);
        game_controller._scouting_2_4.GetComponent<Button>().interactable = false;
        game_controller._scouting_2_5.SetActive(false);
        game_controller._scouting_2_5.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_3_1.SetActive(false);
        game_controller._scouting_3_1.SetActive(false);
        game_controller._scouting_3_1.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_3_2.SetActive(false);
        game_controller._scouting_3_2.SetActive(false);
        game_controller._scouting_3_2.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_3_3.SetActive(false);
        game_controller._scouting_3_3.SetActive(false);
        game_controller._scouting_3_3.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_3_4.SetActive(false);
        game_controller._scouting_3_4.SetActive(false);
        game_controller._scouting_3_4.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_3_5.SetActive(false);
        game_controller._scouting_3_5.SetActive(false);
        game_controller._scouting_3_5.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_4_1.SetActive(false);
        game_controller._scouting_4_1.SetActive(false);
        game_controller._scouting_4_1.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_4_2.SetActive(false);
        game_controller._scouting_4_2.SetActive(false);
        game_controller._scouting_4_2.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_4_3.SetActive(false);
        game_controller._scouting_4_3.SetActive(false);
        game_controller._scouting_4_3.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_4_4.SetActive(false);
        game_controller._scouting_4_4.SetActive(false);
        game_controller._scouting_4_4.GetComponent<Button>().interactable = false;
        game_controller._scouting_next_4_5.SetActive(false);
        game_controller._scouting_4_5.SetActive(false);
        game_controller._scouting_4_5.GetComponent<Button>().interactable = false;

        switch(nodes[page].Length){
            case 6:
                if(direction[page]){
                    game_controller._scouting_1_1.SetActive(true);
                    game_controller._scouting_1_1.GetComponent<Image>().sprite = Sprites.apartment_logo;
                    game_controller._scouting_2_2.SetActive(true);
                    game_controller._scouting_2_2.GetComponent<Image>().sprite = nodes[page][0].icon;
                    if(!nodes[page][0].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_2.GetComponent<Button>().interactable = true;
                    }
                    game_controller._scouting_2_4.SetActive(true);
                    game_controller._scouting_2_4.GetComponent<Image>().sprite = nodes[page][3].icon;
                    if(!nodes[page][3].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_4.GetComponent<Button>().interactable = true;
                    }
                    if(nodes[page][0].visited){
                        game_controller._scouting_next_3_2.SetActive(true);
                        game_controller._scouting_3_2.SetActive(true);
                        game_controller._scouting_3_2.GetComponent<Image>().sprite = nodes[page][1].icon;
                        if(!nodes[page][1].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_2.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][3].visited){
                        game_controller._scouting_next_3_4.SetActive(true);
                        game_controller._scouting_3_4.SetActive(true);
                        game_controller._scouting_3_4.GetComponent<Image>().sprite = nodes[page][4].icon;
                        if(!nodes[page][4].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_4.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][1].visited){
                        game_controller._scouting_next_4_2.SetActive(true);
                        game_controller._scouting_4_2.SetActive(true);
                        game_controller._scouting_4_2.GetComponent<Image>().sprite = nodes[page][2].icon;
                        if(!nodes[page][2].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_2.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][4].visited){
                        game_controller._scouting_next_4_4.SetActive(true);
                        game_controller._scouting_4_4.SetActive(true);
                        game_controller._scouting_4_4.GetComponent<Image>().sprite = nodes[page][5].icon;
                        if(!nodes[page][5].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_4.GetComponent<Button>().interactable = true;
                        }
                    }
                }
                break;
            case 9:
                if(direction[page]){
                    game_controller._scouting_1_1.SetActive(true);
                    game_controller._scouting_1_1.GetComponent<Image>().sprite = Sprites.apartment_logo;
                    game_controller._scouting_2_1.SetActive(true);
                    game_controller._scouting_2_1.GetComponent<Image>().sprite = nodes[page][0].icon;
                    if(!nodes[page][0].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_1.GetComponent<Button>().interactable = true;
                    }
                    game_controller._scouting_2_3.SetActive(true);
                    game_controller._scouting_2_3.GetComponent<Image>().sprite = nodes[page][3].icon;
                    if(!nodes[page][3].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_3.GetComponent<Button>().interactable = true;
                    }
                    game_controller._scouting_2_5.SetActive(true);
                    game_controller._scouting_2_5.GetComponent<Image>().sprite = nodes[page][6].icon;
                    if(!nodes[page][6].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_5.GetComponent<Button>().interactable = true;
                    }
                    if(nodes[page][0].visited){
                        game_controller._scouting_next_3_1.SetActive(true);
                        game_controller._scouting_3_1.SetActive(true);
                        game_controller._scouting_3_1.GetComponent<Image>().sprite = nodes[page][1].icon;
                        if(!nodes[page][1].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_1.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][3].visited){
                        game_controller._scouting_next_3_3.SetActive(true);
                        game_controller._scouting_3_3.SetActive(true);
                        game_controller._scouting_3_3.GetComponent<Image>().sprite = nodes[page][4].icon;
                        if(!nodes[page][4].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_3.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][6].visited){
                        game_controller._scouting_next_3_5.SetActive(true);
                        game_controller._scouting_3_5.SetActive(true);
                        game_controller._scouting_3_5.GetComponent<Image>().sprite = nodes[page][7].icon;
                        if(!nodes[page][7].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_5.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][1].visited){
                        game_controller._scouting_next_4_1.SetActive(true);
                        game_controller._scouting_4_1.SetActive(true);
                        game_controller._scouting_4_1.GetComponent<Image>().sprite = nodes[page][2].icon;
                        if(!nodes[page][2].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_1.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][4].visited){
                        game_controller._scouting_next_4_3.SetActive(true);
                        game_controller._scouting_4_3.SetActive(true);
                        game_controller._scouting_4_3.GetComponent<Image>().sprite = nodes[page][5].icon;
                        if(!nodes[page][5].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_3.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][7].visited){
                        game_controller._scouting_next_4_5.SetActive(true);
                        game_controller._scouting_4_5.SetActive(true);
                        game_controller._scouting_4_5.GetComponent<Image>().sprite = nodes[page][8].icon;
                        if(!nodes[page][8].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_5.GetComponent<Button>().interactable = true;
                        }
                    }
                }
                break;
            case 12:
                if(direction[page]){
                    game_controller._scouting_1_1.SetActive(true);
                    game_controller._scouting_1_1.GetComponent<Image>().sprite = Sprites.apartment_logo;
                    game_controller._scouting_2_1.SetActive(true);
                    game_controller._scouting_2_1.GetComponent<Image>().sprite = nodes[page][0].icon;
                    if(!nodes[page][0].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_1.GetComponent<Button>().interactable = true;
                    }
                    game_controller._scouting_2_2.SetActive(true);
                    game_controller._scouting_2_2.GetComponent<Image>().sprite = nodes[page][3].icon;
                    if(!nodes[page][3].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_2.GetComponent<Button>().interactable = true;
                    }
                    game_controller._scouting_2_4.SetActive(true);
                    game_controller._scouting_2_4.GetComponent<Image>().sprite = nodes[page][6].icon;
                    if(!nodes[page][6].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_4.GetComponent<Button>().interactable = true;
                    }
                    game_controller._scouting_2_5.SetActive(true);
                    game_controller._scouting_2_5.GetComponent<Image>().sprite = nodes[page][9].icon;
                    if(!nodes[page][9].visited && !traveling[game_controller.open_scouting_tab]){
                        game_controller._scouting_2_5.GetComponent<Button>().interactable = true;
                    }
                    if(nodes[page][0].visited){
                        game_controller._scouting_next_3_1.SetActive(true);
                        game_controller._scouting_3_1.SetActive(true);
                        game_controller._scouting_3_1.GetComponent<Image>().sprite = nodes[page][1].icon;
                        if(!nodes[page][1].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_1.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][3].visited){
                        game_controller._scouting_next_3_2.SetActive(true);
                        game_controller._scouting_3_2.SetActive(true);
                        game_controller._scouting_3_2.GetComponent<Image>().sprite = nodes[page][4].icon;
                        if(!nodes[page][4].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_2.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][6].visited){
                        game_controller._scouting_next_3_4.SetActive(true);
                        game_controller._scouting_3_4.SetActive(true);
                        game_controller._scouting_3_4.GetComponent<Image>().sprite = nodes[page][7].icon;
                        if(!nodes[page][7].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_4.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][9].visited){
                        game_controller._scouting_next_3_5.SetActive(true);
                        game_controller._scouting_3_5.SetActive(true);
                        game_controller._scouting_3_5.GetComponent<Image>().sprite = nodes[page][10].icon;
                        if(!nodes[page][10].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_3_5.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][1].visited){
                        game_controller._scouting_next_4_1.SetActive(true);
                        game_controller._scouting_4_1.SetActive(true);
                        game_controller._scouting_4_1.GetComponent<Image>().sprite = nodes[page][2].icon;
                        if(!nodes[page][2].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_1.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][4].visited){
                        game_controller._scouting_next_4_2.SetActive(true);
                        game_controller._scouting_4_2.SetActive(true);
                        game_controller._scouting_4_2.GetComponent<Image>().sprite = nodes[page][5].icon;
                        if(!nodes[page][5].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_2.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][7].visited){
                        game_controller._scouting_next_4_4.SetActive(true);
                        game_controller._scouting_4_4.SetActive(true);
                        game_controller._scouting_4_4.GetComponent<Image>().sprite = nodes[page][8].icon;
                        if(!nodes[page][8].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_4.GetComponent<Button>().interactable = true;
                        }
                    }
                    if(nodes[page][10].visited){
                        game_controller._scouting_next_4_5.SetActive(true);
                        game_controller._scouting_4_5.SetActive(true);
                        game_controller._scouting_4_5.GetComponent<Image>().sprite = nodes[page][11].icon;
                        if(!nodes[page][11].visited && !traveling[game_controller.open_scouting_tab]){
                            game_controller._scouting_4_5.GetComponent<Button>().interactable = true;
                        }
                    }
                }
                break;
        }
    }
    public static int SetOpenScouting(int id, GameController game_controller){
        int open_scouting = 0;
        switch(nodes[game_controller.open_scouting_tab].Length){
            case 6:
                open_scouting = id==11?-1:open_scouting;
                open_scouting = id==22?0:open_scouting;
                open_scouting = id==24?3:open_scouting;
                open_scouting = id==32?1:open_scouting;
                open_scouting = id==34?4:open_scouting;
                open_scouting = id==42?2:open_scouting;
                open_scouting = id==44?5:open_scouting;
                break;
            case 9:
                open_scouting = id==11?-1:open_scouting;
                open_scouting = id==21?0:open_scouting;
                open_scouting = id==23?3:open_scouting;
                open_scouting = id==25?6:open_scouting;
                open_scouting = id==31?1:open_scouting;
                open_scouting = id==33?4:open_scouting;
                open_scouting = id==35?7:open_scouting;
                open_scouting = id==41?2:open_scouting;
                open_scouting = id==43?5:open_scouting;
                open_scouting = id==45?8:open_scouting;
                break;
            case 12:
                open_scouting = id==11?-1:open_scouting;
                open_scouting = id==21?0:open_scouting;
                open_scouting = id==22?3:open_scouting;
                open_scouting = id==24?6:open_scouting;
                open_scouting = id==25?9:open_scouting;
                open_scouting = id==31?1:open_scouting;
                open_scouting = id==32?4:open_scouting;
                open_scouting = id==34?7:open_scouting;
                open_scouting = id==35?10:open_scouting;
                open_scouting = id==41?2:open_scouting;
                open_scouting = id==42?5:open_scouting;
                open_scouting = id==44?8:open_scouting;
                open_scouting = id==45?11:open_scouting;
                break;
        }
        game_controller._scouting_time.text = CalculateTravelTime(game_controller, open_scouting).ToString() + " hours to reach target";
        if(open_scouting == -1){
            game_controller._scouting_description.text = "Your base of operations."; 
        } else{
            game_controller._scouting_description.text = nodes[game_controller.open_scouting_tab][open_scouting].used_description;
        }
        return open_scouting;
    }

    private static int CalculateTravelTime(GameController game_controller, int id){
        int travel_time = 0;
        int current_node = current_location[game_controller.open_scouting_tab]==-1?-1:(current_location[game_controller.open_scouting_tab] + 1) % 3;
        current_node = current_node==0?3:current_node;
        int current_track = current_location[game_controller.open_scouting_tab]==-1?0:current_location[game_controller.open_scouting_tab] / 3 + 1;
        int track_to_reach = id==-1?0:id / 3 + 1;
        int node_to_reach = id==-1?-1:(id + 1) % 3;
        node_to_reach = node_to_reach==0?3:node_to_reach;
        if(current_node != node_to_reach || current_track != track_to_reach){
            if(node_to_reach == -1){
                for(int i = 0; i < current_node; i++){
                    travel_time += nodes[game_controller.open_scouting_tab][current_location[game_controller.open_scouting_tab] - i].hours_to_complete / 2;
                }
            }
            else if(current_track == track_to_reach){
                travel_time = nodes[game_controller.open_scouting_tab][id].hours_to_complete;
            } else{
                if(current_node != -1){
                    for(int i = 0; i < current_node; i++){
                        travel_time += nodes[game_controller.open_scouting_tab][current_location[game_controller.open_scouting_tab] - i].hours_to_complete / 2;
                    }
                }
                for(int i = 0; i < node_to_reach; i++){
                    if(nodes[game_controller.open_scouting_tab][3 * (track_to_reach - 1) + i].visited){
                        travel_time += nodes[game_controller.open_scouting_tab][3 * (track_to_reach - 1) + i].hours_to_complete / 2;
                    } else{
                        travel_time += nodes[game_controller.open_scouting_tab][3 * (track_to_reach - 1) + i].hours_to_complete;
                    }
                }
            }
        }
        temp_time = travel_time;
        return travel_time;
    }

    public static void StartScouting(GameController game_controller, int id){
        current_location[game_controller.open_scouting_tab] = id;
        traveling[game_controller.open_scouting_tab] = true;
        finish_travel[game_controller.open_scouting_tab] = temp_time + game_controller.elapsed_hours;
        ChangeScoutingDisplayed(game_controller.open_scouting_tab, game_controller);
    }

    public static bool IsScoutReady(){
        bool north = direction[0] && !traveling[0];
        bool east = direction[1] && !traveling[1];
        bool south = direction[2] && !traveling[2];
        bool west = direction[3] && !traveling[3];
        return north || east || south || west;
    }

    public static void LootResources(int direction){
        ScoutingNode node = nodes[direction][current_location[direction]];
        int current_sum = carried_food[direction] + carried_building_material[direction] + carried_iron[direction];
        int loot_sum = (int)node.food + (int)node.building_material + (int)node.iron;
        float penalty = 1;
        if(current_sum + loot_sum > Buildings.scout_station.carrying_capacity){
            penalty = Buildings.scout_station.carrying_capacity / (current_sum + loot_sum);
        }
        carried_workers[direction] += (int) node.workers;
        carried_children[direction] += (int) node.children;
        carried_food[direction] += (int) (node.food * penalty);
        carried_building_material[direction] += (int) (node.building_material * penalty);
        carried_iron[direction] += (int) (node.iron * penalty);
    }

    public static void DepositLoot(int direction){
        Residents.AddResidents(carried_workers[direction], carried_children[direction]);
        ResourcesManager.food += carried_food[direction];
        ResourcesManager.building_material += carried_building_material[direction];
        ResourcesManager.iron += carried_iron[direction];

        carried_workers[direction] = 0;
        carried_children[direction] = 0;
        carried_food[direction] = 0;
        carried_building_material[direction] = 0;
        carried_iron[direction] = 0;
    }
}