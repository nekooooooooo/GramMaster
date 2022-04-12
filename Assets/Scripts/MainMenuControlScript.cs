using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlScript : MonoBehaviour
{

    public Button[] lessonButtons;
    public Button[] levelButtons;
    public Button[] lessonGameButtons;
    public static bool fromGame = false;
    public static bool fromLesson1 = false;
    public static bool fromLesson2 = false;
    public static bool fromLesson3 = false;
    public static bool fromLesson4 = false;
    public static bool fromLesson5 = false;
    public static bool fromLesson6 = false;
    public GameObject mainMenu;
    public GameObject lesson1;
    public GameObject lesson2;
    public GameObject lesson3;
    public GameObject lesson4;
    public GameObject lesson5;
    public GameObject lesson6;
    // Start is called before the first frame update
    void Start()
    {
        if (fromGame)
        {
            mainMenu.SetActive(false);
            if (fromLesson1)
            {
                lesson1.SetActive(true);
            } 
            if (fromLesson2) 
            {
                lesson1.SetActive(false);
                lesson2.SetActive(true);
            }
            if (fromLesson3)
            {
                lesson1.SetActive(false);
                lesson2.SetActive(false);
                lesson3.SetActive(true);
            }
            if (fromLesson4)
            {
                lesson1.SetActive(false);
                lesson2.SetActive(false);
                lesson3.SetActive(false);
                lesson4.SetActive(true);
            }
            if (fromLesson5)
            {
                lesson1.SetActive(false);
                lesson2.SetActive(false);
                lesson3.SetActive(false);
                lesson4.SetActive(false);
                lesson5.SetActive(true);
            }
            if (fromLesson6)
            {
                lesson1.SetActive(false);
                lesson2.SetActive(false);
                lesson3.SetActive(false);
                lesson4.SetActive(false);
                lesson5.SetActive(false);
                lesson6.SetActive(true);
            }
            fromGame = false;
        }

        int lessonReached = PlayerPrefs.GetInt("lessonReached", 1);
        int lessonGameReached = PlayerPrefs.GetInt("lessonGameReached", 1);
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < lessonButtons.Length; i++)
        {
            if (i + 1 > lessonReached)
                lessonButtons[i].interactable = false;
        }

        for (int i = 0; i < lessonGameButtons.Length; i++)
        {
            if (i + 1 > lessonGameReached)
                lessonGameButtons[i].interactable = false;
        }

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
