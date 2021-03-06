﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour 
{
    private float walkspeed = 8.0f;
    private float sprintSpeed = 12.0f;    

    public void Move(Vector3 direction, bool sprint)
    {
        float speed;

        if (sprint)
        {
            speed = sprintSpeed;           
        }

        else
        {
            speed = walkspeed;
        }

        rigidbody.velocity = new Vector3(0.0f, rigidbody.velocity.y, 0.0f);

        //Vector3 forceX = direction.normalized.x * speed * transform.forward;
        //Vector3 forceZ = direction.normalized.z * speed * transform.right;

        Vector3 forceX = new Vector3(direction.normalized.x * speed, 0, 0);
        Vector3 forceZ = new Vector3(0, 0, direction.normalized.z * speed);

        rigidbody.AddForce(forceX, ForceMode.VelocityChange);
        rigidbody.AddForce(forceZ, ForceMode.VelocityChange);
    }

    public void Jump(float jumpStrength)
    {
        rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);      
    }
}
