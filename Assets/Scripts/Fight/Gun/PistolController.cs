using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    private PistolView pistolView;
    private PistolModel pistolModel;

    private AudioSource[] sounds;
    private Camera eyeCamera;
    private GameUICanvasMngr gameUICanvasMngr;

    void Start()
    {
        pistolView = GetComponent<PistolView>();
        pistolModel = GetComponent<PistolModel>();
        sounds = GetComponents<AudioSource>();
        eyeCamera = GameObject.Find("EyeCamera").GetComponent<Camera>();
        gameUICanvasMngr = GameObject.Find("GameUICanvas").GetComponent<GameUICanvasMngr>();

        gameUICanvasMngr.SetAmmoCount(pistolModel.GetAmmoCount());
    }

    public int HowManyLoaded()
    {
        return pistolModel.GetAmmoCount();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pistolModel.TakeAmmo())
            {
                Shoot();
                gameUICanvasMngr.SetAmmoCount(pistolModel.GetAmmoCount());
            }
            else
            {
                pistolView.SetEmpty();
                sounds[0].Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            gameUICanvasMngr.SetAmmoCount(pistolModel.GetAmmoCount());
        }
    }

    private void Shoot()
    {
        pistolView.Shoot();
        sounds[1].Play();
        Ray ray = eyeCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<EnemyDamage>() != null)
            {
                hit.collider.gameObject.GetComponent<EnemyDamage>().Shot(hit.collider);
            }
        }

    }

    private void Reload()
    {
        if (pistolModel.Reload())
        {
            pistolView.Reload();
            sounds[2].Play();
        }
        else
        {
            gameUICanvasMngr.Help(Lean.Localization.LeanLocalization.GetTranslationText("NoAmmo"));
            Delay.CallDelayedFunction(1.5f, ResetText);
        }
    }

    private void ResetText()
    {
        gameUICanvasMngr.Help("");
    }
}
