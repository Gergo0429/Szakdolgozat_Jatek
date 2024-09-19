using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float gravity = 3f;

    private float velocity = 0;
    private CharacterController controller;

    private AudioSource[] steps;
    private bool first;

    private int leftStepIndex;
    private int rightStepIndex;
    private float stamina = 100f;
    private bool staminaIncrement = false;
    private GameUICanvasMngr gameUICanvasMngr;

    void Awake()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
        steps = GetComponents<AudioSource>();
        first = true;

        gameUICanvasMngr = GameObject.Find("GameUICanvas").GetComponent<GameUICanvasMngr>();

        leftStepIndex = 0;
        rightStepIndex = 1;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
            controller.Move(new Vector3(0, velocity, 0));
        }

        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            if (first)
            {
                if (steps[leftStepIndex].isPlaying == false && steps[rightStepIndex].isPlaying == false)
                {
                    steps[rightStepIndex].Stop();
                    steps[leftStepIndex].Play();
                    first = false;
                }
            }
            else
            {
                if (steps[leftStepIndex].isPlaying == false && steps[rightStepIndex].isPlaying == false)
                {
                    steps[leftStepIndex].Stop();
                    steps[rightStepIndex].Play();
                    first = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 4f;

            leftStepIndex = 2;
            rightStepIndex = 3;
        }
        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 0f)
        {
            stamina -= 30 * Time.deltaTime;
            stamina = Mathf.Max(stamina, 0f);
            staminaIncrement = false;
            gameUICanvasMngr.SetStamina(stamina);
            if (stamina == 0f)
            {
                speed = 2f;

                leftStepIndex = 0;
                rightStepIndex = 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2f;

            leftStepIndex = 0;
            rightStepIndex = 1;

            staminaIncrement = true;
        }
        if (staminaIncrement && stamina < 100f)
        {
            stamina += 30 * Time.deltaTime;
            stamina = Mathf.Min(stamina, 100f);
            gameUICanvasMngr.SetStamina(stamina);
        }
    }
}
