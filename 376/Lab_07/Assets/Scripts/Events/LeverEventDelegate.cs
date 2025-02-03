using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LeverEventDelegate : MonoBehaviour
{
    
    bool activated = false;
    public delegate void OnEventTrigger();
    public static event OnEventTrigger trigger;
    //public static OnEventTrigger trigger; //This version, any class can trigger the event
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
        trigger.Invoke();
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
