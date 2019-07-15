using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    public static int targetCount;

    private float xPos;
    private float zPos;

    private bool started;

    //TODO: dont spawn targets in walls

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

            //TODO: dont spawn in walls or target or player!
//            float radius = target.GetComponent<SphereCollider>().radius;
//            
//            if (Physics.CheckSphere(new Vector3(xPos, 0.5f, zPos), radius))
//            {
//                xPos = Random.Range(-6, 6);
//                zPos = Random.Range(-6, 6);
//                
//            }

            //TODO: FX for spawning
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