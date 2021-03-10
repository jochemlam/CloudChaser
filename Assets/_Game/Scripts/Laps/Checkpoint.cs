using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTransform.tag))
            return;

        if (transform == playerTransform.GetComponent<CarCheckpoint>().checkPointArray[CarCheckpoint.currentCheckpoint].transform)
        {
            if (CarCheckpoint.currentCheckpoint + 1 <= playerTransform.GetComponent<CarCheckpoint>().checkPointArray.Length)
            {
                RegisterCheckpoint();

                Camera.main.GetComponentInChildren<TextMeshPro>().text = "Checkpoint: " + CarCheckpoint.currentCheckpoint + "Lap: " + CarCheckpoint.currentLap;
            }
        }
    }

    private void RegisterCheckpoint()
    {
        if (CarCheckpoint.currentCheckpoint != playerTransform.GetComponent<CarCheckpoint>().checkPointArray.Length)
        {
            CarCheckpoint.currentCheckpoint++;
        }
        //On last checkpoint
        if (CarCheckpoint.currentCheckpoint == playerTransform.GetComponent<CarCheckpoint>().checkPointArray.Length)
        {
            CarCheckpoint.currentLap++;
            CarCheckpoint.currentCheckpoint = 0;
        }
    }
}
