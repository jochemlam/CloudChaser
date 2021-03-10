using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckpoint : MonoBehaviour
{
    public Transform[] checkPointArray;
    public static int currentCheckpoint = 0;
    public static int currentLap = 0;

    [SerializeField]
    private int totalLapCount = 3;

    public delegate void OnLapsFinishedDelegate();
    public static OnLapsFinishedDelegate onRaceFinished;

    private void Update()
    {
        LapsFinished();
    }

    private void LapsFinished()
    {
        if (currentLap == totalLapCount)
        {
            onRaceFinished();
        }
    }
}
