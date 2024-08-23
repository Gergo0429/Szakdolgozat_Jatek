using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SetQuality : MonoBehaviour, IMenuAction
{
    public int index;

    public void Execute()
    {
        if (index > -1 && index < 3)
        {
            QualitySettings.SetQualityLevel(index, true);
            GameObject.Find("SaveMngr").GetComponent<SaveDAO>().data.quality = index;
        }
    }
}
