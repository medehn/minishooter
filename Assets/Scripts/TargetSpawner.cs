using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    public static int targetCount;
    private float xPos;
    private float zPos;

    private bool started;


    void Start()
    {
        StartCoroutine(TargetDrop(2));
    }

    private void Update()
    {
        //after Start() coroutine and if less than 2 targets - respawn
        if (targetCount < 2 && started)
        {
            targetCount++;
            StartCoroutine(Respawn());
        }
    }
    
    //initial two targets are spawned in the Start()
    IEnumerator TargetDrop(int spawnDelay)
    {
        while (targetCount < 2)
        {
            xPos = Random.Range(-6, 6);
            zPos = Random.Range(-6, 6);
            
            Instantiate(target, new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
            started = true;
            targetCount++;
            yield return new WaitForSeconds(1);
        }
    }
    
    //Respawning of targets to create new target when old ones get destroyed
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        
        xPos = Random.Range(-6, 6);
        zPos = Random.Range(-6, 6);

        Instantiate(target, new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
    }
    
    



}

