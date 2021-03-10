using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlopes : MonoBehaviour
{
    [SerializeField] Transform rayChecker;

    // Update is called once per frame
    void Update()
    {
        RotateSlope();
    }


    private void RotateSlope()
    {
        RaycastHit targetHit;
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        Debug.DrawRay(rayChecker.position, Vector3.down * 50);
        if (Physics.Raycast(rayChecker.position, Vector3.down * 50, out targetHit, 100))
        {
            Vector3 targetDir = new Vector3(targetHit.point.x, targetHit.point.y + 0.9f, targetHit.point.z) - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, 1 * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
