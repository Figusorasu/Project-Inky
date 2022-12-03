using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    // InputSystem / Movement
    private float inputHorizontal;
    private float inputVertical;
    public float speed;
    private Transform tr;
    private Rigidbody2D rb; // Use to get player's Rigitbody Unity component in script
    private bool facingRight = true; 
    private float currentSpeed;

    // Jump
    public float jumpForce;
    public Transform groundCheck; // Use Unity Transform object to detect collision with ground
    public float checkRadius;
    public int extraJumps;
    public int extraJumpsValue;
    public float gravScale;

    // Ground Detection
    public LayerMask whatIsGround; // Unity layer with objects that are ground
    public LayerMask whatIsPlatform;
    public bool isGrounded;
    public bool isOnPlatform;

    // Ladders
    public LayerMask whatIsLadder;
    public bool canClimbLadder;
    public bool isClimbing = false;
    

    // Animator
    public Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        currentSpeed = speed;
    }

    void FixedUpdate() {
        // Movement
        rb.velocity = new Vector2(inputHorizontal * currentSpeed, rb.velocity.y);
     
        // Renew jumps
        if(isGrounded) {
            extraJumpsValue = extraJumps;
        }

        // Flip Player
        if(facingRight == false && rb.velocity.x > 0) {
            Flip();
        } else if (facingRight == true && rb.velocity.x < 0) {
            Flip();
        }

        // Climbing
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, 5, whatIsLadder);

        if(hitInfo.collider != null) {
            canClimbLadder = true;
        }
        else {
            canClimbLadder = false;
        }

        if(canClimbLadder && (inputVertical != 0 || !isGrounded)) {
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * currentSpeed);
            rb.gravityScale = 0;
        } else {
            rb.gravityScale = gravScale;
        }

        // Ground and interactable objects checking
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isOnPlatform = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsPlatform);

        #region ANIMATIONS:
           /* if(rb.velocity.x != 0) {
                anim.SetBool("IsMoving", true);
            } else {
                anim.SetBool("IsMoving", false);
            }

            if(rb.velocity.y > 0) {
                anim.SetBool("Jump", true);
                anim.SetBool("Fall", false);
            } else if(rb.velocity.y < 0) {
                anim.SetBool("Fall", true);
                anim.SetBool("Jump", false);
            }
            
            if(isGrounded || inputHorizontal == 0) { 
                anim.SetBool("Fall", false); 
                anim.SetBool("Jump", false);
            }*/
        #endregion
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Move(InputAction.CallbackContext ctx) {
        inputVertical = ctx.ReadValue<Vector2>().y;
        inputHorizontal = ctx.ReadValue<Vector2>().x;
    }
    
    void Jump(InputAction.CallbackContext ctx) {
        if(ctx.performed && isGrounded) {
            rb.velocity = Vector2.up * jumpForce;
        } else if(ctx.performed && !isGrounded && extraJumpsValue > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumpsValue--;
        }
        
        if(ctx.canceled && rb.velocity.y > 0) {
            rb.velocity = Vector2.up * (jumpForce * 0.5f);
        }
    }
    
    void Run(InputAction.CallbackContext ctx) {
        if(ctx.performed && !isClimbing) {
            currentSpeed = speed * 2;
        } else {
            currentSpeed = speed;
        }
    } 

    


}