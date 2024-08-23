using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour, IMenuAction
{
    public int levelNr;

    public void Execute()
    {
        GameObject.Find("SceneMngr").GetComponent<SceneMngr>().LoadLevel(levelNr);
    }
}
