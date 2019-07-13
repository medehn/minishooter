using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    
    

    void Start()
    {

    }

    void Update()
    {
        //movement of lower part with simple horizontal and vertical input, not very "tankish"
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0.0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        
    }
    public float speed;
 

}
