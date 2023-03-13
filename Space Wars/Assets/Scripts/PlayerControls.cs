using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [Header("Screen position based tuning")]
    [SerializeField] float picthFactor = -2f;
    [SerializeField] float yawFactor = 3f;

    [SerializeField] GameObject[] lasers;

    float xThrow, yThrow;

    Enemy enemy;
    

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * speed;
        float xPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(xPos, -8.61f, 8.61f);

        float yOffset = yThrow * speed * Time.deltaTime;
        float yPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(yPos, -1f, 10f);


        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * picthFactor + yThrow * -10f;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = xThrow * -20f;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }


}
