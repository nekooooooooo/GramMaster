using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScoreScript : MonoBehaviour
{

    public TMP_Text noOfStars;
    public TMP_Text totalScore;

    // Start is called before the first frame update
    void Start()
    {
        noOfStars.text += PlayerPrefs.GetInt("totalStars").ToString();
        totalScore.text += PlayerPrefs.GetFloat("totalScore").ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
