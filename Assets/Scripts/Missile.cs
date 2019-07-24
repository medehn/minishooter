using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public GameObject effect;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Destroy target and missile on impact, trigger FX
        if (other.gameObject.CompareTag("target"))
        {
            GameObject explosion = Instantiate(effect, transform.position, transform.rotation) as GameObject;
            Destroy(other.gameObject, 0.1f);
            Destroy(gameObject);
            Destroy(explosion, .5f);

            TargetSpawner.TargetCount--;
        }

        //Destroy missile if it hits a wall or obstacle
        else if (other.gameObject.CompareTag(("wall")) || other.gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}