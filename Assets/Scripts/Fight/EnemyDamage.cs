using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : DamageBase
{
    public int headShotDamage = 25;
    public int bodyShotDamage = 11;

    private Collider[] colliders;

    public void Awake()
    {
        colliders = GetComponents<Collider>();
    }

    public void Shot(Collider col)
    {
        if (col == colliders[1])
        {
            Damage(bodyShotDamage);
        }
        else if (col == colliders[0])
        {
            Damage(headShotDamage);
        }
    }

    public override void Damage(int damage)
    {
        life -= damage;
    }

    public override void Death()
    {
        gameObject.SetActive(false);
    }
}
