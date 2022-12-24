using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    #region Variables
        private GameMaster gm;

        [Header("Movement")]
        public float speed;

        private float inputHorizontal;
        private float inputVertical;
        private float currentSpeed;
        private Transform tr;
        private Rigidbody2D rb;
        private bool facingRight = true; 
        [Header("Jump")]

        public float jumpForce;
        public int extraJumps;

        private int extraJumpsValue;
        private bool isFalling;
        private GameObject[] allPlatforms;

        [Space]
        [Header("Ground Detection")]
        public Transform groundCheck; // Use Unity Transform object to detect collision with ground
        public float checkRadius;
        public LayerMask whatIsGround; // Unity layer with objects that are ground
        public LayerMask whatIsPlatform;
        public bool isGrounded;
        public bool isOnPlatform;

        [Space]
        [Header("Animator")]
        public Animator anim;

        public GameObject playerLight;

    #endregion

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        currentSpeed = speed;

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        anim.SetBool("isDead", false);
    }

    void FixedUpdate() {
        // Movement
        rb.velocity = new Vector2(inputHorizontal * currentSpeed, rb.velocity.y);
        
        // Renew jumps
        if(isGrounded) {
            isFalling = false;
            if(gm.DubbleJumpUnlocked) {
                extraJumpsValue = extraJumps;
            }
        }
        

        // Flip Player
        if(facingRight == false && rb.velocity.x > 0) {
            Flip();
        } else if (facingRight == true && rb.velocity.x < 0) {
            Flip();
        }

        // Ground checking
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isOnPlatform = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsPlatform);
    }
    
    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Move(InputAction.CallbackContext ctx) {
        inputVertical = ctx.ReadValue<Vector2>().y;
        inputHorizontal = ctx.ReadValue<Vector2>().x;
    }
    
    public void Jump(InputAction.CallbackContext ctx) {
        if(ctx.performed && isGrounded) {
            rb.velocity = Vector2.up * jumpForce;
        } else if(ctx.performed && !isGrounded && extraJumpsValue > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumpsValue--;
        }
        
        if(ctx.canceled && !isFalling) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            isFalling = true;
        }
    }

    public void Respawn(InputAction.CallbackContext ctx) {
        if(ctx.performed) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}