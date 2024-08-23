using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : InteractableBase
{
    [SerializeField]
    public ItemModel itemModel;

    private AudioSource pickSound;
    private GameUICanvasMngr gameUICanvasMngr;

    void Awake()
    {
        pickSound = gameObject.GetComponent<AudioSource>();
        gameUICanvasMngr = GameObject.Find("GameUICanvas").GetComponent<GameUICanvasMngr>();
    }

    public override void Interact()
    {
        pickSound.Play();

        GameObject.Find("Inventory").GetComponent<InventoryModelController>().AddItem(itemModel);

        Delay.CallDelayedFunction(0.2f, Deactivate);
    }

    private void Deactivate()
    {
        gameUICanvasMngr.ClearAllTexts();
        this.gameObject.SetActive(false);
    }
}
