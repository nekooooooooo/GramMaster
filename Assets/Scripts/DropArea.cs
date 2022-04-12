using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropArea : MonoBehaviour, IDropHandler
{

    public TMP_Text text;
    public TMP_Text answer;
    public static string questionAnswer;

    void Update()
    {
        questionAnswer = text.text;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            //text.text = questionAnswer + " " + DragDrop.answer;
            answer.text = DragDrop.answer;
        }
    }

}
