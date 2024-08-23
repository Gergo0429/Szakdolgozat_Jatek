using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBackCamera : MonoBehaviour
{
    Data data;
    GameObject saveMngr;

    void Start()
    {
        SetCamera();
    }

    void SetCamera()
    {
        saveMngr = GameObject.Find("SaveMngr");
        saveMngr.GetComponent<SaveDAO>().Load();
        data = saveMngr.GetComponent<SaveDAO>().data;
        this.gameObject.GetComponent<MouseLook>().mouseSensitivity = data.sensitivity;
        this.gameObject.GetComponent<Camera>().fieldOfView = data.fov;
    }
}
