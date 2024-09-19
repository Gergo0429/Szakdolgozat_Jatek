using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPreviousScene : MonoBehaviour, IMenuAction
{
    public void Execute()
    {
        GameObject.Find("SceneMngr").GetComponent<SceneMngr>().LoadPrevious();
    }
}
