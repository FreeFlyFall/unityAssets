using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCRadius : MonoBehaviour {

    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

	void Start () {
        // Use the target as a public player object declared in a
        // singleton in the PlayerManager;
        // Just a reference to the player object
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.stoppingDistance = 2;
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack logic here
                //face target
                FaceTarget();

            }
        }
        else
        {
            agent.stoppingDistance = 0;
        }
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
