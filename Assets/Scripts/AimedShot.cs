using UnityEngine;

public class AimedShot : MonoBehaviour
{
    public float rotSpeed;

    private Rigidbody _rigidbody;
    private GameObject _target;

    void Start()
    {
        _target = GameObject.Find("Target(Clone)");
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        FlyTowards();
    }

    //homing missile script to fly to target automatically
    void FlyTowards()
    {
        if (_target != null)
        {
            Vector3 start = transform.position;
            Vector3 end = _target.transform.position;
            Vector3 dir = end - start;

            //give the missile movement
            _rigidbody.velocity = transform.forward * rotSpeed;

            //get the rotation that is needed to fly towards target
            Quaternion targetRot = Quaternion.LookRotation(dir);

            //set rotation to missile
            _rigidbody.MoveRotation((Quaternion.RotateTowards(transform.rotation, targetRot, 2)));
        }
        else
        {
            //no target? fly straight
            _rigidbody.velocity = transform.forward * rotSpeed;
        }
    }
}