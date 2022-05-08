using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  * -------------------------------------------------------
  *                      PLAYER DEATH
  * -------------------------------------------------------
  */

// in theory, player touches the "death blocks"
// then, 


public class PlayerDeath : MonoBehaviour
{
    public delegate void pDeathEvent();
    public event pDeathEvent playerDies;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
