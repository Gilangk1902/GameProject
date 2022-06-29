using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    GameObject self;
    //STAT
    public float health = 100;
    void Start()
    {
        self = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0){
            Destroy(self);
        }
    }
}
