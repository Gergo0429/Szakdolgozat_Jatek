using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class ChangeLanguage : MonoBehaviour, IMenuAction
{
    public string language;

    public void Execute()
    {
        GameObject.Find("LeanLocalization").GetComponent<LeanLocalization>().SetCurrentLanguage(language);
    }
}
