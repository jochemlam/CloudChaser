using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private bool FirstPersonView = false; //If this is false, it will run on Third Person View
    Camera cam;
    private string vehicle = "PlayerRacer"; //Specifies the object this script will be getting current speed data from
    private float speed,
                  standardFOV,
                  maxFOV = 90,
                  step,
                  minimumSpeed = 50, //Minimum speed for changing Field of View
                  tCameraSmoothingTPV = 10, //Camera smoothing Translate TPV (Lower = Smoother)
                  rCameraSmoothingTPV = 5, //Camera smoothing Rotate TPV (Lower = Smoother)

                  rCameraSmoothingFPV = 5; //Camera smoothing Rotate FPV (Lower = Smoother)
    [SerializeField] private Vector3 tpvOffset = new Vector3(0, 4, -10),
                                     fpvOffset = new Vector3(0, 2, 1);
    private CarController cc;
    private Transform target;
    private void Start()
    {
        cam = transform.GetChild(0).GetComponent<Camera>();
        cc = GameObject.Find(vehicle).GetComponent<CarController>();
        target = GameObject.Find(vehicle).transform;

        standardFOV = cam.fieldOfView;
        step = (maxFOV - cam.fieldOfView) / (cc.GetMaxSpeed() - minimumSpeed);
    }

    private void FixedUpdate()
    {   
        //If FirstPersonView is true, it will run on First Person View. Else it will run on Third Person View.
        if (FirstPersonView)
        {
            FPVRotateSmoothing(); 
        } else
        {
            speed = cc.GetCurrentSpeed();
            if (speed >= minimumSpeed)
            {
                TPVChangeFOV();
            }
            TPVSmoothFollowTarget();
        }
    }

    //Changes FOV for Third Person View (TPV)
    private void TPVChangeFOV()
    {
        float c = speed - minimumSpeed;
        cam.fieldOfView = standardFOV + (c * step);
    }

    //Follows vehicle in Third Person View (TPV)
    private void TPVSmoothFollowTarget()
    {
        var targetPos = target.TransformPoint(tpvOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, tCameraSmoothingTPV * Time.deltaTime);

        var dir = target.position - transform.position;
        var rot = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, rCameraSmoothingTPV * Time.deltaTime);
    }

    //Rotates in First Person View (FPV)
    private void FPVRotateSmoothing()
    {
        transform.position = target.TransformPoint(fpvOffset);

        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rCameraSmoothingFPV * Time.deltaTime);
    }
}
