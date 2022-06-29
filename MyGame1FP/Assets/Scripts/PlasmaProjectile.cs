using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaProjectile : MonoBehaviour
{
    public GameObject target; public GameObject spawn;
    public Rigidbody rb;
    public float force = 10000f;
    Vector3 endPoint; Vector3 startPoint;
    float distance; public float maxDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        
        GetComponent<Rigidbody>();
        Debug.Log("test");

        rb.AddRelativeForce(0, 0, force*Time.deltaTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Pow(transform.position.x - startPoint.x, 2) + Mathf.Pow(transform.position.y - startPoint.y, 2) + Mathf.Pow(transform.position.z - startPoint.z, 2);
        distance = Mathf.Sqrt(distance);
        
        if(distance >= maxDistance){
            Destroy(gameObject);
            Debug.Log("gone");
        }
    }
}
