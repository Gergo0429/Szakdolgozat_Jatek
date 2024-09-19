using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxDistance = 10f;

    private float startingZ;

    void Start()
    {
        startingZ = transform.position.z;
    }

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        float step = moveSpeed * Time.deltaTime;

        float newZPosition = transform.position.z + step;

        if (newZPosition <= startingZ + maxDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startingZ + maxDistance);
            this.enabled = false;
        }
    }
}
