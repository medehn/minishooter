using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    public static int TargetCount;
    private float _xPos;
    private float _zPos;
    private bool _started;

    //TODO: dont spawn targets in walls

    void Start()
    {
        StartCoroutine(TargetDrop(2));
    }

    private void Update()
    {
        //after Start() coroutine and if less than 2 targets - respawn
        if (TargetCount < 2 && _started)
        {
            TargetCount++;
            StartCoroutine(Respawn());
        }
    }

    //initial two targets are spawned in the Start()
    private IEnumerator TargetDrop(int spawnDelay)
    {
        while (TargetCount < 2)
        {
            _xPos = Random.Range(-6, 6);
            _zPos = Random.Range(-6, 6);

            //TODO: dont spawn in walls or target or player!
//            float radius = target.GetComponent<SphereCollider>().radius;
//            
//            if (Physics.CheckSphere(new Vector3(xPos, 0.5f, zPos), radius))
//            {
//                xPos = Random.Range(-6, 6);
//                zPos = Random.Range(-6, 6);
//                
//            }

            Instantiate(target, new Vector3(_xPos, 0.5f, _zPos), Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
            _started = true;
            TargetCount++;
            yield return new WaitForSeconds(1);
        }
    }

    //Respawning of targets to create new target when old ones get destroyed
    private IEnumerator Respawn()
    {
        float rn = Random.Range(2.0f, 3.0f);
        yield return new WaitForSeconds(rn);

        _xPos = Random.Range(-6, 6);
        _zPos = Random.Range(-6, 6);

        Instantiate(target, new Vector3(_xPos, 0.5f, _zPos), Quaternion.identity);
    }
}