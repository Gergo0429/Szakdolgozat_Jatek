using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBackSliders : MonoBehaviour
{
    public string dataName;

    Data data;
    GameObject saveMngr;

    void Start()
    {
        saveMngr = GameObject.Find("SaveMngr");
        saveMngr.GetComponent<SaveDAO>().Load();
        data = saveMngr.GetComponent<SaveDAO>().data;
        SetSliderValue();
    }

    void SetSliderValue()
    {
        switch (dataName)
        {
            case "sensitivity":
            case "Sensitivity":
            case "SENSITIVITY":
                this.gameObject.GetComponent<Slider>().value = (float)GameObject.Find("SaveMngr").GetComponent<SaveDAO>().data.sensitivity;
                break;
            case "fov":
            case "Fov":
            case "FOV":
                this.gameObject.GetComponent<Slider>().value = (float)GameObject.Find("SaveMngr").GetComponent<SaveDAO>().data.fov;
                break;
            default:
                break;
        }
    }
}
