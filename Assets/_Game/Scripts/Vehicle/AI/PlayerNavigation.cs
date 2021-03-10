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
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        target = new Vector3(0, 0, 0);
        NavMeshPath path = new NavMeshPath();

        int loopFilter = 0;
        while (!agent.CalculatePath(target, path) && loopFilter < 250)
        {
            target = new Vector3(transform.position.x - 5,
                             transform.position.y + Random.Range(-5, 5),
                             transform.position.z);

            if (Input.GetKey(KeyCode.A))
            {
                target.z -= 16;
            }
            if (Input.GetKey(KeyCode.D))
            {
                target.z += 16;
            }
        }

        Debug.Log(agent.CalculatePath(target, path));

        agent.SetDestination(target); //Move towards point
    }
}
