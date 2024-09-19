using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageBase : MonoBehaviour, IDamage
{
    public float life;

    public abstract void Damage(int damage);

    public abstract void Death();

    protected void Update()
    {
        if (life <= 0)
        {
            Death();
        }
    }
}
