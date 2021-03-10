using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
       if (Input.GetKey(KeyCode.A))
       {
            transform.Rotate(0, -2, 0);
       }
       if (Input.GetKey(KeyCode.D))
       {
           transform.Rotate(0, 2, 0);
       }
    }
}
