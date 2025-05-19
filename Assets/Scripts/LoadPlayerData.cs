using UnityEngine;
using UnityEngine.Audio;

public class LoadPlayerData : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer effectsMixer;

    void Start(){
        GameOptions.LoadUserSettings();
        musicMixer.SetFloat("MusicVolume", GameOptions.music_volume);
        effectsMixer.SetFloat("EffectsVolume", GameOptions.effects_volume);
    }
}