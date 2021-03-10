using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private GameObject cpHolder;
    private List<Vector3> checkpointsOrigin = new List<Vector3>();

    private int currentCheckpoint = 0;
    private bool finished = false;

    private Vector3 actualTarget;

    private float maxWidthOffset = 15;
    private float maxDistanceFromPoint = 35;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(75, 79);
        agent.acceleration = Random.Range(38, 42);

        //Stores the origin of all Navigation Points inside checkpointsOrigin
        for (int i = 0; i < cpHolder.transform.childCount; i++)
        {
            checkpointsOrigin.Add(cpHolder.transform.GetChild(i).transform.position);
        }
        MoveToNextCheckpoint();
    }

    void Update()
    {
        //Checks if the lap is finished
        if (currentCheckpoint < cpHolder.transform.childCount)
        {
            //Checks if the object is in range of the Navigation Point's randomly assigned position
            if (Vector3.Distance(transform.position, actualTarget) < maxDistanceFromPoint)
            {
                currentCheckpoint++;
                if (currentCheckpoint < cpHolder.transform.childCount)
                {
                    MoveToNextCheckpoint();
                }
            }
        } else
        {
            currentCheckpoint = 0;
        }
    }

    private void MoveToNextCheckpoint()
    {
        actualTarget = new Vector3(0, 0, 0); //Reset the variable
        NavMeshPath path = new NavMeshPath();

        //Loops (max 250 times to prevent potential infinite loops) until a possible path is found
        int loopFilter = 0;
        while (!agent.CalculatePath(actualTarget, path) && loopFilter < 250)
        {
            loopFilter++;
            //Store a random position based on the Navigation Point's origin
            actualTarget = new Vector3(checkpointsOrigin[currentCheckpoint].x + Random.Range(-maxWidthOffset, maxWidthOffset),
                                       checkpointsOrigin[currentCheckpoint].y + Random.Range(-maxWidthOffset, maxWidthOffset),
                                       checkpointsOrigin[currentCheckpoint].z + Random.Range(-maxWidthOffset, maxWidthOffset));
        }
        agent.SetDestination(actualTarget); //Move towards point
    }
}
