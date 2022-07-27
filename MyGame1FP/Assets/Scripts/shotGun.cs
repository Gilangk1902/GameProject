using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Camera cam;
    private Animator anim;
    RaycastHit hit;
    bool isreloading = false;
    //STATS
    public float attackSpeed = 1f;
    bool wait = false;
    int ammo = 2;

    //Enemy Script
    public status enemy;
    void Start()
    {
        enemy = GameObject.Find("Enemy 1").GetComponent<status>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(wait == false && ammo != 0){
                anim.Play("shoot", 0, 0.0f);
                ammo--;
                wait = true;
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        status takeDamage = hit.collider.gameObject.GetComponent<status>();
                        takeDamage.health -= 100;
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        status takeDamage = hit.collider.gameObject.GetComponent<status>();
                        takeDamage.health -= 100;
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        status takeDamage = hit.collider.gameObject.GetComponent<status>();
                        takeDamage.health -= 100;
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        status takeDamage = hit.collider.gameObject.GetComponent<status>();
                        takeDamage.health -= 100;
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        status takeDamage = hit.collider.gameObject.GetComponent<status>();
                        takeDamage.health -= 100;
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        status takeDamage = hit.collider.gameObject.GetComponent<status>();
                        takeDamage.health -= 100;
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        status takeDamage = hit.collider.gameObject.GetComponent<status>();
                        takeDamage.health -= 100;
                    }
                }
                if(Physics.Raycast(cam.transform.position, cam.transform.forward + randomSpread(), out hit)){
                    Instantiate(bullet, hit.point, hit.transform.rotation);
                    
                    if(hit.collider.tag == "Enemy"){
                        status takeDamage = hit.collider.gameObject.GetComponent<status>();
                        takeDamage.health -= 100;
                    }
                }
                Invoke("waitNoMore", attackSpeed);
            }
            else if(ammo == 0 && !isreloading && !wait){
                anim.Play("reloading", 0, 0.0f);
                Invoke("reloading", 3f);
                isreloading = true;
            }
        }
        if(Input.GetKey(KeyCode.R) && ammo < 2 && !isreloading && !wait){
            anim.Play("reloading", 0, 0.0f);
            Invoke("reloading", 3f);
            isreloading = true;
        }
    }
    void reloading(){
        ammo = 2;
        isreloading = false;
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
