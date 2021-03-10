using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionWithObject : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float timeDuration = 0.2f;

    [Range(0f, 10f)]
    [SerializeField] private float shakeIntensityValue = 8f;

    private void OnCollisionStay(Collision collision) { Camera.main.GetComponent<CameraShake>().Shake(timeDuration, shakeIntensityValue);}
}
