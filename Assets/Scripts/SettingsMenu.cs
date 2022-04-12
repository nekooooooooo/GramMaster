using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider mainSlider;
    public Slider musicSlider;
    public Slider soundEffectSlider;
    public Button mute;
    public Sprite muteSprite;


    void Start()
    {
        mainSlider.value = PlayerPrefs.GetFloat("MainVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume", 1f);
    }

    public void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MainVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("effectsVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundEffectVolume", volume);
    }

    public void MuteMusic(float volume)
    {
        audioMixer.SetFloat("masterVolume", -80);
        PlayerPrefs.SetFloat("SoundEffectVolume", volume);
        if(PlayerPrefs.GetInt("IsMuted") == 0)
        {
            PlayerPrefs.SetInt("IsMuted", 1);
        }
    }
}
