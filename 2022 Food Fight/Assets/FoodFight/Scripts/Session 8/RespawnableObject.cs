using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableObject : MonoBehaviour
{
    private Vector3 startingPosition;
    private Quaternion startingRotation;
    private Rigidbody rigidbody;

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (rigidbody== null)
        {
            startingPosition = transform.position;
            startingRotation = transform.rotation;
        }
        else
        {
            startingPosition = rigidbody.position;
            startingRotation = rigidbody.rotation;
        }
    }

    public void Respawn()
    {
        if(rigidbody == null)
        {
            transform.position = startingPosition;
            transform.rotation = startingRotation;
        }
        else
        {
            // stop inertia
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;

            // reset position
            rigidbody.position = startingPosition;
            rigidbody.rotation = startingRotation;
        }
    }
}
