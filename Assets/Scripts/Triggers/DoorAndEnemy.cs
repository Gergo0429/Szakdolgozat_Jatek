using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAndEnemy : TriggerBase
{
    public GameObject door;
    public string keyNeeded = "RedKey";
    public GameObject enemy;

    public override void TriggerAction()
    {
        DoorOpenClose doc = door.transform.GetChild(0).gameObject.GetComponent<DoorOpenClose>();

        doc.OpenClose();
        doc.isLocked = true;
        doc.keyNeeded = keyNeeded;

        enemy.GetComponent<MoveTowardsCamera>().enabled = true;

        this.gameObject.SetActive(false);
    }
}
