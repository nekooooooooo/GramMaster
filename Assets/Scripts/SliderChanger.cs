using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderChanger : MonoBehaviour
{

    public GameObject menu;
    public static bool pauseTimer;
    public static float timeRemaining;
    public TextMeshProUGUI progressText;
    public static float timerMax;
    private float temp;
    public Slider slider;
    public AudioSource source;
    public enum Difficulty { easy, medium, hard };
    public Difficulty difficulty;

    void Start()
    {
        if (difficulty == Difficulty.easy)
        {
            timerMax = 61;
            timeRemaining = 61;
        } else if (difficulty == Difficulty.medium) {
            timerMax = 46;
            timeRemaining = 46;
        } else if (difficulty == Difficulty.hard)
        {
            timerMax = 31;
            timeRemaining = 31;
        }
        pauseTimer = false;
    }

    // Update is called once per frame
    void Update()
    {

        slider.value = CalculateSliderValue();
        progressText.text = (timeRemaining).ToString("F0") + "s";

        if (timeRemaining <= 0)
        {
            source.volume = 0;
            menu.SetActive(true);
            Debug.Log("You Lose");
        }
        if (timeRemaining > 0)
        {
            if(!pauseTimer)
            timeRemaining -= Time.deltaTime;
        }

    }

    float CalculateSliderValue()
    {
        return (timeRemaining / timerMax);
    }

}
