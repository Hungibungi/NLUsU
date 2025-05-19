using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsIngame : MonoBehaviour
{
    [SerializeField]
    private Text _music_volume_text;
    [SerializeField]
    private Slider _music_volume_slider;
    [SerializeField]
    private Text _effects_volume_text;
    [SerializeField]
    private Slider _effects_volume_slider;
    [SerializeField]
    private Text _autosave_frequency_text;
    [SerializeField]
    private Slider _autosave_frequency_slider;
    public AudioMixer music_mixer;
    public AudioMixer effects_mixer;
    public ReadSaveSlotInfoInGame read_save_slot_info;

    void Start(){
        _music_volume_text.text = "Music volume: " + (int)((GameOptions.music_volume + 80) * 1.25);
        _music_volume_slider.value = GameOptions.music_volume;
        _effects_volume_text.text = "Effects volume: " + (int)((GameOptions.effects_volume + 80) * 1.25);
        _effects_volume_slider.value = GameOptions.effects_volume;
        _autosave_frequency_text.text = "Save every " + GameOptions.autosave_frequency + " hours";
        _autosave_frequency_slider.value = GameOptions.autosave_frequency;
        read_save_slot_info.ReadSaveSlots();
    }

    public void SaveUserSettings(){
        GameOptions.SaveUserSettings();
    }

    public void setMusicVolume(float volume) {
        GameOptions.music_volume = (int)volume;
        music_mixer.SetFloat("MusicVolume", volume);
        _music_volume_text.text = "Music volume: " + (int)((volume + 80) * 1.25);
    }
     public void setEffectsVolume(float volume) {
        GameOptions.effects_volume = (int)volume;
        effects_mixer.SetFloat("EffectsVolume", volume);
        _effects_volume_text.text = "Effects volume: " + (int)((volume + 80) * 1.25);
    }
    public void setAutosaveFrequency(float frequency) {
        GameOptions.autosave_frequency = (int)frequency;
        _autosave_frequency_text.text = "Save every " + (int)frequency + " hours";
    }
}