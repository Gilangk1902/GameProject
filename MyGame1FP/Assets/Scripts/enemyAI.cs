using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Transform enemy;
    public LayerMask ground, playerMask;
    public CharacterController controller;
    public GameObject projectile; 
    public GameObject spawner;
    public float radius = 50f; public float speed = 3.5f;
    public float attackRadius = 5f;
    public Vector3 runTo;
    bool playerInSight; bool playerInAttackRange; bool walkPointSet = false;

    
    void Start()
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position ,radius, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRadius, playerMask);
        if(playerInAttackRange){
            if(walkPointSet == false){
                searchManuverPoint();
                attack();
            }
            chaseInAttackRange();
        }
        else if(playerInSight){
            searchPoint();
            chase(); 
        }
    }

    void leftRightMovement(){
            int x = Random.Range(-1,1);

            Vector3 move = transform.right * x;

            controller.Move(move*speed*Time.deltaTime);
    }
    void chase(){
        agent.SetDestination(runTo);
        lookAt();
    }

    void chaseInAttackRange(){
        agent.SetDestination(runTo);
        lookAt();
    }
    void searchPoint(){
        runTo = player.position;
    }
    void searchManuverPoint(){
        float randomZ = Random.Range(-radius, radius);
        float randomX = Random.Range(-radius, radius);

        runTo = new Vector3 (transform.position.x + randomX , transform.position.y, transform.position.z + randomZ);

        walkPointSet=true;
        Invoke("resetRandomWalk", 5f);
    }

    void inAttackRange(){ // moving left and right (Not very succesfull)
        float x = Random.Range(-5,5);
        runTo = transform.localPosition + new Vector3(5f, 0, 0);

        walkPointSet=true;
        Invoke("resetRandomWalk", 5f);
    }
    void resetRandomWalk(){
        walkPointSet = false;
    }
    void attack(){
        Instantiate(projectile, spawner.transform.position, transform.rotation);
    }
    void lookAt(){
        Vector3 lookTo = (runTo - transform.position).normalized;
        Quaternion rotate = Quaternion.LookRotation(new Vector3(lookTo.x, 0 ,lookTo.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime*5f);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }

    void lookAtPlayer(){
        transform.LookAt(player);
    }

}


