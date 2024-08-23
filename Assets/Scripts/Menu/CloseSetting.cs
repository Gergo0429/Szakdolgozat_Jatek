using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSetting : MonoBehaviour, IMenuAction
{
    public GameObject cover;

    public void Execute()
    {
        this.transform.parent?.gameObject.SetActive(false);
        cover.SetActive(false);
    }
}
