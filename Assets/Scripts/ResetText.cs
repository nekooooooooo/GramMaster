using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ResetText : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField inputField;

    private void clearText()
    {
        inputField.text = "";
    }

}
