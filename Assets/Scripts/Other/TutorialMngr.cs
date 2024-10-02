using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialMngr : MonoBehaviour
{
    public GameObject interactables;
    private TextMeshProUGUI textMesh;

    private int faze = 1;

    private GameObject objToCheck;

    void Start()
    {
        textMesh = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textMesh.text = Lean.Localization.LeanLocalization.GetTranslationText("Tutorial1");

        objToCheck = GameObject.Find("Enemies").transform.GetChild(0).gameObject;
    }

    void Update()
    {
        switch (faze)
        {
            case 1:
                if (!objToCheck.activeSelf)
                {
                    textMesh.text = Lean.Localization.LeanLocalization.GetTranslationText("Tutorial2");
                    faze = 2;
                    objToCheck = GameObject.Find("Inventory");
                }
                break;
            case 2:
                if (objToCheck.GetComponent<InventoryModelController>().FindIndexByName("Ammo") != -1 && objToCheck.GetComponent<InventoryModelController>().FindIndexByName("RedKey") != -1)
                {
                    textMesh.text = Lean.Localization.LeanLocalization.GetTranslationText("Tutorial3");
                    faze = 3;
                }
                break;
            case 3:
                if (objToCheck.transform.GetChild(0).gameObject.activeSelf)
                {
                    textMesh.text = Lean.Localization.LeanLocalization.GetTranslationText("Tutorial4");
                    faze = 4;
                }
                break;
            case 4:
                if (objToCheck.GetComponent<InventoryModelController>().FindIndexByName("RedKey") == 10)
                {
                    textMesh.text = Lean.Localization.LeanLocalization.GetTranslationText("Tutorial5");
                    faze = 5;
                    foreach (Transform child in interactables.transform)
                    {
                        if (child.gameObject.name == "Drawer")
                        {
                            objToCheck = child.GetChild(0).gameObject;
                        }
                    }
                }
                break;
            case 5:
                if (!objToCheck.GetComponent<DrawerOpenClose>().isLocked)
                {
                    textMesh.text = Lean.Localization.LeanLocalization.GetTranslationText("Tutorial6");
                    faze = 6;
                    foreach (Transform child in interactables.transform)
                    {
                        if (child.gameObject.name == "door")
                        {
                            objToCheck = child.GetChild(0).gameObject;
                        }
                    }
                }
                break;
            case 6:
                if (!objToCheck.GetComponent<DoorOpenClose>().isLocked)
                {
                    textMesh.text = Lean.Localization.LeanLocalization.GetTranslationText("Tutorial7");
                    faze = 7;
                    objToCheck = null;
                }
                break;
            default:
                // code block
                break;
        }
    }
}
