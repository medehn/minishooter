﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;

    void Start ()
    {

        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}

//TODO: Delete Missiles when out of  sight