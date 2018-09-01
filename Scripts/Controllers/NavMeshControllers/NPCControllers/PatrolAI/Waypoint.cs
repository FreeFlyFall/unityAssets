using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Attach this script to an empty object to act as a waypoint
    // The empty object should not affect navmesh baking
    // Make sure Gizmos are enabled to see the radius
    [SerializeField]
    protected float radius = 1.0f;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
