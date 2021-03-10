using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        if (xInput != 0 || yInput != 0)
        {
            rb.AddForce(xInput / 4, 0, yInput / 4,ForceMode.VelocityChange);
        }
    }
}
