using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class LeverEventActions : MonoBehaviour
{

    bool activated = false;

    public float mForceMultiplier;

    //public static event Action trigger; Same as normal event and delegate
    public static event Action <float> triggerAction;

    public void Start()
    {

    }
    void Activate()
    {
        activated = true;
        this.GetComponent<Animator>().Play("LeverPull");
        this.GetComponent<AudioSource>().Play();
    }

    //Gets called at the end of the lever animation
    void EventTrigger()
    {
        //IMPLEMENT INVOKE FUNCTION
        triggerAction.Invoke(mForceMultiplier);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (Input.GetKey(KeyCode.E) && !activated)
            {
                Activate();
            }
        }
    }
}
