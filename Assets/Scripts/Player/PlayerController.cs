using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables

    // Constants
    private const float SMOOTH_TIME = 0.07f;
    private const float STANDARD_GRAV_SCALE = 2f;
    private const float FASTFALL_GRAV_SCALE = 4f;
    

    // References
    private Rigidbody2D rb2d;
    [SerializeField] BoxCollider2D playerFeetCol = default; // object needed to see if player's feet is on ground.
    [SerializeField] private PlayerData p_dataRef;
    [SerializeField] private QuickSandBlock qs_dataRef;

    // Variables
    private float movementInputParam = default;
    private float jumpInputParam = default;
    private Vector2 zeroVector = Vector2.zero;

    // StateMachine Setup
    public P_ActionStateMachine actionSM;
    public P_StandingState standingState;
    public P_JumpingState jumpState;
    public P_CrouchState crouchState;

    [Header("Ground Check Setup")]
    [SerializeField] Transform playerFeetPoint = default;
    [SerializeField] [Range(0, 1)] float playerFeetContactRange = 0.5f;
    [SerializeField] LayerMask interableGroundLayer = default;

    #endregion

    #region Properties

    public float MovementInputParam 
    { 
        get { return movementInputParam; } set { movementInputParam = value; } 
    }

    public float JumpInputParam
    {
        get { return jumpInputParam; } set { jumpInputParam = value; }
    }

    #endregion

    #region Event Initialization

    // Events
    public delegate bool QuickSandChecker();
    public event QuickSandChecker QuickSandCheckerInstance;

    #endregion

    #region Unity MonoBehavior CallBacks
    private void Awake()
    {
        // Caching
        rb2d = GetComponent<Rigidbody2D>();

        // state machine set up
        actionSM = new P_ActionStateMachine();
        standingState = new P_StandingState(this, actionSM);
        jumpState = new P_JumpingState(this, actionSM);
        crouchState = new P_CrouchState(this, actionSM);

        actionSM.Initialize(standingState);

        /* Checking state of face left and face right, and sets up the other functions linked to this to work properly.*/
        // 
        if (p_dataRef.currentFacingState == PlayerData.PlayerXRotationState.Left && transform.localScale.x > 0)
        {
            Vector3 playerScale = transform.localScale;
            playerScale.x = playerScale.x * -1;
            transform.localScale = playerScale;
        }
        p_dataRef.currentFacingState = p_dataRef.GetPlayerXRotationState(this.gameObject, movementInputParam);

        // Setting up Movement State
        p_dataRef.currentCharacterState = PlayerData.CharacterStateMachine.Normal;
    }

    private void Update()
    {
        // Action State Machine
        actionSM.currentState.UpdateInput();
        actionSM.currentState.HandleInput();
        actionSM.currentState.LogicUpdate();
        
        // Checks to see if player is in Quicksand
        if (QuickSandCheckerInstance())
        {
            p_dataRef.currentCharacterState = PlayerData.CharacterStateMachine.QuickSand;
            p_dataRef.isPlayerJumpin = true;
        }
        else
        {
            p_dataRef.currentCharacterState = PlayerData.CharacterStateMachine.Normal;
        }


        // Set isJumping to true if player pressed jump and is on ground or if player is in quicksand
        if(JumpInputParam == 1 && IsOurPlayerOnGround())
        {
            p_dataRef.isPlayerJumpin = true;
        }
    }

    private void FixedUpdate()
    {
        // Action State Machine
        actionSM.currentState.PhysicsUpdate();

        // Checks the state of player movement.
        /*
        switch (p_dataRef.currentCharacterState)
        {
            case PlayerData.CharacterStateMachine.Normal:
                {
                    MovePlayerNormal();
                    break;
                }
            case PlayerData.CharacterStateMachine.QuickSand:
                {
                    MovePlayerQuickSand();
                    break;
                }
        }
        */
        // player flipping
        DoIFlipPlayer();

        // player jump
        //PlayerJumpNormal();

        // ground check
        IsOurPlayerOnGround();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(playerFeetPoint.position, playerFeetContactRange);
    }

    #endregion

    #region Input Handling
    /*
    * -------------------------------------------------------
    *                      PLAYER INPUT
    * -------------------------------------------------------
    */
    void OnMovement(InputValue movementValue)
    {
        MovementInputParam = movementValue.Get<float>();
        //Debug.Log(movementInputParam);

        
    }

    void OnJump(InputValue jumpValue)
    {
        JumpInputParam = jumpValue.Get<float>();
        //Debug.Log(jumpInputParam);
        
    }

    #endregion

    #region Methods
    /*
     * ----------------------------------------------------------------
     * MOVEMENT
     * ----------------------------------------------------------------
    */

    public void MovePlayerNormal()
    {
        Vector2 targetVelocity = new Vector2(MovementInputParam * p_dataRef.p_Speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref zeroVector, SMOOTH_TIME);
    }
    public void MovePlayerQuickSand()
    {
        Vector2 targetVelocity = new Vector2(
            (MovementInputParam * p_dataRef.p_Speed) * qs_dataRef.quickSandSpeedMultiplier, 
            rb2d.velocity.y + qs_dataRef.sinkingSpeed
            );
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref zeroVector, SMOOTH_TIME);
    }

    /* 
     * ----------------------------------------------------------------
     * checks if player needs to be flipped based on movementInputParam
     * ----------------------------------------------------------------
     */

    
    public void DoIFlipPlayer()
    {
        p_dataRef.currentFacingState = p_dataRef.GetPlayerXRotationState(this.gameObject, MovementInputParam);

        // if player faces right, and wants to go left
        if(
            (p_dataRef.currentFacingState == PlayerData.PlayerXRotationState.Right 
            || p_dataRef.currentFacingState == PlayerData.PlayerXRotationState.IdleRight)
            && MovementInputParam < 0)
        {
            FlipPlayer();
        }
        // if player faces left, and wants to go right
        else if((p_dataRef.currentFacingState == PlayerData.PlayerXRotationState.Left 
            || p_dataRef.currentFacingState == PlayerData.PlayerXRotationState.IdleLeft)
            && MovementInputParam > 0)
        {
            FlipPlayer();
        }
    }

    public void FlipPlayer()
    {
        switch (p_dataRef.currentFacingState)
        {
            case PlayerData.PlayerXRotationState.Right:
                {
                    p_dataRef.currentFacingState = PlayerData.PlayerXRotationState.Left;
                    break;
                }
            case PlayerData.PlayerXRotationState.Left:
                {
                    p_dataRef.currentFacingState = PlayerData.PlayerXRotationState.Right;
                    break;
                }
            case PlayerData.PlayerXRotationState.IdleRight:
                {
                    p_dataRef.currentFacingState = PlayerData.PlayerXRotationState.IdleLeft;
                    break;
                }
            case PlayerData.PlayerXRotationState.IdleLeft:
                {
                    p_dataRef.currentFacingState = PlayerData.PlayerXRotationState.IdleRight;
                    break;
                }
        }

        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
    }

    /*
     * --------------------------------------------------------
     *                          JUMP
     * --------------------------------------------------------
     */

    public void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, JumpInputParam * p_dataRef.p_jumpForce);
    }

    public void PlayerJumpNormal()
    {
        if (p_dataRef.isPlayerJumpin)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpInputParam * p_dataRef.p_jumpForce);
            p_dataRef.isPlayerJumpin = false;
        }
        
        if(rb2d.velocity.y < 0) // when player reaches peak jump height, increases gravity for nice fall speed
        {
            rb2d.gravityScale = FASTFALL_GRAV_SCALE;
        }
        else if(rb2d.velocity.y > 0 && JumpInputParam != 1) // if player lets go of jump before the peak jump height, he slows down, giving sense of "shorthopping"
        {
            rb2d.gravityScale = FASTFALL_GRAV_SCALE * 2;
        }
    }

    public void PlayerJumpQuickSand()
    {
        if (p_dataRef.isPlayerJumpin)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpInputParam * p_dataRef.p_jumpForce);
            p_dataRef.isPlayerJumpin = false;
        }
    }

    /*
     * --------------------------------------------------------
     *           CHECKING GROUND for jumpable locations
     * --------------------------------------------------------
    */
    public bool IsOurPlayerOnGround()
    {
        bool result = false;

        Collider2D[] feetColliderContacts = Physics2D.OverlapCircleAll(playerFeetPoint.position, playerFeetContactRange, interableGroundLayer);

        foreach (Collider2D col in feetColliderContacts)
        {
            if (col != playerFeetCol)
            {
                // restore gravity scale back to standard since gravity scale is changing when we are in the air.
                if (rb2d.gravityScale > STANDARD_GRAV_SCALE)
                {
                    rb2d.gravityScale = STANDARD_GRAV_SCALE;
                }
                // User Layer 7 & 8 are ground and quicksand
                if(col.gameObject.layer == 7 || col.gameObject.layer == 8)
                {
                    result = true;
                }
                return result;
            }
        }

        return result;
    }

    public bool IsOurPlayerInQuickSand(bool result)
    {
        return result;
    }
    #endregion
}
