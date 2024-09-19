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
        keypadController = GameObject.Find("Keypad").GetComponent<KeypadController>();
    }

    public override void Interact()
    {
        keypadController.ButtonPressed(buttonCode);
    }

}
