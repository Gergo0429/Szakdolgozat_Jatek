using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolModel : MonoBehaviour
{
    public int maxAmmo = 8;

    public int ammoCount = 6;
    private InventoryModelController invModel;

    void Awake()
    {
        invModel = GameObject.Find("Inventory").GetComponent<InventoryModelController>();
    }

    public int GetAmmoCount()
    { return ammoCount; }

    public bool TakeAmmo()
    {
        if (ammoCount == 0)
        {
            return false;
        }
        else
        {
            ammoCount--;
            return true;
        }
    }

    public bool Reload()
    {
        bool reloaded = false;
        while (invModel.RemoveItem("Ammo") && ammoCount < maxAmmo)
        {
            ammoCount++;
            reloaded = true;
        }
        return reloaded;
    }
}
