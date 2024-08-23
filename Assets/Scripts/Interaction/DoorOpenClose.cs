using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : InteractableBase
{
    public string keyNeeded;

    private Animator doorAnimator = null;
    private bool isOpen = false;

    private AudioSource[] sounds;

    void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        sounds = GetComponents<AudioSource>();
    }

    public override void Interact()
    {
        if (keyNeeded != "" && keyNeeded != null)
        {
            if (GameObject.Find("Inventory").GetComponent<InventoryModelController>().UseFromHand(keyNeeded))
            {
                keyNeeded = null;
                sounds[2].Play();
            }
            else
            {
                gameUICanvas.GetComponent<GameUICanvasMngr>().Help(Lean.Localization.LeanLocalization.GetTranslationText("ItemNeeded") + ": " + Lean.Localization.LeanLocalization.GetTranslationText(keyNeeded));
                sounds[3].Play();
            }
        }
        else
        {
            if (!isOpen)
            {
                sounds[1].Play();
                doorAnimator.Play("DoorOpen", 0, 0.0f);
                isOpen = true;
            }
            else
            {
                sounds[0].PlayDelayed(0.8f);
                doorAnimator.Play("DoorClose", 0, 0.0f);
                isOpen = false;
            }
        }
    }
}
