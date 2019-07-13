using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    
    public GameObject target;
    public float xPos;
    public float zPos;
    public int targetCount;

    void Start()
    {
        StartCoroutine(TargetDrop());
    }

    IEnumerator TargetDrop()
    {
        while (targetCount < 2)
        {
            xPos = Random.Range(-4, 4);
            zPos = Random.Range(-4, 4);

            Instantiate(target, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            targetCount += 1;
        }
    }
}

