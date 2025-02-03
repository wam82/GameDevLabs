using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float mForce = 10;

    public void Start()
    {
        LeverEventDelegate.trigger += DeleteCube;
        LeverEventActions.triggerAction += PushMultiplied;
        //TODO:
        //
        // Add DeleteCube() function to the Delegete Trigger
        // Add PushMultiplied function to the Actions Trigger
        //
    }
    public void Push()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * mForce, ForceMode.Impulse);
    }

    public void PushMultiplied(float mMultiplier)
    {
        GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * mForce * mMultiplier, ForceMode.Impulse);
    }

    public void DeleteCube()
    {
        Destroy(this.gameObject);
    }
}
