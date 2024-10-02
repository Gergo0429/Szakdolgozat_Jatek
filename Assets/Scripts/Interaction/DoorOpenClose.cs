using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : InteractableBase
{
    public string keyNeeded;
    public bool isLocked = false;

    private Animator doorAnimator = null;
    private bool isOpen = false;

    private AudioSource[] sounds;

    void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        sounds = GetComponents<AudioSource>();
    }

    public void OpenClose()
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

    public override void Interact()
    {
        if (isLocked)
        {
            if (GameObject.Find("Inventory").GetComponent<InventoryModelController>().UseFromHand(keyNeeded))
            {
                isLocked = false;
                sounds[2].Play();
            }
            else
            {
                if (keyNeeded != "" && keyNeeded != null)
                {
                    gameUICanvas.GetComponent<GameUICanvasMngr>().Help(Lean.Localization.LeanLocalization.GetTranslationText("ItemNeeded") + ": " + Lean.Localization.LeanLocalization.GetTranslationText(keyNeeded));
                }
                else
                {
                    gameUICanvas.GetComponent<GameUICanvasMngr>().Help(Lean.Localization.LeanLocalization.GetTranslationText("CodeNeeded"));
                }
                sounds[3].Play();
            }
        }
        else
        {
            OpenClose();
        }
    }
}
