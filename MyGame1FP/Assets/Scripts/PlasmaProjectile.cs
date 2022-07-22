using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaProjectile : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10000f;
    Vector3 endPoint; Vector3 startPoint;
    float distance; public float maxDistance = 10f;
    private playerStat playerH;
    public LayerMask playerMask;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, force*Time.deltaTime);
        playerH = GameObject.Find("player").GetComponent<playerStat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Pow(transform.position.x - startPoint.x, 2) + Mathf.Pow(transform.position.y - startPoint.y, 2) + Mathf.Pow(transform.position.z - startPoint.z, 2);
        distance = Mathf.Sqrt(distance);
        
        if(distance >= maxDistance){
            Destroy(gameObject);
        }
        hit();
    }

    void hit(){
        if(Physics.CheckSphere(transform.position, 5f, playerMask)){
            playerH.playerHealth-=20f;
            Destroy(gameObject);
        }
    }
}
