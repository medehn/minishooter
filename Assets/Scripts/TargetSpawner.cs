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
            xPos = Random.Range(-6, 6);
            zPos = Random.Range(-6, 6);

            Instantiate(target, new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            targetCount += 1;
        }
    }
}

