using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractions : MonoBehaviour
{
    public void StartGame()
    {
        SceneSwitcher.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
