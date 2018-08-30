using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour {


    [SerializeField] Transform destination;

    NavMeshAgent navMeshAgent;

	void Start () {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agenst component is not atached to " + gameObject.name);
        }
        else
        {
            //Method for moving to a point that is set once
            //SetDestination();
        }
    }

    // private void SetDestination()
    // {
    //     if(destination != null)
    //     {
    //        Vector3 targetVector = destination.transform.position;
    //        navMeshAgent.SetDestination(targetVector);
    //     }
    // }

	void Update () {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
    }
}
