using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Register : MonoBehaviour
{

    public TMP_InputField input;
    public TMP_Text text;
    public GameObject mainMenu;
    public GameObject register;
    public static string uName;
    public static int ifRegistered;
    public TMP_Text watermark;

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.GetInt("isRegistered") == 1)
        {
            text.gameObject.SetActive(true);
            mainMenu.SetActive(true);
            register.SetActive(false);
            text.text = text.text + " " + PlayerPrefs.GetString("userName") + "!";
        }
        else
        {
            text.text = "Welcome, " + PlayerPrefs.GetString("userName") + "!";
        }
    }

    public void GetInput(string name)
    {
        uName = input.text;
        if(uName == "ljan gwapo")
        {
            watermark.gameObject.SetActive(true);
            PlayerPrefs.SetString("userName", "Programmer");
            text.text = "Welcome, Programmer" + "!";
            Debug.Log(PlayerPrefs.GetString("userName"));
            if (PlayerPrefs.GetInt("isRegistered") == 1)
            {
                Debug.Log("This phone has been registered!");
            }
            else
            {
                ifRegistered = 1;
                text.gameObject.SetActive(true);
                PlayerPrefs.SetInt("isRegistered", ifRegistered);
                Debug.Log("This phone has not been registered!");
            }
        }
        else
        {
            PlayerPrefs.SetString("userName", uName);
            text.text = "Welcome, " + PlayerPrefs.GetString("userName") + "!";
            Debug.Log(PlayerPrefs.GetString("userName"));
            if (PlayerPrefs.GetInt("isRegistered") == 1)
            {
                Debug.Log("This phone has been registered!");
            }
            else
            {
                ifRegistered = 1;
                text.gameObject.SetActive(true);
                PlayerPrefs.SetInt("isRegistered", ifRegistered);
                Debug.Log("This phone has not been registered!");
            }
        }
    }
}
