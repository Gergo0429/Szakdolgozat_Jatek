using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpenClose : InteractableBase
{
    public string keyNeeded;
    public bool isLocked = false;

    private AudioSource[] sounds;

    private Animator drawerAnimator;

    void Awake()
    {
        sounds = GetComponents<AudioSource>();
        drawerAnimator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (isLocked)
        {
            if (GameObject.Find("Inventory").GetComponent<InventoryModelController>().UseFromHand(keyNeeded))
            {
                isLocked = false;
                sounds[0].Play();
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
                sounds[1].Play();
            }
        }
        else
        {
            sounds[2].Play();
            drawerAnimator.Play("DrawerOpen", 0, 0.0f);
            this.enabled = false;
        }
    }
}
