using UnityEngine;

public class Controls : MonoBehaviour
{
    public float moveSpeed;

    public GameObject fastShot;
    public GameObject slowShot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(fastShot, shotSpawn.position, shotSpawn.rotation);
        }

        else if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(slowShot, shotSpawn.position, shotSpawn.rotation);
        }

        //movement of lower part with simple horizontal and vertical input, not very "tankish" yet
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0.0f,
            moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}