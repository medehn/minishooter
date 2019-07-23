using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    public static int _targetCount = 0;
    private float _xPos;
    private float _zPos;
    public int maxSpawnAttemptsPerObstacle = 10;


    private void Start()
    {
        InvokeRepeating("Respawn", 0, Random.Range(2,3));
    }

    //Respawning of targets to create new target when old ones get destroyed
    private void Respawn()
    {
        if (_targetCount < 2)
        {
            Vector3 position = Vector3.zero;
            bool validPos = false;

            int tries = 0;

            while (!validPos && tries < maxSpawnAttemptsPerObstacle)
            {
                tries++;
                position = new Vector3(Random.Range(-8.0f, 8.0f), 0, Random.Range(-8.0f, 8.0f));
                validPos = true;

                float radius = 3f;

                Collider[] colliders = Physics.OverlapSphere(position, radius);

                Debug.Log(colliders.Length);
                foreach (Collider col in colliders)
                {
                    // If this collider is tagged "Obstacle"
                    if (col.tag == "obstacle")
                    {
                        // Then this position is not a valid spawn position
                        validPos = false;
                    }
                }
            }

            // If we exited the loop with a valid position
            if (validPos && _targetCount < 2)
            {
                // Spawn the obstacle here
                Instantiate(target, position + target.transform.position, Quaternion.identity);
                _targetCount++;
                //yield return new WaitForSeconds(Random.Range(2,3));
            }
        }
    }
}