using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Missile : MonoBehaviour
{
    public float speed;
    
    

    void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        StartCoroutine(MissileDestruct());
        
    }

    //Destroy missile after some seconds 
    IEnumerator MissileDestruct(){

        yield return new WaitForSeconds (3);
        Destroy (gameObject);
    }

    //Destroy target and missile on impact
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("target"))
        {
            Destroy(other.gameObject, 0.1f);
            Destroy(gameObject);

            TargetSpawner.targetCount--;
        }
    }
    

}

