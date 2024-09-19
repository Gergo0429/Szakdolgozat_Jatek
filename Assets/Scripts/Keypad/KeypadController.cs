using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour
{
    public int code;
    public GameObject doorToOpen;

    private TextMeshProUGUI textMesh;
    private AudioSource[] sounds;

    void Start()
    {
        textMesh = transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        sounds = GetComponents<AudioSource>();
    }

    public void ButtonPressed(int buttonCode)
    {
        if (buttonCode < 0 || buttonCode > 10)
        {
            return;
        }

        sounds[0].Play();

        if (buttonCode == 10)
        {
            if (textMesh.text == code.ToString())
            {
                textMesh.text = "APPROVED";
                textMesh.color = Color.green;
                doorToOpen.transform.GetChild(0).gameObject.GetComponent<DoorOpenClose>().isLocked = false;
                sounds[2].Play();
            }
            else
            {
                textMesh.text = "DENIED";
                textMesh.color = Color.red;
                sounds[1].Play();
            }
        }
        else if (textMesh.text.Length < 7)
        {
            if (textMesh.text == "DENIED")
            {
                textMesh.text = "";
                textMesh.color = Color.black;
            }
            textMesh.text += buttonCode.ToString();
        }

    }
}
