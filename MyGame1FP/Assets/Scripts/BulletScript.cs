using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem bulletCollision;
    public float bulletSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, bulletSpeed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void destroy(){
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Enemy"){
            bulletCollision.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Invoke("destroy", .5f);
        }
    }
}
