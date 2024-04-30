using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ReadSaveSlotInfoInGame : MonoBehaviour
{
    [SerializeField]
    private Text _manual1_text;
    [SerializeField]
    private Text _manual2_text;
    [SerializeField]
    private Text _manual3_text;

    public void ReadSaveSlots(){
        SaveFileInfo[] save_file_infos = SaveController.ReadSaveFileInfo();

        string GetDifficulty(int difficulty){
            switch(difficulty){
                case 0:
                    return "custom";
                case 1:
                    return "easy";
                case 2:
                    return "normal";
                case 3:
                    return "hard";
                case 4:
                    return "extreme";
                default:
                    return "impossible";
            }
        }

        if(save_file_infos[1] == null){
            _manual1_text.text = "You don't have\n a manual save yet.";
        } else{
            _manual1_text.text = save_file_infos[1].timestamp + "\n" + save_file_infos[1].coordinate + ", " + GetDifficulty(save_file_infos[1].difficulty) + "\n" + save_file_infos[1].current_days + " days since THAT day";
        }
        if(save_file_infos[2] == null){
            _manual2_text.text = "You don't have\n a manual save yet.";
        } else{
            _manual2_text.text = save_file_infos[2].timestamp + "\n" + save_file_infos[2].coordinate + ", " + GetDifficulty(save_file_infos[2].difficulty) + "\n" + save_file_infos[2].current_days + " days since THAT day";
        }
        if(save_file_infos[3] == null){
            _manual3_text.text = "You don't have\n a manual save yet.";
        } else{
            _manual3_text.text = save_file_infos[3].timestamp + "\n" + save_file_infos[3].coordinate + ", " + GetDifficulty(save_file_infos[3].difficulty) + "\n" + save_file_infos[3].current_days + " days since THAT day";
        }
    }
}