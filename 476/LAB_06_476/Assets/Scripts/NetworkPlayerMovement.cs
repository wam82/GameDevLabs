using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using HelloWorld;

public class NetworkPlayerMovement : NetworkBehaviour
{
    readonly float speed = 10.0f;
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();


    // Update is called once per frame
    void Update()
    {
        if (IsOwner || IsServer)
        {

            Vector3 movement = GetMovement();
            //TODO:
            //Hint: If movement is zero, you don't need to do anything
            //This is to prevent server/client keep overriding the position of the player
            if (movement == Vector3.zero)
            { 
                return;
            }

            //TODO:
            //Hint:If you are the server, you can just move the player and update the position variable
            //If you are the client, you need to send an RPC to the server to move the player and update the position variable
            if (IsServer)
            {
                transform.position += movement;
                Position = gameObject.GetComponent<HelloWorldPlayer>().Position;
                Position.Value = transform.position;
            }

            if (IsOwner)
            {
                SubmitPositionRequestServerRpc(movement);
            }
        }
    }

    [ServerRpc]
    void SubmitPositionRequestServerRpc(Vector3 movement, ServerRpcParams rpcParams = default)
    {
        //TODO:
        transform.position += movement;
        Position = gameObject.GetComponent<HelloWorldPlayer>().Position;
        Position.Value = transform.position;
    }

    Vector3 GetMovement()
    {
        Vector3 movement = Vector3.zero;
        
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        return movement + new Vector3(horizontal, 0, vertical);
    }
}
