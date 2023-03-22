using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float normalSpeed;
    public float boostedSpeed;
    public float slowedSpeed;
  
    [SerializeField] GameObject codePanel, closedSafe, openedSafe;
    public static bool isSafeOpened = false;
    [SerializeField] CameraShake cameraS;
    PlayerControls controls;
    float direction = 0;
    public Rigidbody2D playerRB;
    public float speed = 400;
    public Animator animator;
    bool isFacingRight = true;
    public float jumpforce;
    int numberOfJumps = 0;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {
        normalSpeed = speed;
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openedSafe.SetActive(false);
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
            {
                direction = ctx.ReadValue<float>();
            };
       controls.Land.Jump.performed += ctx => Jump();
    }
    
    public void Update() 
    {
        if (isSafeOpened)
        {
            codePanel.SetActive(false);
            closedSafe.SetActive(false);
        }
    }
    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f,groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(direction));
        
        if(isFacingRight && direction <0 || !isFacingRight && direction >0)
        Flip(); 
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
     void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpforce);
            numberOfJumps++;
            AudioManager.instance.Play("FirstJump");
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Safe") && !isSafeOpened)
        {
            codePanel.SetActive(true);
        }
        if (col.CompareTag("SpeedBoost"))
        {
            speed = boostedSpeed;
            jumpforce = 9;
        }

        if (col.CompareTag("SlowBoost"))
        {
            speed = slowedSpeed;
        }
        if (col.CompareTag("Debuff"))
        {
            speed = normalSpeed;
            StartCoroutine(cameraS.StopShake());
            jumpforce = 7;
        }
        if (col.CompareTag("Alcohol"))
        {
            StartCoroutine(cameraS.StartShake());
        }
        if (col.CompareTag("Portal"))
        {
            isSafeOpened = false;
            codePanel.SetActive(false);
            closedSafe.SetActive(true);
            openedSafe.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Safe"))
        {
            codePanel.SetActive(false);
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayerManager.isGameOver = true;
            AudioManager.instance.Play("Death");
            gameObject.SetActive(false);
            isSafeOpened = false;
            codePanel.SetActive(false);
            closedSafe.SetActive(true);
            openedSafe.SetActive(false);
        }
    }
}
