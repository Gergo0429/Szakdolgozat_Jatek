using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour, IMenuAction
{
    public void Execute()
    {
        Application.Quit();
    }
}
