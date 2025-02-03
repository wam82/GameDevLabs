using UnityEngine;
using System.Collections;

public class Plunger : MonoBehaviour
{
    // Recommendation: Make the magnitude of the force adjustable from the inspector
    
    // TODO: Check if the ball is in the trigger zone.
    //       If it is and the player presses the launch button,
    //       then add a force to push the ball forward.
    //       Don't forget to use ForceMode.Impulse!

    // Can be done in 1 line of code in an if-statement in a functio

    [SerializeField]
    string mButtonName;
    
    [SerializeField]
    float launchForce;
    
    Rigidbody mRigidbody;
    
    private void OnTriggerEnter(Collider collider)
    {
        mRigidbody = collider.GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider collider)
    {
        mRigidbody = null;
    }

    private void Update()
    {
        if (mRigidbody != null && Input.GetButton(mButtonName))
        {
            mRigidbody.AddForce(transform.forward * launchForce, ForceMode.Impulse);
        }
    }
}
