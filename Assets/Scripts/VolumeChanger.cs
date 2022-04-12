using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeChanger : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Button mute;
    public TMP_Text warningText1;
    public TMP_Text warningText2;
    public Sprite mutedSprite;
    private Sprite unmutedSprite;
    private int isMainMuted;
    private int isMusicMuted;
    private int isEffectsMuted;
    public Button mainOn;
    public Button mainOff;
    public Button musicOn;
    public Button musicOff;
    public Button effectOn;
    public Button effectOff;

    void Start()
    {
        unmutedSprite = mute.GetComponent<Image>().sprite;
        isMainMuted = PlayerPrefs.GetInt("IsMainMuted");
        isMusicMuted = PlayerPrefs.GetInt("IsMusicMuted");
        isEffectsMuted = PlayerPrefs.GetInt("IsEffectsMuted");
        if (isMainMuted == 1) MuteMain();
        else if (isMainMuted == 0) UnmuteMain();
        if (isMusicMuted == 1) MuteMusic();
        else if (isMusicMuted == 0) UnmuteMusic();
        if (isEffectsMuted == 1) MuteEffects();
        else if (isEffectsMuted == 0) UnmuteEffects();
    }

    public void ToggleMuteMusic()
    {
        if (PlayerPrefs.GetInt("IsMainMuted") == 0) // is main muted is set to false
        {
            MuteMain();
            PlayerPrefs.SetInt("IsMainMuted", 1);
        }else if(PlayerPrefs.GetInt("IsMainMuted") == 1)
        {
            UnmuteMain();
            PlayerPrefs.SetInt("IsMainMuted", 0);
        }
    }

    public void TurnOnMain()
    {
        if (PlayerPrefs.GetInt("IsMainMuted") == 1)
        {
            UnmuteMain();
            PlayerPrefs.SetInt("IsMainMuted", 0);
        }
    }

    public void TurnOffMain()
    {
        if (PlayerPrefs.GetInt("IsMainMuted") == 0)
        {
            MuteMain();
            PlayerPrefs.SetInt("IsMainMuted", 1);
        }
    }

    public void TurnOnMusic()
    {
        if (PlayerPrefs.GetInt("IsMusicMuted") == 1)
        {
            UnmuteMusic();
            PlayerPrefs.SetInt("IsMusicMuted", 0);
        }
    }

    public void TurnOffMusic()
    {
        if (PlayerPrefs.GetInt("IsMusicMuted") == 0)
        {
            MuteMusic();
            PlayerPrefs.SetInt("IsMusicMuted", 1);
        }
    }

    public void TurnOnEffects()
    {
        if (PlayerPrefs.GetInt("isEffectsMuted") == 1)
        {
            UnmuteEffects();
            PlayerPrefs.SetInt("isEffectsMuted", 0);
        }
    }

    public void TurnOffEffects()
    {
        if (PlayerPrefs.GetInt("isEffectsMuted") == 0)
        {
            MuteEffects();
            PlayerPrefs.SetInt("isEffectsMuted", 1);
        }
    }

    public void MuteMain()
    {
        mainOn.interactable = true;
        mainOff.interactable = false;
        warningText1.gameObject.SetActive(true);
        warningText2.gameObject.SetActive(true);
        audioMixer.SetFloat("masterVolume", -80f);
        mute.GetComponent<Image>().sprite = mutedSprite;
    }

    public void UnmuteMain()
    {
        mainOn.interactable = false;
        mainOff.interactable = true;
        warningText1.gameObject.SetActive(false);
        warningText2.gameObject.SetActive(false);
        audioMixer.SetFloat("masterVolume", 0);
        mute.GetComponent<Image>().sprite = unmutedSprite;
    }

    public void MuteMusic()
    {
        musicOn.interactable = true;
        musicOff.interactable = false;
        audioMixer.SetFloat("musicVolume", -80f);
    }

    public void UnmuteMusic()
    {
        musicOn.interactable = false;
        musicOff.interactable = true;
        audioMixer.SetFloat("musicVolume", 0);
    }

    public void MuteEffects()
    {
        effectOn.interactable = true;
        effectOff.interactable = false;
        audioMixer.SetFloat("effectsVolume", -80f);
    }

    public void UnmuteEffects()
    {
        effectOn.interactable = false;
        effectOff.interactable = true;
        audioMixer.SetFloat("effectsVolume", 0);
    }
}
