using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is where we store data about the player
 * so that we can access this data outside the 
 * scene. 
 * 
 */

[CreateAssetMenu(menuName = "PlayerData")]

public class PlayerData : ScriptableObject
{
    [Header("General Characteristics of playerObject")]
    public int p_Health = 1;
    public float p_Speed;
    public float p_jumpForce;

    [Header("Check Variables")]
    public bool isGrounded = default;
    public bool isPlayerJumpin = default;

    public enum PlayerXRotationState { Right, Left, IdleRight, IdleLeft };
    public PlayerXRotationState currentFacingState = default;

    public enum CharacterStateMachine { Normal, QuickSand };
    public CharacterStateMachine currentCharacterState = default;

    private void Awake()
    {}

    public PlayerXRotationState GetPlayerXRotationState(GameObject playerObject, float movementParam)
    {
        if(movementParam == 0)
        {
            if(playerObject.transform.localScale.x > 0)
            {
                currentFacingState = PlayerXRotationState.IdleRight;
                return currentFacingState;
            }
            else if(playerObject.transform.localScale.x < 0)
            {
                currentFacingState = PlayerXRotationState.IdleLeft;
                return currentFacingState;
            }
        }
        else if (movementParam > 0 && playerObject.transform.localScale.x > 0)
        {
            currentFacingState = PlayerXRotationState.Right;
            return currentFacingState;
        }
        else if (movementParam < 0 && playerObject.transform.localScale.x < 0)
        {
            currentFacingState = PlayerXRotationState.Left;
            return currentFacingState;
        }

        Debug.LogError("Function 'GetPlayerXRotationState' has not identified a correct state for the Player");
        return currentFacingState;
    }

    // get funct for movement state player is in
    public CharacterStateMachine GetCurrentActionState()
    {
        return currentCharacterState;
    }
}
