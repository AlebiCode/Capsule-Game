using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByAle2 : MonoBehaviour
{

 
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.position += Vector3.forward * Time.deltaTime * 2;
    }
}