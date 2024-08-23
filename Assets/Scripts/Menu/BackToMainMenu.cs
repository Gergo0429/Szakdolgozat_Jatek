using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour, IMenuAction
{
    public void Execute()
    {
        GameObject.Find("SceneMngr").GetComponent<SceneMngr>().LoadScene("MainMenu");
    }
}
