using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetGame : MonoBehaviour
{

    public LevelLoader levelLoader;

    public void RestartGame()
    {
        Debug.Log("Reset!");
        /*GameManager.unansweredQuestions.Clear();
        GameManagerButtons.unansweredQuestions.Clear();
        GameManagerDragDrop.unansweredQuestions.Clear();*/
        //levelLoader.LoadLevel(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}
