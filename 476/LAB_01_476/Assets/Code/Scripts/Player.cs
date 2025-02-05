using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool walking = false;
    private bool running = false;

    private void Update()
    {
        Camera cam = Camera.main;

        animator.SetBool("Walk", walking);
        animator.SetBool("Run", running);
        //TODO 1: control movement (hint:using Input.GetAxis)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        //movement = Vector3.ProjectOnPlane(movement, Vector3.up);

        if (movement.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            //TODO 2: Control your animator
            walking = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                running = true;
            }
            else
            {
                running = false;
            }
        }
        else
        {
            //TODO 2: Control your animator
            walking = false;
            running = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //TODO
        }
    }
}