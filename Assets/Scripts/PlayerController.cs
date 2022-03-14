using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Constants
    [SerializeField] private const float SMOOTH_TIME = 0.07f;
    [SerializeField] private const float GRAV_MULTIPLIER = 2.0f;
    [SerializeField] private const float SHORTHOP_GRAV_MULTIPLIER = 1.5f;

    // References
    private Rigidbody2D rb2d;
    [SerializeField] BoxCollider2D playerFeetCol = default; // object needed to see if player's feet is on ground.
    [SerializeField] private PlayerData p_dataRef;
    PlayerData.PlayerSideFacingState currentState = default;

    // Variables
    private float movementInputParam = default;
    private float jumpInputParam = default;
    private Vector2 zeroVector = Vector2.zero;

    [Header("Ground Check Setup")]
    [SerializeField] Transform playerFeetPoint = default;
    [SerializeField] [Range(0, 1)] float playerFeetContactRange = 0.5f;
    [SerializeField] LayerMask interableGroundLayer = default;


    private void Awake()
    {
        // Caching
        rb2d = GetComponent<Rigidbody2D>();

        /* Checking state of face left and face right, and sets up the other functions linked to this to work properly.*/
        // 
        if (p_dataRef.p_FacesLeft == true && transform.localScale.x > 0)
        {
            Vector3 playerScale = transform.localScale;
            playerScale.x = playerScale.x * -1;
            transform.localScale = playerScale;
        }
        // checks if both params faces left and right are the same value, which they shouldnt be.
        // and sets the state to be according to player's current local scale.
        else if ( ((p_dataRef.p_FacesLeft && p_dataRef.p_FacesRight) == true) 
                    || ((p_dataRef.p_FacesLeft && p_dataRef.p_FacesRight) == false))
        {
            if(transform.localScale.x > 0)
            {
                p_dataRef.p_FacesRight = true;
                p_dataRef.p_FacesLeft = false;
            }
            else if(transform.localScale.x < 0)
            {
                p_dataRef.p_FacesRight = false;
                p_dataRef.p_FacesLeft = true;
            }
        }

        currentState = p_dataRef.GetPlayerSideFacingState(currentState, p_dataRef.p_FacesRight, p_dataRef.p_FacesLeft, movementInputParam);
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        // Set isJumping to true if condition is met
        if(jumpInputParam == 1 && IsOurPlayerOnGround(p_dataRef.isGrounded))
        {
            p_dataRef.isPlayerJumpin = true;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        DoIFlipPlayer();

        PlayerJump();
        if (p_dataRef.isPlayerJumpin)
        {
            
            p_dataRef.isPlayerJumpin = false;
        }

        IsOurPlayerOnGround(p_dataRef.isGrounded);
    }

    /*
    * -------------------------------------------------------
    *                      PLAYER INPUT
    * -------------------------------------------------------
    */


    void OnMovement(InputValue movementValue)
    {
        movementInputParam = movementValue.Get<float>();
        //Debug.Log(movementInputParam);
        
    }

    void OnJump(InputValue jumpValue)
    {
        jumpInputParam = jumpValue.Get<float>();
        //Debug.Log(jumpInputParam);
        
    }

    /*
     * ----------------------------------------------------------------
     * MOVEMENT
     * ----------------------------------------------------------------
    */

    private void MovePlayer()
    {
        Vector2 targetVelocity = new Vector2(movementInputParam * p_dataRef.p_Speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref zeroVector, SMOOTH_TIME);
    }

    /* 
     * ----------------------------------------------------------------
     * checks if player needs to be flipped based on movementInputParam
     * ----------------------------------------------------------------
     */
    public void DoIFlipPlayer()
    {
        currentState = p_dataRef.GetPlayerSideFacingState(currentState, p_dataRef.p_FacesRight, p_dataRef.p_FacesLeft, movementInputParam);

        // if player faces right, and wants to go left
        if(currentState == PlayerData.PlayerSideFacingState.Right && movementInputParam < 0 && (transform.localScale.x > 0))
        {
            FlipPlayer();
        }
        // if player faces left, and wants to go right
        else if(currentState == PlayerData.PlayerSideFacingState.Left && movementInputParam > 0 && (transform.localScale.x < 0))
        {
            FlipPlayer();
        }
    }

    public void FlipPlayer()
    {
        p_dataRef.p_FacesRight = !p_dataRef.p_FacesRight;
        p_dataRef.p_FacesLeft = !p_dataRef.p_FacesLeft;

        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
    }

    /*
     * --------------------------------------------------------
     *                          JUMP
     * --------------------------------------------------------
     */

    public void PlayerJump()
    {
        if (p_dataRef.isPlayerJumpin)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpInputParam * p_dataRef.p_jumpForce);
            p_dataRef.isPlayerJumpin = false;
        }
        
        if(rb2d.velocity.y < 0) // when player reaches peak jump height, increases gravity for nice fall speed
        {
            //rb2d.velocity += Vector2.up * Physics2D.gravity.y * GRAV_MULTIPLIER * Time.fixedDeltaTime;
            rb2d.gravityScale = 3;
        }
        else if(rb2d.velocity.y > 0 && jumpInputParam != 1) // if player lets go of jump before the peak jump height, he slows down.
        {
            //rb2d.velocity += Vector2.up * Physics2D.gravity.y * SHORTHOP_GRAV_MULTIPLIER * Time.fixedDeltaTime;
            rb2d.gravityScale = 5;
        }
    }

    /*
     * --------------------------------------------------------
     *                      CHECK GROUND
     * --------------------------------------------------------
    */
    private bool IsOurPlayerOnGround(bool result)
    {
        result = false;

        Collider2D[] feetColliderContacts = Physics2D.OverlapCircleAll(playerFeetPoint.position, playerFeetContactRange, interableGroundLayer);

        foreach (Collider2D col in feetColliderContacts)
        {
            if (col != playerFeetCol)
            {
                result = true;

                if(rb2d.gravityScale > 1) // restores gravity scale back to one since gravity scale is changing when we are in the air.
                {
                    rb2d.gravityScale = 1;
                }

                return result;
            }
        }

        return result;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(playerFeetPoint.position, playerFeetContactRange);
    }

}
