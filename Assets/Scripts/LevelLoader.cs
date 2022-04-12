using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;

    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsychronously(sceneIndex));
    }

    IEnumerator LoadAsychronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = (progress * 100).ToString("F0") + "%";
            Debug.Log(progressText.text);
            yield return null;
        }

    }

    public void GoToMain(int sceneIndex)
    {
        MainMenuControlScript.fromGame = false;
        MainMenuControlScript.fromLesson1 = false;
        MainMenuControlScript.fromLesson2 = false;
        MainMenuControlScript.fromLesson3 = false;
        MainMenuControlScript.fromLesson4 = false;
        MainMenuControlScript.fromLesson5 = false;
        MainMenuControlScript.fromLesson6 = false;
        LoadLevel(sceneIndex);
    }


}
