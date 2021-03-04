using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractions : MonoBehaviour
{
    private bool gameIsPaused = false;
    public void ToggleGamePause()
    {
        gameIsPaused = !gameIsPaused;

        if (gameIsPaused)
        {
            ToggleMenuItem(this.gameObject, true);
        }
        else
        {
            ToggleMenuItem(this.gameObject, false);
        }
    }

    public void GoToMenu()
    {
        SceneSwitcher.LoadScene("MainMenu");
    }

    private void ToggleMenuItem(GameObject gameObject, bool state)
    {
        gameObject.SetActive(state);
    }
    public void StartGame()
    {
        SceneSwitcher.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
