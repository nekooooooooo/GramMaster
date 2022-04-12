using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Loading : MonoBehaviour
{

    public Animator animator;
    public Slider slider;
    public TextMeshProUGUI progressText;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.0f);
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(1);

        while (!gameLevel.isDone)
        {
            float progress = Mathf.Clamp01(gameLevel.progress / .9f);
            slider.value = progress;
            progressText.text = (progress * 100).ToString("F0") + "%";
            Debug.Log(progress);
            yield return null;
        }
     
    }

}
