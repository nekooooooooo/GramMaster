using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControllerButtons : MonoBehaviour
{

    [SerializeField]
    public Slider timer;
    public string correctAnswer;
    private float remainingTime;
    public GameObject winScreen;
    public GameObject loseScreen;
    public Image[] stars;
    public Sprite greyStar;
    public TMP_Text winText;
    public TMP_Text loseText;
    //public static bool[] isPlayed = new bool[65];
    public static int totalStars;
    public int currentLevel;
    public static float score;
    public static float totalScore;
    public AudioSource source; // Assign in editor/etc

    void Start()
    {

    }

    public void GetText(string answer)
    {

        remainingTime = timer.value * 10;

        if (answer == correctAnswer)
        {
            score = remainingTime * 100;
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
            source.volume = 0;
            SliderChanger.pauseTimer = true;
            loseText.text = "You picked the wrong answer. Try Again!";
            loseScreen.SetActive(true);
            Debug.Log("Try Again!");
        }
        //GetStars(StarsHandler.noOfStars);
    }

    /*void GetStars(int noOfStars)
    {
        if (!isPlayed[currentLevel])
        {
            Debug.Log("This level has not been played before");
            totalStars = PlayerPrefs.GetInt("totalStars");
            totalStars += noOfStars;
            PlayerPrefs.SetInt("totalStars", totalStars);
            isPlayed[currentLevel] = true;
        }
        else
        {
            Debug.Log("This level has been played before");
        }
        Debug.Log("No Of Stars: " + PlayerPrefs.GetInt("totalStars"));
    }*/

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