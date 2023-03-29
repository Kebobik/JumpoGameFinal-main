using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{  
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public static Vector2 lastCheckPointPos = new Vector2(0,0);

    private void Awake()
    {
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }
     public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}


   