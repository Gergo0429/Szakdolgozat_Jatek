using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUICanvasMngr : MonoBehaviour
{
    TextMeshProUGUI lookingAt;
    TextMeshProUGUI help;

    void Start()
    {
        lookingAt = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        help = transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void LookingAt(string textToWrite)
    {
        lookingAt.text = textToWrite;
        //Debug.Log(textToWrite);
    }

    public void Help(string textToWrite)
    {
        help.text = textToWrite;
    }

    public void ClearAllTexts()
    {
        lookingAt.text = "";
        help.text = "";
    }
}
