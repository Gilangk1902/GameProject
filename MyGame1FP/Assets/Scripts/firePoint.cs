using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePoint : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 500f;
    float xRotation = 0f;
    public GameObject bullet;
    public Transform spawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
