using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f; // sets movement speed
    public float gravity = -9.81f; // sets fallspeed

    public Transform groundCheck; // calls a gameobject at the bottom of the character to make sure the object's gravity gets reset at 0 and snaps to floor
    public float groundDistance = 0.4f; // picks a distance to apply the snapping and zeroing from
    public LayerMask groundMask; // so the code knows what the ground is

    Vector3 velocity; // a variable for proper gravity
    bool isGrounded; // a bool to enable a script
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // tests if the ground is within the sphere from the gameobject for ground testing

        if (isGrounded && velocity.y < 0)   // if the object is grounded, and y velocity is 0, snap to ground.
        {                                   //
            velocity.y = -2f;               //
        }                                   //

        float x = Input.GetAxis("Horizontal");  // Gets the left and right movement 
        float z = Input.GetAxis("Vertical");    // Gets the up and down movement

        Vector3 move = transform.right * x + transform.forward * z; // (I beleive) a variable to give a numerical value to the movement

        controller.Move(move * speed * Time.deltaTime); // moves the character


        velocity.y += gravity * Time.deltaTime; // fancy way to properly calculate gravity

        controller.Move(velocity * Time.deltaTime); // applies the calculated gravity
    }
}
