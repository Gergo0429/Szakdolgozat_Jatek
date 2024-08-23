using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBackQuality : MonoBehaviour
{
    Data data;
    GameObject saveMngr;

    void Start()
    {
        SetQuality();
    }

    void SetQuality()
    {
        saveMngr = GameObject.Find("SaveMngr");
        saveMngr.GetComponent<SaveDAO>().Load();
        data = saveMngr.GetComponent<SaveDAO>().data;
        QualitySettings.SetQualityLevel(data.quality, true);
    }
}
