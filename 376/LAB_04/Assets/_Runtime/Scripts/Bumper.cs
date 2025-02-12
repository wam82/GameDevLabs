﻿using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{
    // Recommendation: Make the magnitude of the force and the explosion radius adjustable from the inspector

    // TODO: When the ball collides against the bumper,
    //       apply an explosion force to the ball.
    //       Careful! The explosion should be centered on the bumper, not the ball!
    //       Don't forget to use ForceMode.Impulse!

    // Can be done in 1 line of code in an if-statement in a function
    [SerializeField] float explosionForce;

    [SerializeField] private float explosionRadius;

    Rigidbody mRigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        mRigidbody = collision.collider.GetComponent<Rigidbody>();
        if (mRigidbody != null)
        {
            mRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0f, ForceMode.Impulse);
        }
    }
}
