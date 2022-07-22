using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStat : MonoBehaviour
{
    public float playerHealth = 0f;
    
    //STATS==============================
    FPMovement movementVar; shotGun attackVar;
    public int mSpeedMult = 10; public int aSpeedMult = 10;
    int currMaxJump = 1;
    //==================================
    
    void Start()
    {
        playerHealth = 100f;
    }
    void Update()
    {
        Debug.Log("PLAYER HEALTH " + playerHealth);
        if(playerHealth<=0){
            Debug.Log("DEAD");
            Destroy(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.P)){
            movementSpeedFunction();
        }
        if(Input.GetKeyDown(KeyCode.O)){
            attackSpeedFunction();
        }
        if(Input.GetKeyDown(KeyCode.I)){
            currMaxJump += 1;
            movementVar.maxJumps = currMaxJump;
        }
    }
    void movementSpeedFunction(){
        movementVar = GameObject.Find("player").GetComponent<FPMovement>();
        movementVar.speed = movementVar.speed + (movementVar.speed*mSpeedMult/15);
    }
    void attackSpeedFunction(){
        attackVar = GameObject.Find("CameranGun").GetComponent<shotGun>();
        attackVar.attackSpeed = attackVar.attackSpeed - (attackVar.attackSpeed*10/100);
    }
}
