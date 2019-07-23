using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public GameObject effect;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    //Destroy target and missile on impact
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("target"))
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(other.gameObject, 0.1f);
            Destroy(gameObject);

            TargetSpawner.TargetCount--;
        }

        else if (other.gameObject.CompareTag(("wall")))
        {
            Destroy(gameObject);
        }
    }
}