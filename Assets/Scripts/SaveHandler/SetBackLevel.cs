using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackLevel : MonoBehaviour
{
    public int levelNr;
    Data data;
    GameObject saveMngr;

    void Start()
    {
        saveMngr = GameObject.Find("SaveMngr");
        saveMngr.GetComponent<SaveDAO>().Load();
        data = saveMngr.GetComponent<SaveDAO>().data;
        SetLevelActive();
    }

    void OnEnable()
    {
        saveMngr = GameObject.Find("SaveMngr");
        saveMngr.GetComponent<SaveDAO>().Load();
        data = saveMngr.GetComponent<SaveDAO>().data;
        SetLevelActive();
    }

    public void SetLevelActive()
    {
        if (data.level < levelNr)
        {
            this.gameObject.SetActive(false);
        }
    }
}
