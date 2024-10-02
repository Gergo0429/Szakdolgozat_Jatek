using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    public string itemName;
    public float distance = 2.5f;

    protected Camera eyeCamera;
    protected GameObject gameUICanvas;
    private bool lookedOnThis;

    public abstract void Interact();

    private void Start()
    {
        lookedOnThis = false;
        name = "";
        gameUICanvas = GameObject.Find("GameUICanvas");
        eyeCamera = GameObject.Find("EyeCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        Ray ray = eyeCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == this.gameObject && Vector3.Distance(transform.position, eyeCamera.gameObject.GetComponent<Transform>().position) < distance)
            {
                gameUICanvas.GetComponent<GameUICanvasMngr>().LookingAt(Lean.Localization.LeanLocalization.GetTranslationText(itemName));
                lookedOnThis = true;

                if (Input.GetMouseButtonDown(1))
                {
                    Interact();
                }
            }
            else if (lookedOnThis)
            {
                gameUICanvas.GetComponent<GameUICanvasMngr>().ClearAllTexts();
                lookedOnThis = false;
            }
        }
    }
}
