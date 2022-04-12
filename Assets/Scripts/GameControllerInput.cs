using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControllerInput : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField input;
    public Slider timer;
    public string correctAnswer;
    private float remainingTime;
    public GameObject winScreen;
    public Image[] stars;
    public Sprite greyStar;
    public TMP_Text winText;
    //public TMP_Text scoreText;
    //public static bool[] isPlayed = new bool[65];
    public static int totalStars;
    public int currentLevel;
    public static float score;
    public static float totalScore;
    public AudioSource source; // Assign in editor/etc

    public void GetInput(string answer)
    {
        answer = input.text.ToLower();
        remainingTime = timer.value * 10;

        if (answer == correctAnswer)
        {
            score = remainingTime * 100;
            //scoreText.text = "SCORE: " + score.ToString("F0");
            source.volume = 0;
            winScreen.SetActive(true);
            SliderChanger.pauseTimer = true;
            if (StarsHandler.noOfStars == 1)
            {
                winText.text = "GOOD! ";
                stars[1].sprite = greyStar;
                stars[2].sprite = greyStar;
            }
            else if (StarsHandler.noOfStars == 2)
            {
                winText.text = "NICE JOB! ";
                stars[2].sprite = greyStar;
            }
            else if (StarsHandler.noOfStars == 3)
            {
                winText.text = "PERFECT! ";
            }
            if (!IsPlayed())
            {
                PlayerPrefs.SetInt("finishedLevels", currentLevel);
                Debug.Log("This level has not been played before");
                totalStars = PlayerPrefs.GetInt("totalStars");
                totalStars += StarsHandler.noOfStars;
                totalScore = PlayerPrefs.GetFloat("totalScore");
                totalScore += score;
                PlayerPrefs.SetInt("totalStars", totalStars);
                PlayerPrefs.SetFloat("totalScore", totalScore);
            }
            else
            {
                Debug.Log("This level has been played before");
            }
            winText.text += "SCORE: " + score.ToString("F0");
            Debug.Log("Congrats! Remaining time " + remainingTime + " No of stars: " + StarsHandler.noOfStars);
            Debug.Log("Total No Of Stars: " + PlayerPrefs.GetInt("totalStars"));
            Debug.Log("Total Score: " + PlayerPrefs.GetFloat("totalScore"));
        }
        else
        {
            Debug.Log("Try Again!");
        }

        input.text = "";
    }

    private bool IsPlayed()
    {
        if (PlayerPrefs.GetInt("finishedLevels") < currentLevel)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}