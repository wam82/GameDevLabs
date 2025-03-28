﻿using UnityEngine;
using System.Collections;

public class SideBumper : MonoBehaviour
{
    // Recommendation: Make the magnitude of the force adjustable from the inspector

    // TODO: Detect collision with the ball,
    //       then add force towards the appropriate direction.
    //       Remember to use ForceMode.Impulse!

    // Can be done in 1 line of code in an if-statement in a function
    [SerializeField]
    float bumperForce;
    
    Rigidbody mRigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        mRigidbody = collision.collider.GetComponent<Rigidbody>();
        
        if (mRigidbody != null)
        {
            Vector3 forceDirection = collision.contacts[0].normal;
            mRigidbody.AddForce(-forceDirection * bumperForce, ForceMode.Impulse);
        }
    }
}
