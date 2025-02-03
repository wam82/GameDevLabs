using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LeverEvent : MonoBehaviour
{
    public UnityEvent mEvent;
    bool activated=false;
    

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
        mEvent.Invoke();
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
