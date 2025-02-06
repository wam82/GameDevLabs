using UnityEngine;

using System.Collections.Generic;
using Utilities;

public class FlockAgent : MonoBehaviour 
{
    public bool debug;
    public Transform target;
    public float neighborRadius = 5;
    public float avoidanceRadius = 3.5f;
    public float cohesionFactor = 1.5f;
    public float avoidanceFactor = 2f;
    public float seekSpeed = 3f;

    private Vector3 movement;
    
	void Update () 
    {
        Collider[] neighbors = GetNeighborContext();
        Cohesion(neighbors);
        Avoidance(neighbors);
        Alignment(neighbors);
        Seek();

        // TODO : steer and align the boid in the direction of the movement
        transform.position += movement * seekSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

        movement = Vector3.zero;
    }

    public Collider[] GetNeighborContext()
    {
        Collider[] neighbors = Physics.OverlapSphere(transform.position, neighborRadius);

        if (debug)
            DebugUtil.DrawWireSphere(transform.position, Color.Lerp(Color.white, Color.red, neighbors.Length), neighborRadius);

        return neighbors;
    }

    // This is the force that keeps the swarm together.
    void Cohesion(Collider[] neighbors)
    {
        // movement is equal to the relative offset from the flock agent to the center of the flock
        // TODO
        Vector3 cohesiveMovement = Vector3.zero;

        foreach (Collider neighbor in neighbors)
        {
            if (neighbor.transform == this.transform)
            {
                continue;
            }

            cohesiveMovement += neighbor.transform.position;
        }

        if (neighbors.Length > 0)
        {
            cohesiveMovement /= neighbors.Length;
            cohesiveMovement -= transform.position;
        }

        movement += cohesiveMovement.normalized * cohesionFactor;
    }

    // This is the force that dictates the spacing of the swarm.
    void Avoidance(Collider[] neighbors)
    {
        // movement is equal to the average of the sum of all vectors going from neighbor to flock agent within the avoidance radius
        // TODO
        Vector3 avoidanceMovement = Vector3.zero;
        float squareRadius = avoidanceRadius * avoidanceRadius;

        foreach (Collider neighbor in neighbors)
        {
            if (neighbor.transform == this.transform)
            {
                continue;
            }

            if (Vector3.SqrMagnitude(neighbor.transform.position - transform.position) <= squareRadius)
            {
                Vector3 neighborToAgent = transform.position - neighbor.transform.position;

                if (neighborToAgent == Vector3.zero)
                {
                    neighborToAgent = Random.insideUnitSphere * 0.1f;
                }

                avoidanceMovement += neighborToAgent;
            }
        }

        if (neighbors.Length > 0)
        {
            avoidanceMovement = avoidanceMovement.normalized / neighbors.Length;
        }

        movement += avoidanceMovement.normalized * avoidanceFactor;
    }

    // This "force" has each of the agents try to synch their orientation.
    void Alignment(Collider[] neighbors)
    {
        // alignedDirection is equal to the average direction of neighbors 
        // TODO
        Vector3 alignmentDirection = Vector3.zero;
        foreach (Collider neighbor in neighbors)
        {
            if (neighbor.transform == this.transform)
            {
                continue;
            }

            FlockAgent neighborFlockAgent = neighbor.GetComponent<FlockAgent>();
            alignmentDirection += neighborFlockAgent.movement;
        }
        
        if (neighbors.Length > 0)
        {
            alignmentDirection = alignmentDirection.normalized / neighbors.Length;
        }

        movement += alignmentDirection.normalized;
    }

    // This has each agent try to seek out its current target. It's possible to do this
    // in the FlockMind as well, but this is more of a "distributed" swarm model, so each agent
    // gets to make its decisions locally.
    void Seek()
    {
        // TODO
        Vector3 desiredVelocity = target.position - transform.position;
        movement += desiredVelocity.normalized * seekSpeed;
        // desiredVelocity = Vector3.ClampMagnitude(desiredVelocity, seekSpeed);
        // movement += desiredVelocity * Time.deltaTime;
    }
}
