using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider musicVolSlider, effectsVolSlidert;

    public CanvasGroup optionsMenu, nonOptionsMenu;

    private void Start()
    {
        setSettings();
    }

    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicParam", volume);
        PlayerPrefs.SetFloat("MusicParam", volume);
    }

    public void setEffectsVolume(float volume)
    {
        audioMixer.SetFloat("EffectsParam", volume);
        PlayerPrefs.SetFloat("EffectsParam", volume);
    }

    void setSettings()
    {
        musicVolSlider.value = PlayerPrefs.GetFloat("MusicParam");
        effectsVolSlidert.value = PlayerPrefs.GetFloat("EffectsParam");
        
        audioMixer.SetFloat("MusicParam", musicVolSlider.value);
        audioMixer.SetFloat("EffectsParam", effectsVolSlidert.value);
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();

        optionsMenu.alpha = 0;
        optionsMenu.interactable = false;
        optionsMenu.blocksRaycasts = false;

        nonOptionsMenu.alpha = 1;
        nonOptionsMenu.interactable = true;
        nonOptionsMenu.blocksRaycasts = true;
    }




}
