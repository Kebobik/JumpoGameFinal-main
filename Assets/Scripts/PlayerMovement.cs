using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float normalSpeed;
    public float boostedSpeed;
    public float speedCoolDown;
    public float slowedSpeed;

    [SerializeField]
    GameObject codePanel, closedSafe, openedSafe;
    public static bool isSafeOpened = false;

    PlayerControls controls;
    float direction = 0;
    public Rigidbody2D playerRB;
    public float speed = 400;
    public Animator animator;
    bool isFacingRight = true;
    public float jumpforce = 5;
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
           // openedSafe.SetActive(true);
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
       /* else 
        { 
            if(numberOfJumps == 1 )   
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpforce);  
            numberOfJumps++;
            AudioManager.instance.Play("SecondJump"); 
            
        }*/
              
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
            StartCoroutine("EffectDuration");
        }
        if (col.CompareTag("SlowBoost"))
        {
            speed = slowedSpeed;
            StartCoroutine("EffectDuration");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Safe"))
        {
            codePanel.SetActive(false);
        }
    }
    IEnumerator EffectDuration()
    {
        yield return new WaitForSeconds(speedCoolDown);
        speed = normalSpeed;

    }
}
