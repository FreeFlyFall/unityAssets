using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSimplePatrol : MonoBehaviour
{
    //Dictates whether the agent waits on each node.
    [SerializeField]
    bool patrolWaiting;

    //The total time we wait at each node.
    [SerializeField]
    float totalWaitTime = 3f;

    //The probability of switching direction.
    [SerializeField]
    float switchProbability = 0.0f;

    //The list of all patrol nodes to visit.
    [SerializeField]
    List<Waypoint> patrolPoints;

    //Private variables for base behaviour.
    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward = true;
    float waitTimer;

    // Use this for initialization
    public void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            if (patrolPoints != null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behaviour.");
            }

        }
    }

    public void Update()
    {
        //Check if we're close to the destination.
        if (travelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            travelling = false;

            //If we're going to wait, then wait.
            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        //Instead if we're waiting.
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= totalWaitTime)
            {
                waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navMeshAgent.SetDestination(targetVector);
            travelling = true;
        }
    }

    /// <summary>
    /// Selects a new patrol point in the available list, but
    /// also with a small probability allows for us to move forward or backwards.
    /// </summary>
    private void ChangePatrolPoint()
    {
        //if (UnityEngine.Random.Range(0f, 1f) <= switchProbability)
        //{
              //invert the boolean's current status
        //    patrolForward = !patrolForward;
        //}

        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }
}
