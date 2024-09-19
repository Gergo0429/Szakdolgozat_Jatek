using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoomedView : MonoBehaviour
{
    private GameObject image;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        image = transform.GetChild(0).gameObject;
        textMesh = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void SetName(string name)
    {

        textMesh.text = name;
    }

    public void SetImage(Sprite image)
    {
        this.image.GetComponent<Image>().sprite = image;
        this.image.SetActive(true);
    }

    public void SetEmpty()
    {
        image.SetActive(false);
        textMesh.text = "";
    }
}
