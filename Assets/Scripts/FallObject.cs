using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    Rigidbody2D rb;
    void Start() 
    {
        rb = GetComponent<Rigidbody2D> ();
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name.Equals("Player"))
            rb.isKinematic = false;
    }
}

