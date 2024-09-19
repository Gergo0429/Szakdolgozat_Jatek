using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCamera : MonoBehaviour
{
    public float moveSpeed = 5f;

    private float rotationSpeed = 10f;
    private Camera mainCamera;
    private Vector3 cameraPosition;
    private Animator anim;
    private FirstPersonDamage firstPersonDamage;
    private float timeSinceLastDamage = 0f;

    private AudioSource[] steps;
    private bool left = true;

    void Start()
    {
        mainCamera = Camera.main;
        anim = GetComponent<Animator>();
        firstPersonDamage = GameObject.Find("Player").GetComponent<FirstPersonDamage>();

        steps = GetComponents<AudioSource>();
    }

    void Update()
    {
        cameraPosition = mainCamera.transform.position;

        Vector3 targetPosition = new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z);

        if (Vector3.Distance(transform.position, targetPosition) > 0.6f)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            anim.speed = 1f;
            timeSinceLastDamage = 0f;

            if (steps[0].isPlaying == false && steps[1].isPlaying == false)
            {
                if (left)
                {
                    steps[1].Stop();
                    steps[0].Play();
                    left = false;
                }
                else
                {
                    steps[0].Stop();
                    steps[1].Play();
                    left = true;
                }

            }
        }
        else
        {
            anim.speed = 0f;

            timeSinceLastDamage += Time.deltaTime;

            if (timeSinceLastDamage >= 1f)
            {
                firstPersonDamage.Damage(11);
                timeSinceLastDamage = 0f;
            }
        }

        Vector3 directionToFace = targetPosition - transform.position;
        directionToFace.y = 0f;

        if (directionToFace != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }
}
