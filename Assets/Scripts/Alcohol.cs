using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class Alcohol : MonoBehaviour
{
    [SerializeField] CameraShake cameraS;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alcohol"))
        {
            StartCoroutine(cameraS.StartShake());
            Destroy(collision.gameObject);
        }
    } 
}
   
