using UnityEngine;
using System.Collections;

public class ApplyForceAtOffset : MonoBehaviour
{
    [SerializeField]
    float mForce;

    [SerializeField]
    Vector3 mDirection = Vector3.forward;

    [SerializeField]
    string mButtonName;

    [SerializeField]
    Vector3 mOffset;

    Rigidbody mRigidbody;

    void Awake()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        // TODO: Detect player's input (You can use mButtonName - It's convenient, but configure it first in the inspector!)
        //       Apply the force at the appropriate direction and at the correct position (make use of mOffset)

        // IMPORTANT: You must know the difference between Local Space and World Space!
        //            Ask yourself these questions:
        //                When the flipper is moving or rotating, what is its LOCAL forward direction at any time? Is this changing?
        //                What about its World Space forward direction? Is this always the same?

        // Can be done in 2 lines of code
        
        // Check for player input
        if (Input.GetButton(mButtonName))
        {
            // Apply force at the offset position
            Vector3 worldOffset = transform.TransformPoint(mOffset); // Convert the local offset to world space
            Vector3 worldDirection = transform.TransformDirection(mDirection); // Convert local direction to world space

            // Apply the force at the calculated world offset position in the calculated direction
            mRigidbody.AddForceAtPosition(worldDirection * mForce, worldOffset, ForceMode.Impulse);
        }
    }
}
