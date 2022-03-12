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
    public bool p_FacesRight = default;
    public bool p_FacesLeft = default;


    public enum PlayerSideFacingState {Right, Left};



    private void Awake()
    {
        
    }



    public PlayerSideFacingState GetPlayerSideFacingState(PlayerSideFacingState state, bool facingRight, bool facingLeft, float movementParam)
    {
        if (facingRight && movementParam > 0)
        {
            state = PlayerSideFacingState.Right;
            facingRight = true;
            facingLeft = false;
        }
        else if (facingLeft && movementParam < 0)
        {
            state = PlayerSideFacingState.Left;
            facingRight = false;
            facingLeft = true;
        }
            
        return state;
    }

}
