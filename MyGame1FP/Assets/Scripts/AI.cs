using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent; public Transform player; public LayerMask playerMask; private Animator anim;
    bool playerInSight; bool playerInAttackRange; bool isWalkPointSet = false; bool walkPointSet = false;
    public Vector3 runTo;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, 50f, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, 15f, playerMask);
        if(playerInAttackRange){
            positioning();

        }
        else if(playerInSight){
            chasePlayer();
        }

    }

    void positioning(){
        if(!walkPointSet && !isMoving){
            standStill();
        }
        else if(!walkPointSet && isMoving){
            randomManuver();
        }
        else if(walkPointSet && isMoving){
            agent.SetDestination(runTo);
            anim.SetFloat("Blend", 1f, 0.1f, Time.deltaTime);
            Invoke("resetRandomWalk", 5f);
        }
        
    }

    void go(){
        isMoving = true;
    }
    void resetRandomWalk(){
        walkPointSet = false;
        isMoving = false;
    }
    void randomManuver(){
        isMoving = true;
        float randomZ = Random.Range(-50f, 50f);
        float randomX = Random.Range(-50f, 50f);

        runTo = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPointSet = true;
        lookAtDestination();
    }
    void chasePlayer(){
        runTo = player.position;
        agent.SetDestination(runTo);
        anim.SetFloat("Blend", 1f, 0.1f, Time.deltaTime);
        lookAtDestination();
        resetRandomWalk();
    }

    void standStill(){
        runTo = transform.position;
        agent.SetDestination(runTo);
        anim.SetFloat("Blend",0f, 0.1f, Time.deltaTime);
        lookAtPlayer();
        Invoke("go",3f);
    }

    void lookAtPlayer(){
        Vector3 lookTo = (player.position - transform.position).normalized;
        Quaternion rotate = Quaternion.LookRotation(new Vector3(lookTo.x, 0 ,lookTo.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime*5f);
    }

    void lookAtDestination(){
        Vector3 lookTo = (runTo - transform.position).normalized;
        Quaternion rotate = Quaternion.LookRotation(new Vector3(lookTo.x, 0 ,lookTo.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime*5f);
    }
}
