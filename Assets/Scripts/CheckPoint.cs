using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool isCaptured = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && !isCaptured)
        {
            PlayerManager.lastCheckPointPos = transform.position;
            AudioManager.instance.Play("Checkpoint");
            GetComponent<SpriteRenderer>().color = Color.blue;
            isCaptured = true;
        }
    }
}

  
