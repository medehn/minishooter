using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;

    void Start()
    {
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

        else if (other.gameObject.CompareTag(("wall")))
        {
            Destroy(gameObject);
        }
    }
}