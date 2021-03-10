using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    //[SerializeField]
    //private float dampening;

    //private float lastHitDist,
    //              hitDistance;

    //[SerializeField]
    //private int length,
    //            strength;
    

    Rigidbody rb;

    [Range(0f, 10f)]
    [SerializeField] private float multiplier;

    [SerializeField]
    private float moveForce,
                  turnTorque;

    public Transform[] anchors = new Transform[4];
    RaycastHit[] hits = new RaycastHit[4];
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void FixedUpdate()
    {
        for (int i = 0; i < 4; i++)
            ApplyForce(anchors[i], hits[i]);

        rb.AddForce(Input.GetAxis("Vertical") * moveForce * transform.forward);
        rb.AddTorque(Input.GetAxis("Horizontal") * turnTorque * transform.up);


    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, length))
    //    {
    //        float forceAmount = 0;
              ////Hooke's Law
    //        forceAmount = strength * (length - hit.distance) / length + (dampening * (lastHitDist - hitDistance));
    //        rb.AddForceAtPosition(transform.up * forceAmount, transform.position);

    //        lastHitDist = hitDistance;
    //    }
    //    else
    //    {
    //        lastHitDist = length;
    //    }
    }

    void ApplyForce(Transform anchor, RaycastHit hit)
    {
        if (Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            float force = 0;
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            rb.AddForceAtPosition(transform.up * force * multiplier, anchor.position, ForceMode.Acceleration);
        }
    }
}
