using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
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
    [SerializeField]
    private Image _sync_button;
    [SerializeField]
    private GameObject _settings_group;
    [SerializeField]
    private GameObject _login_button;
    public AudioMixer music_mixer;
    public AudioMixer effects_mixer;
    public UnityAuthentication unity_auth;
    public ReadSaveSlotInfo read_save_slot_info;
    void Start()
    {
        read_save_slot_info.ReadSaveSlots();
        _music_volume_text.text = "Music volume: " + (int)((GameOptions.music_volume + 80) * 1.25);
        _music_volume_slider.value = GameOptions.music_volume;
        _effects_volume_text.text = "Effects volume: " + (int)((GameOptions.effects_volume + 80) * 1.25);
        _effects_volume_slider.value = GameOptions.effects_volume;
        _autosave_frequency_text.text = "Autosave frequency:\n" + GameOptions.autosave_frequency + " hours";
        _autosave_frequency_slider.value = GameOptions.autosave_frequency;
        DisableSyncButton();
    }

    public void SaveUserSettings()
    {
        GameOptions.SaveUserSettings();
    }

    public void setMusicVolume(float volume)
    {
        GameOptions.music_volume = (int)volume;
        music_mixer.SetFloat("MusicVolume", volume);
        _music_volume_text.text = "Music volume: " + (int)((volume + 80) * 1.25);
    }
    public void setEffectsVolume(float volume)
    {
        GameOptions.effects_volume = (int)volume;
        effects_mixer.SetFloat("EffectsVolume", volume);
        _effects_volume_text.text = "Effects volume: " + (int)((volume + 80) * 1.25);
    }
    public void setAutosaveFrequency(float frequency)
    {
        GameOptions.autosave_frequency = (int)frequency;
        _autosave_frequency_text.text = "Autosave frequency:\n" + frequency + " hours";
    }

    public async void Login()
    {
        await unity_auth.InitSignIn();
    }
    public void LoadSaveSlot(int slot)
    {
        SaveController.LoadGameData(slot);
    }

    public void UploadSaveFiles()
    {
        SaveController.UploadSaveFiles();
    }

    public void DownloadSaveFiles()
    {
        SaveController.DownloadSaveFiles(read_save_slot_info);
    }

    public void HideLoginButton()
    {
        if (unity_auth.IsSignedIn())
        {
            _login_button.SetActive(false);
        }
        else
        {
            _login_button.SetActive(true);
        }
    }

        public void DisableSyncButton()
    {
        if (unity_auth.IsSignedIn())
        {
            _sync_button.color = Color.black;
            _sync_button.transform.GetComponent<Button>().interactable = true;
        }
        else
        {
            _sync_button.color = Color.red;
            _sync_button.transform.GetComponent<Button>().interactable = false;
        }
    }
}