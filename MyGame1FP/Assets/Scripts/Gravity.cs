using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public CharacterController controller;
    float gravity = -9.81f;
    public Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        playerGravity();
    }
    void gravity2()
    {

    }

    void playerGravity(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        velocity.y += gravity*Time.deltaTime;
        
        controller.Move(velocity*Time.deltaTime);
    }

    

}
