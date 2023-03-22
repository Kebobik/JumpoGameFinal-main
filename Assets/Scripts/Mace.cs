using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 4;

    float startingY;
    float startingX;
    int dir = 1;
  
    void Start()
    {
        startingY = transform.position.y;
        startingX = transform.position.x;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if(transform.position.y < startingY || transform.position.y > startingY + range)
        dir *= -1;

        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if (transform.position.x < startingX || transform.position.x > startingX + range)
            dir *= -1;
    }   
}
