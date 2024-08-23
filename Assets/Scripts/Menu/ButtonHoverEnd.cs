using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHoverEnd : MonoBehaviour, IMenuAction
{
    public void Execute()
    {
        TMP_Text buttonText = this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        buttonText.fontStyle = FontStyles.Normal;
        buttonText.fontSize = 24;
    }
}
