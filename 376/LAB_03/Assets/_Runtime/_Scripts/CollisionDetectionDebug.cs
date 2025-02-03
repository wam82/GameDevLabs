using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class CollisionDetectionDebug : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(gameObject.name + " -> OnCollisionEnter: " + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        print(gameObject.name + " -> OnCollisionStay: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        print(gameObject.name + " -> OnCollisionExit: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(gameObject.name + " -> OnTriggerEnter: " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        print(gameObject.name + " -> OnTriggerStay: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        print(gameObject.name + " -> OnTriggerExit: " + other.gameObject.name);
    }
}
