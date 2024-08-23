using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour, IMenuAction
{
    public GameObject changeHere;

    public void Execute()
    {
        GameObject menu = GameObject.Find("Menu");

        foreach (Transform child in menu.transform)
        {
            child.gameObject.SetActive(false);
        }

        changeHere.SetActive(true);
    }
}
