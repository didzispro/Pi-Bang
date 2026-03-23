using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioSource[] sfxSources;

    void Start()
    {

        float savedMaster = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);

        masterSlider.value = savedMaster;
        sfxSlider.value = savedSFX;

        AudioListener.volume = savedMaster;
        
        foreach (AudioSource source in sfxSources)
        {
            source.volume = savedSFX;
        }
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        
        titleScreen.SetActive(false);
        playButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);

        titleScreen.SetActive(true);
        playButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        foreach (AudioSource source in sfxSources)
        {
            source.volume = volume;
        }
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
}