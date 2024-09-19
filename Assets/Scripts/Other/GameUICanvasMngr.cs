using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUICanvasMngr : MonoBehaviour
{
    TextMeshProUGUI lookingAt;
    TextMeshProUGUI help;

    private StatsMngr stats;

    void Awake()
    {
        lookingAt = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        help = transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        stats = transform.GetChild(3).gameObject.GetComponent<StatsMngr>();
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

    public void Damageing()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void SetAmmoCount(int count)
    {
        stats.SetAmmo(count);
    }

    public void SetLife(float life)
    {
        stats.SetLife((int)life);
    }

    public void SetStamina(float stamina)
    {
        stats.SetStamina((int)stamina);
    }
}
