using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsMngr : MonoBehaviour
{
    private TextMeshProUGUI life;
    private TextMeshProUGUI ammo;
    private TextMeshProUGUI stamina;

    void Awake()
    {
        life = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ammo = transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        stamina = transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void SetAmmo(int count)
    {
        ammo.text = count.ToString() + "/8";
    }

    public void SetLife(int life)
    {
        this.life.text = life.ToString() + "%";
    }

    public void SetStamina(int stam)
    {
        stamina.text = stam.ToString() + "%";
    }
}
