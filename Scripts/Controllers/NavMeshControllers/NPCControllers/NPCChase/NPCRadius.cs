using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCRadius : MonoBehaviour {

    public float lookRadius = 250f;
    Transform target;
    NavMeshAgent agent;
    public float distance;
    public float distanceLimit = 220;
    public Renderer agentRend;
    public Collider agentCollider;

    [SerializeField] public static bool passed; // accessed by targethealth script

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

        agentRend = GetComponent<Renderer>();
        agentRend.enabled = false;
        agentCollider = GetComponent<Collider>();
        agentCollider.enabled = false;
    }

	void Update () {
        distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.stoppingDistance = 15;
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
            //agent.stoppingDistance = 0;
        }
        FollowingEnemy();
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public bool isTeleported = true;
    // float that will act like a bool with a countdown
    public float isWaiting = 180;

    void FollowingEnemy()
    {
        // If the timer is up
        if (isWaiting < 0)
        {
            // If the enemy is too far away, or too close, or killed, and has not not teleported
            if ((distance >= distanceLimit || distance <= 3 || passed == true) && isTeleported == false)
            {
                // Hide enemy agent and tp it to the player
                agentRend.enabled = false;
                agentCollider.enabled = false;
                agent.transform.position = target.transform.position;
                // Change tp bool to true, set the passed static death bool to false, and reset the timer
                isTeleported = true;
                passed = false;
                isWaiting = 180;
            }
            // If the enemy has teleported and is within the range to follow the player
            else if (isTeleported == true && distance >= agent.stoppingDistance && distance > 3)
            {
                // Show the enemy and make it chase the player again in case path finding failed
                agentRend.enabled = true;
                agentCollider.enabled = true;
                agent.SetDestination(target.position);
                // Set the tp bool to false so the enemy can be teleported again,
                isTeleported = false;
                // Reset the timer bool so the enemy can be teleported again
                /// Fixes bug where enemy would sometimes tp and show immediately with invincibility
                isWaiting = 0;
            }
        }
        // Constantly reduce countdown
        isWaiting -= Time.deltaTime;
    }
}