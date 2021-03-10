using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip test;

    [SerializeField]
    private static AudioSource audioSource;

    void Awake()
    {
        // moet nog een test sound in
        test = Resources.Load<AudioClip>("");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Test":
                audioSource.volume = Random.Range(0.5f, 0.7f);
                audioSource.pitch = Random.Range(1f, 1.1f);
                audioSource.PlayOneShot(test);
                break;
        }
    }
}
