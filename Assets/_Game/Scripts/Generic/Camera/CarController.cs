using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float maxSpeed = 80,
                  maxBackwardsSpeed = -20,
                  acceleration = 0.1f,
                  accelerationBackwards = 0.05f,
                  currentSpeed,
                   
                  deceleration = 0.1f,

                  rotateSpeed = 0.8f;

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += acceleration;
            }
        } else
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration;
            } 
            if (currentSpeed > 0 && currentSpeed < 1)
            {
                currentSpeed = 0;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (currentSpeed > maxBackwardsSpeed)
            {
                currentSpeed -= accelerationBackwards;
            }
        } else
        {
            if (currentSpeed < 0)
            {
                currentSpeed += deceleration;
            }
            if (currentSpeed < 0 && currentSpeed > -1)
            {
                currentSpeed = 0;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }

        transform.Translate(0, 0, currentSpeed * Time.deltaTime);
    }
}
