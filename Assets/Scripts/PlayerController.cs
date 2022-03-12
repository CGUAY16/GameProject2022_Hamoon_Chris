using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Constants
    private const float SMOOTH_TIME = 0.07f;

    // References
    private Rigidbody2D rb2d;
    [SerializeField] private PlayerData p_dataRef;

    // Variables
    private float movementInputParam = default;
    private float jumpInputParam = default;
    private Vector2 zeroVector = Vector2.zero;
    
    PlayerData.PlayerSideFacingState currentState = default;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Checking state of face left and face right
        if (p_dataRef.p_FacesLeft == true && transform.localScale.x > 0)
        {
            Vector3 playerScale = transform.localScale;
            playerScale.x = playerScale.x * -1;
            transform.localScale = playerScale;
        }
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

    private void FixedUpdate()
    {
        // This handles player movement
        if (movementInputParam > 0 || movementInputParam < 0)
        {
            Vector2 targetVelocity = new Vector2(movementInputParam * p_dataRef.p_Speed, rb2d.velocity.y);
            rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref zeroVector, SMOOTH_TIME);
        }
        else if (movementInputParam == 0)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
        }
        DoIFlipPlayer();


    }

    /*
     * Functions for player input component.
     * Serves to read input.
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

        // if player is on ground, activate function
        PlayerJump();
    }

    /* 
     * ----------------------------------------------------------------
     * checks if player needs to be flipped based on movementInputParam
     * ----------------------------------------------------------------
     */ 
    public void DoIFlipPlayer()
    {
        currentState = p_dataRef.GetPlayerSideFacingState(currentState, p_dataRef.p_FacesRight, p_dataRef.p_FacesLeft, movementInputParam);
        //Debug.Log(currentState);

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

    private void PlayerJump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpInputParam * p_dataRef.p_jumpForce);
    }
}
