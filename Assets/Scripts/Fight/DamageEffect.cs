using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    private float timeSinceLastDamage = 0f;
    private AudioSource damageSound;

    void Awake()
    {
        damageSound = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        damageSound.Play();
    }

    void Update()
    {
        timeSinceLastDamage += Time.deltaTime;

        if (timeSinceLastDamage >= 0.5f)
        {
            timeSinceLastDamage = 0f;
            gameObject.SetActive(false);
        }
    }
}
