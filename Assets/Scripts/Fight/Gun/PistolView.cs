using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolView : MonoBehaviour
{
    private float targetAngle = 35.0f;
    private float originalAngle = 9.0f;

    private Vector3 targetPosition;
    private Vector3 originalPosition;

    private float rotationSpeed = 350.0f;
    private float movementSpeed = 10.0f;

    private bool rotating = false;
    private bool rotatingForward = true;
    private bool movingForward = true;

    private bool settingEmpty = false;
    private bool reloading = false;

    private float timeSinceReloading = 0f;

    private GameObject rotatingObject;

    private GameObject movingObject;

    void Start()
    {
        rotatingObject = gameObject;

        movingObject = rotatingObject.transform.GetChild(1).gameObject;

        originalPosition = movingObject.transform.localPosition;
        targetPosition = originalPosition + new Vector3(-0.2f, 0, 0);
    }

    void Update()
    {
        if (rotating)
        {
            RecoilRotation();
            RecoilMove();
        }
        else if (settingEmpty)
        {
            SettingEmpty();
        }
        else if (reloading)
        {
            Reloading();
        }
    }

    public void Shoot()
    {
        if (!rotating && !reloading)
        {
            rotating = true;
            rotatingForward = true;
            movingForward = true;
        }
    }
    public void SetEmpty()
    {
        if (!settingEmpty)
        {
            settingEmpty = true;
            movingForward = true;
        }
    }
    public void Reload()
    {
        if (!reloading)
        {
            reloading = true;
        }
    }

    void RecoilRotation()
    {
        if (rotatingObject == null)
            return;

        float currentZAngle = rotatingObject.transform.eulerAngles.z;

        float newZAngle;

        if (rotatingForward)
        {
            newZAngle = Mathf.MoveTowardsAngle(currentZAngle, targetAngle, rotationSpeed * Time.deltaTime);

            if (Mathf.Approximately(newZAngle, targetAngle))
            {
                rotatingForward = false;
            }
        }
        else
        {
            newZAngle = Mathf.MoveTowardsAngle(currentZAngle, originalAngle, rotationSpeed * Time.deltaTime);

            if (Mathf.Approximately(newZAngle, originalAngle))
            {
                rotating = false;
            }
        }

        rotatingObject.transform.rotation = Quaternion.Euler(rotatingObject.transform.eulerAngles.x, rotatingObject.transform.eulerAngles.y, newZAngle);
    }

    void RecoilMove()
    {
        if (movingObject == null)
            return;

        Vector3 currentPosition = movingObject.transform.localPosition;

        Vector3 newPosition;

        if (movingForward)
        {
            newPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);

            if (Mathf.Approximately(newPosition.x, targetPosition.x))
            {
                movingForward = false;
            }
        }
        else
        {
            newPosition = Vector3.MoveTowards(currentPosition, originalPosition, movementSpeed * Time.deltaTime);

            if (Mathf.Approximately(newPosition.x, originalPosition.x))
            {
                //rotating = false;
            }
        }
        movingObject.transform.localPosition = newPosition;
    }

    public void SettingEmpty()
    {
        if (movingObject == null)
            return;

        Vector3 currentPosition = movingObject.transform.localPosition;

        Vector3 newPosition = movingObject.transform.localPosition;

        if (settingEmpty)
        {
            newPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);

            if (Mathf.Approximately(newPosition.x, targetPosition.x))
            {
                settingEmpty = false;
            }
        }
        movingObject.transform.localPosition = newPosition;
    }

    public void Reloading()
    {
        if (movingObject == null)
            return;

        timeSinceReloading += Time.deltaTime;
        if (timeSinceReloading >= 0.2f)
        {
            movingObject.transform.localPosition = originalPosition;
            timeSinceReloading = 0f;
            reloading = false;
        }

    }
}
