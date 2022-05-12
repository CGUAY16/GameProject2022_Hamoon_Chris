using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSand : MonoBehaviour
{
    public PlayerController playerContRef;
    public bool IsPlayerInTrigger { get; set; }

    private void Awake()
    {
        IsPlayerInTrigger = false;
        playerContRef.QuickSandCheckerInstance += IsPlayerInQuickSand;
    }

    private void OnDestroy()
    {
        playerContRef.QuickSandCheckerInstance -= IsPlayerInQuickSand;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider entering");
        if (CheckCollisionForPlayerLayer(collision))
        {
            Debug.Log("Player Entered");
            IsPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collider exiting");
        if (CheckCollisionForPlayerLayer(collision))
        {
            IsPlayerInTrigger = false;
        }
    }

    private bool CheckCollisionForPlayerLayer(Collider2D collision)
    {
        return collision.gameObject.layer == 6;
    }

    public bool IsPlayerInQuickSand()
    {
        return IsPlayerInTrigger;
    }

}
