using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoving : MonoBehaviour
{
    public static bool isSafeOpened = false;
    [SerializeField] private string newLevel;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel);
            PlayerManager.lastCheckPointPos = new Vector2(-50, 7);
            isSafeOpened = false;
}
    }
}
