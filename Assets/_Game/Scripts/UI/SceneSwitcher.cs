using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public delegate string SceneSwitch();
    public static event SceneSwitch OnSceneSwitch;
    public static void LoadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);

        if (OnSceneSwitch != null)
            OnSceneSwitch();
    }
}
