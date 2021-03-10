using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavigation : MonoBehaviour
{
    NavMeshAgent agent;

    private Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(58, 62);
        agent.acceleration = Random.Range(38, 42);
        
    }

    void Update()
    {
        //MoveToTarget();
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -4, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 4, 0);
        }

        transform.Translate(0, 0, 90 * Time.deltaTime); 
    }

    private void MoveToTarget()
    {
        target = new Vector3(0, 0, 0);
        NavMeshPath path = new NavMeshPath();

        for (int k = 0; k < 50 && !agent.CalculatePath(target, path); k++)
        {
            target = new Vector3(transform.position.x - 5.01f,
             transform.position.y + Random.Range(-5, 5),
             transform.position.z);
        }
        if (!agent.CalculatePath(target, path))
        {
            for (int k = 0; k < 50 && !agent.CalculatePath(target, path); k++)
            {
                target = new Vector3(transform.position.x - 4.01f,
                 transform.position.y + Random.Range(-5, 5),
                 transform.position.z);
            }
        }
        if (!agent.CalculatePath(target, path))
        {
            for (int k = 0; k < 50 && !agent.CalculatePath(target, path); k++)
            {
                target = new Vector3(transform.position.x - 3.01f,
                 transform.position.y + Random.Range(-5, 5),
                 transform.position.z);
            }
        }
        if (!agent.CalculatePath(target, path))
        {
            for (int k = 0; k < 50 && !agent.CalculatePath(target, path); k++)
            {
                target = new Vector3(transform.position.x - 2.01f,
                 transform.position.y + Random.Range(-5, 5),
                 transform.position.z);
            }
        }
        if (!agent.CalculatePath(target, path))
        {
            for (int k = 0; k < 50 && !agent.CalculatePath(target, path); k++)
            {
                target = new Vector3(transform.position.x - 1.01f,
                 transform.position.y + Random.Range(-5, 5),
                 transform.position.z);
            }
        }
        if (!agent.CalculatePath(target, path))
        {
            for (int k = 0; k < 50 && !agent.CalculatePath(target, path); k++)
            {
                target = new Vector3(transform.position.x - 0.01f,
                 transform.position.y + Random.Range(-5, 5),
                 transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
                target.z -= 16;
        }
        if (Input.GetKey(KeyCode.D))
        {
            target.z += 16;
        }

        Debug.Log(agent.CalculatePath(target, path));

        agent.SetDestination(target); //Move towards point
    }
}
