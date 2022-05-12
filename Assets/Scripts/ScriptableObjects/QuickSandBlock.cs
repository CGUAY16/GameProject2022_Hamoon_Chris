using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ----------------------------------------  
 *  Data for the quicksand tilemap layers
 *  
*///---------------------------------------

[CreateAssetMenu(menuName = "QuickSandBlock")]
public class QuickSandBlock : ScriptableObject
{
    public enum QuickSandAnimState {Slow, Fast};
    public QuickSandAnimState currentAnimState = default;  // also serves to change animation speed of quick sand tiles

    public float sinkingSpeed = default; // some value that makes player sink through a block.
    public float quickSandSpeedMultiplier = default; // decreases player speed.
    public float quickSandJumpForceMultiplier = default; // decreases height of jump force.

    public void SetQuickSandValues()
    {
        switch(currentAnimState){

            case QuickSandAnimState.Slow:
                {
                    sinkingSpeed = -1f;
                    quickSandSpeedMultiplier = 0.75f;
                    quickSandJumpForceMultiplier = 0.75f;
                    break;
                }
            case QuickSandAnimState.Fast:
                {
                    sinkingSpeed = -2f;
                    quickSandSpeedMultiplier = 0.60f;
                    quickSandJumpForceMultiplier = 0.60f;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void ChangeToFastData()
    {
        currentAnimState = QuickSandAnimState.Fast;
        SetQuickSandValues();
    }

    public void ChangeToSlowData()
    {
        currentAnimState = QuickSandAnimState.Slow;
        SetQuickSandValues();
    }
}
