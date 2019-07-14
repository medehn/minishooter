using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//TODO: clean movement, if no target - shot stands in air
public class AimedShot : MonoBehaviour
{
    public float speed;
    public float force;

    private Transform target;
    private Rigidbody _rigidbody;
    private GameObject _gameObject;

    //TODO: clean curving

    void Start()
    {
        _gameObject = GameObject.Find("Target(Clone)");
        
        _rigidbody = GetComponent<Rigidbody>();

        StartCoroutine(MissileDestruct());

        
    }

    private void Update()
    {
        FlyTowards();
    }

    void FlyTowards()
    {
        if (_gameObject != null)
        {
            float startTime = Time.time;

            Vector3 start = transform.position;
            Vector3 end = _gameObject.transform.position;
            
            //without curving:
            //transform.position = Vector3.MoveTowards(start, end, Time.deltaTime * speed);

            //with curve but not smooth
            if (start != end)
            {
                //float newPercentageBetweenVectors = (Time.time - startTime) * speed;
               
                transform.position = Vector3.Lerp(start, end, 0.05f);
            }

            _rigidbody.velocity = transform.forward * speed;

//            other tries
//            _rigidbody.velocity = transform.forward * speed;
//            target = _gameObject.transform;
//            
//                //find targets position
//
//                Vector3 playerPos = new Vector3(target.transform.position.x, 0,
//                    target.transform.position.z).normalized;
//
//                transform.forward = Vector3.Lerp(start, playerPos,
//                    Time.fixedDeltaTime * .5f );
//
//                _rigidbody.velocity = transform.forward * speed;
//            }
        }
        else
        {
            _rigidbody.velocity = transform.forward * speed;
        }
        

    }
    
    //Destroy missile after some seconds 
    IEnumerator MissileDestruct()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
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
