using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : InteractableBase
{
    public int buttonCode;

    private KeypadController keypadController;

    private void Awake()
    {
        this.itemName = "Button";
        keypadController = transform.parent.parent.parent.GetComponent<KeypadController>();
    }

    public override void Interact()
    {
        keypadController.ButtonPressed(buttonCode);
    }

}
