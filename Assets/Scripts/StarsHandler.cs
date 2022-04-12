using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsHandler : MonoBehaviour
{

    public Sprite greyStar;
    public Image[] stars;
    public float timeRemaining;
    private float timeMax;
    public static int noOfStars;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        noOfStars = 3;
        CheckStars();
    }

    public void CheckStars()
    {
        if (SliderChanger.timeRemaining < SliderChanger.timerMax * 0.5)
        {
            stars[2].sprite = greyStar;
            noOfStars = 2;
        }
        if (SliderChanger.timeRemaining < SliderChanger.timerMax * 0.25)
        {
            stars[1].sprite = greyStar;
            noOfStars = 1;
        }
        if (SliderChanger.timeRemaining < 0)
        {
            stars[0].sprite = greyStar;
            noOfStars = 0;
        }
    }
}
