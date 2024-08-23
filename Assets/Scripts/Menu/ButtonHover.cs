using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHover : MonoBehaviour, IMenuAction
{
    public void Execute()
    {
        TMP_Text buttonText = this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        buttonText.fontStyle = FontStyles.Underline;
        buttonText.fontSize = 30;
        this.GetComponent<AudioSource>().Play();
    }
}
