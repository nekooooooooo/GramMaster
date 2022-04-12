using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour
{

    public int lessonGameToUnlock;
    public LevelLoader levelLoader;
    public int lesson;

    public void UnlockLessonGame()
    {
        if (lessonGameToUnlock > PlayerPrefs.GetInt("lessonGameReached", 1))
        {
            PlayerPrefs.SetInt("lessonGameReached", lessonGameToUnlock);
        }
        levelLoader.LoadLevel(1);
    }

    public void LessonEnd()
    {
        MainMenuControlScript.fromGame = true;
        if (lesson == 1)
        {
            MainMenuControlScript.fromLesson1 = true;
            MainMenuControlScript.fromLesson2 = false;
            MainMenuControlScript.fromLesson3 = false;
            MainMenuControlScript.fromLesson4 = false;
            MainMenuControlScript.fromLesson5 = false;
            MainMenuControlScript.fromLesson6 = false;
        }
        else if (lesson == 2)
        {
            MainMenuControlScript.fromLesson1 = false;
            MainMenuControlScript.fromLesson2 = true;
            MainMenuControlScript.fromLesson3 = false;
            MainMenuControlScript.fromLesson4 = false;
            MainMenuControlScript.fromLesson5 = false;
            MainMenuControlScript.fromLesson6 = false;
        }
        else if (lesson == 3)
        {
            MainMenuControlScript.fromLesson1 = false;
            MainMenuControlScript.fromLesson2 = false;
            MainMenuControlScript.fromLesson3 = true;
            MainMenuControlScript.fromLesson4 = false;
            MainMenuControlScript.fromLesson5 = false;
            MainMenuControlScript.fromLesson6 = false;
        }
        else if (lesson == 4)
        {
            MainMenuControlScript.fromLesson1 = false;
            MainMenuControlScript.fromLesson2 = false;
            MainMenuControlScript.fromLesson3 = false;
            MainMenuControlScript.fromLesson4 = true;
            MainMenuControlScript.fromLesson5 = false;
            MainMenuControlScript.fromLesson6 = false;
        }
        else if (lesson == 5)
        {
            MainMenuControlScript.fromLesson1 = false;
            MainMenuControlScript.fromLesson2 = false;
            MainMenuControlScript.fromLesson3 = false;
            MainMenuControlScript.fromLesson4 = false;
            MainMenuControlScript.fromLesson5 = true;
            MainMenuControlScript.fromLesson6 = false;
        }
        else if (lesson == 6)
        {
            MainMenuControlScript.fromLesson1 = false;
            MainMenuControlScript.fromLesson2 = false;
            MainMenuControlScript.fromLesson3 = false;
            MainMenuControlScript.fromLesson4 = false;
            MainMenuControlScript.fromLesson5 = false;
            MainMenuControlScript.fromLesson6 = true;
        }
        Debug.Log("Lesson Ended!");
        UnlockLessonGame();
    }

    public void EndLesson()
    {
        MainMenuControlScript.fromGame = false;
        MainMenuControlScript.fromLesson1 = false;
        MainMenuControlScript.fromLesson2 = false;
        MainMenuControlScript.fromLesson3 = false;
        MainMenuControlScript.fromLesson4 = false;
        MainMenuControlScript.fromLesson5 = false;
        MainMenuControlScript.fromLesson6 = false;
        UnlockLessonGame();
    }

}
