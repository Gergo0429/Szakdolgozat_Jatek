using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSetting : MonoBehaviour, IMenuAction
{
    public GameObject cover;
    public GameObject setting;

    public void Execute()
    {
        setting.SetActive(true);
        cover.SetActive(true);
    }
}
