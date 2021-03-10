using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterRace : MonoBehaviour
{
    private void FinishRace()
    {
        SceneSwitcher.LoadScene("MainMenu");
    }

    private void OnEnable()
    {
        CarCheckpoint.onRaceFinished += FinishRace;
    }

    private void OnDisable()
    {
        CarCheckpoint.onRaceFinished -= FinishRace;
    }
}
