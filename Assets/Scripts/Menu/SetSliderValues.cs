using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderValues : MonoBehaviour, IMenuAction
{
    public string dataName;

    public void Execute()
    {
        switch (dataName)
        {
            case "sensitivity":
            case "Sensitivity":
            case "SENSITIVITY":
                GameObject.Find("SaveMngr").GetComponent<SaveDAO>().data.sensitivity = (int)this.gameObject.GetComponent<Slider>().value;
                break;
            case "fov":
            case "Fov":
            case "FOV":
                GameObject.Find("SaveMngr").GetComponent<SaveDAO>().data.fov = (int)this.gameObject.GetComponent<Slider>().value;
                break;
            default:
                break;
        }


    }
}
