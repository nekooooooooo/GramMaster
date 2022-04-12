using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class GameManagerDragDrop : MonoBehaviour
{

    public GameObject countdown;
    public TMP_Text countdownText;

    public Slider timer;
    private float remainingTime;
    public GameObject winScreen;
    public Image[] stars;
    public Sprite greyStar;
    public TMP_Text winText;
    public TMP_Text correctText;
    public TMP_Text wrongText;
    public TMP_Text answerText;
    public static int totalStars;
    public int currentLevel;
    public static float score;
    public static float totalScore;
    public AudioSource source; // Assign in editor/etc

    public int questionsNeeded;
    public Questions[] questions;
    public static List<Questions> unansweredQuestions;

    private Questions currentQuestion;

    [SerializeField]
    private TMP_Text questionText;
    [SerializeField]
    private TMP_Text[] choiceText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    void Start()
    {
        unansweredQuestions = new List<Questions>();
        unansweredQuestions.Clear();
        StartCoroutine(Countdown(3));
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Questions>();
        }

        SetCurrentQuestion();
        
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        while (count > 0)
        {
            SliderChanger.pauseTimer = true;
            countdown.SetActive(true);
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }
        SliderChanger.pauseTimer = false;
        countdown.SetActive(false);
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;
        if (currentQuestion.choices.Length != 0)
        {
            for(int i = 0; i < currentQuestion.choices.Length; i++) {
                choiceText[i].text = currentQuestion.choices[i].ToUpper();
            }
        }
        
    }

    IEnumerator TransitionToNextQuestion()
    {
        if(unansweredQuestions.Count != 0 || unansweredQuestions != null) { 
            unansweredQuestions.Remove(currentQuestion);
            questionsNeeded--;
            SliderChanger.pauseTimer = true;
            yield return new WaitForSeconds(timeBetweenQuestions);
            SliderChanger.pauseTimer = false;
            answerText.text = "";
            SetCurrentQuestion();
        }
    }

    private IEnumerator ShowWrongText(float duration)
    {
        wrongText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        wrongText.gameObject.SetActive(false);
    }

    private IEnumerator ShowCorrectText(float duration)
    {
        correctText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        correctText.gameObject.SetActive(false);
    }


    public void GetText()
    {
        string answer = DragDrop.answer.ToLower();
        wrongText.gameObject.SetActive(false);
        correctText.gameObject.SetActive(false);
        remainingTime = timer.value * 10;
        if (currentQuestion.answer == answer)
        {
            StartCoroutine(ShowCorrectText(1f));
            StartCoroutine(TransitionToNextQuestion());
            if (unansweredQuestions == null || questionsNeeded == 0) {
                score = remainingTime * 100;
                source.volume = 0;
                winScreen.SetActive(true);
                SliderChanger.pauseTimer = true; //pause the timer
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
        }
        else
        {
            SliderChanger.timeRemaining -= 5f;
            StartCoroutine(ShowWrongText(1.5f));
            Debug.Log("Try Again!");
        }
        Debug.Log(unansweredQuestions.Count);
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
