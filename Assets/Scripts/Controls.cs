using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float moveSpeed;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        
        //movement of lower part with simple horizontal and vertical input, not very "tankish"
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0.0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        
    }

}
