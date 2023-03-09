using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Transform Closed;
    public Transform Open;
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Closed.gameObject.SetActive(false);
            Open.gameObject.SetActive(true);
            door.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false);
            AudioManager.instance.Play("Coins");
            Destroy(gameObject);
        }

    }
}

