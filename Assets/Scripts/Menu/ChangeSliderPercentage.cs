using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSliderPercentage : MonoBehaviour, IMenuAction
{
    private TextMeshProUGUI tmpText;
    private Slider slider;

    void Start()
    {
        Execute();
    }
    public void Execute()
    {
        tmpText = this.gameObject.GetComponent<TextMeshProUGUI>();
        slider = this.transform.parent?.parent?.parent?.gameObject.GetComponent<Slider>();
        float? val = (slider.value - slider.minValue) / (slider.maxValue - slider.minValue) * 100;
        int? wholeVal = val.HasValue ? (int)val.Value : (int?)null;
        tmpText.text = wholeVal?.ToString() + " %";
    }
}
