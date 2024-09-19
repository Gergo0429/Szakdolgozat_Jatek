using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonDamage : DamageBase
{
    private GameUICanvasMngr gameUICanvasMngr;

    public void Start()
    {
        gameUICanvasMngr = GameObject.Find("GameUICanvas").GetComponent<GameUICanvasMngr>();
        gameUICanvasMngr.SetLife(life);
    }

    public override void Damage(int damage)
    {
        life -= damage;
        gameUICanvasMngr.SetLife(life);
        gameUICanvasMngr.Damageing();
    }

    public override void Death()
    {
        GameObject.Find("SceneMngr").GetComponent<SceneMngr>().LoadScene("Death");
    }
}
