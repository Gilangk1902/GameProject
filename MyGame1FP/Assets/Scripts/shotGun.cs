using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Camera cam;
    RaycastHit hit;

    //STATS
    public float attackSpeed = 1.5f;
    bool wait = false;

    //Enemy Script
    public status enemy;
    void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<status>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)){
            if(wait == false){
                wait = true;
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Debug.Log("HIT");
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        enemy.health = enemy.health - 6;
                        Debug.Log(enemy.health);
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Debug.Log("HIT");
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        enemy.health = enemy.health - 6;
                        Debug.Log(enemy.health);
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Debug.Log("HIT");
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        enemy.health = enemy.health - 6;
                        Debug.Log(enemy.health);
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Debug.Log("HIT");
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        enemy.health = enemy.health - 6;
                        Debug.Log(enemy.health);
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Debug.Log("HIT");
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        enemy.health = enemy.health - 6;
                        Debug.Log(enemy.health);
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Debug.Log("HIT");
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        enemy.health = enemy.health - 6;
                        Debug.Log(enemy.health);
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Debug.Log("HIT");
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        enemy.health = enemy.health - 6;
                        Debug.Log(enemy.health);
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Debug.Log("HIT");
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        enemy.health = enemy.health - 6;
                        Debug.Log(enemy.health);
                    }
                }

                
                Invoke("waitNoMore", attackSpeed);
            }
        }
    }
    void waitNoMore(){
        wait = false;
    }
    Vector3 randomSpread(){
        float x = Random.Range(-.1f,.1f);
        float y = Random.Range(-.1f,.1f);
        Vector3 spread = new Vector3(x,y,0);
        return spread;
    }
}
