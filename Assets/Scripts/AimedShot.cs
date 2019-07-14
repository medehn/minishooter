using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedShot : MonoBehaviour
{
    public float speed;

    private Transform target;
    

    void Start()
    {
        
        StartCoroutine(FlyTowards());
        StartCoroutine(MissileDestruct());

    }

    //Destroy missile after some seconds 
    IEnumerator MissileDestruct()
    {

        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    IEnumerator FlyTowards()
    {
        target = GameObject.Find("Target(Clone)").transform;
        Vector3 playerPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);

        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.LookRotation(playerPos);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        
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
