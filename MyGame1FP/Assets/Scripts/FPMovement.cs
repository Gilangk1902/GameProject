using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    public CharacterController controller;
    //STATS==========================================
    public float speed = 12f;
    public float jumpHeight = 9f;
    public int maxJumps = 1;
    //=============================================
    int jumps = 1;
    bool isGrounded;
    Gravity gravVar;
    // Start is called before the first frame update
    void Start()
    {
        gravVar = GameObject.Find("player").GetComponent<Gravity>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        jump();
        isLanded();
    }

    void movement(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);
    }
    void jump(){
        if(jumps<maxJumps && Input.GetButtonDown("Jump")){
            jumps++;
            gravVar.velocity.y = jumpHeight;
        }
    }
    void isLanded(){
        if(gravVar.isGrounded){
            jumps = 0;
        }
        
    }

    

    
}
