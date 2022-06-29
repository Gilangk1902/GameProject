using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterPad : MonoBehaviour
{
    public Vector3 velocity;
    public CharacterController controller;
    bool thurstPad;
    bool thurstPad2;
    public Transform thurstPadChecker;
    public LayerMask pad;
    public float padDistance = 0.4f;
    public float thrustForce = 1f;
    public LayerMask Ground;
    float substractionToOneSecond;
    
    bool stepped = false;
    float maxTime = 0;
    float gravity = 9.81f;
    public float startingVelocity = 900f;
    bool startJumpSequence = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thurstPad = Physics.CheckSphere(thurstPadChecker.position, padDistance, pad);
        thurstPad2 = Physics.CheckSphere(thurstPadChecker.position, padDistance, Ground);

        if(thurstPad){
            startJumpSequence = true;
        }
        jump();
    }
    void jump(){
        if(startJumpSequence == true){
            if(stepped == false){
                substractionToOneSecond = Time.time;
                stepped = true;
            }
            Debug.Log(Time.time - substractionToOneSecond+1);
            if(velocity.y >= 0){
                velocity.y =  startingVelocity - gravity*(Time.time-substractionToOneSecond+1);
                controller.Move(velocity*Time.deltaTime);
            }
        }
    }

}
