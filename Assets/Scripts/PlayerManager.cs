using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{  
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public static Vector2 lastCheckPointPos = new Vector2(-50,7);

    private void Awake()
    {
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    void Update()
    {
        
        //coinsText.text = numberOfCoins.ToString();
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
    [SerializeField] CameraShake cameraS;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alcohol"))
        {
            StartCoroutine(cameraS.StartShake());
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Enemy")
        {
            PlayerManager.isGameOver = true;
            AudioManager.instance.Play("Death");
            gameObject.SetActive(false);
        }
    }
}


   