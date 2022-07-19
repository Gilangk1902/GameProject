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
    public GameObject projectlie;
    public GameObject projectileSpawnPoint;
    public GameObject eye;
    public bool readyToFire = true;
    public bool targetLocked = true;
    int burstCount = 0;
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
            targeting();
            positioning();
            attacking();
        }
        else if(playerInSight){
            chasePlayer();
        }
        else if (!playerInSight){
            patrol();
        }
    }
    void shoot(){
        Instantiate(projectlie, projectileSpawnPoint.transform.position, transform.rotation);
    }
    void waitShoot(){
        readyToFire = true;
    }
    void lostTarget(){
        targetLocked = false;
    }
    void targeting(){
        RaycastHit hit;
        float thickness = 2f;
        if(Physics.SphereCast(eye.transform.position, thickness, eye.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, playerMask)){
            targetLocked = true;
            Debug.Log("target locked");
        }
        else
            Invoke("lostTarget", 1f);
    }
    void attacking(){
        if(!isMoving && readyToFire && targetLocked == true){
            shoot();
            readyToFire = false;
            if(burstCount < 4){
                Invoke("waitShoot", 0.5f);
                burstCount++;
            }
            else{
                Invoke("waitShoot", 2f);
                burstCount=0;
            }
        }
        else{
            //bruh
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
    void patrol(){
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
