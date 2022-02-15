using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 * This Scriptable Object is for creating a base class for collectables 
 * within our game. By making it a scriptable object, we can now track
 * the count of specific collectable outside the scenes.
 */

[CreateAssetMenu(menuName = " Collectable Type")]

public class CollectableType : ScriptableObject
{
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnValidate()
    {
        
    }

}
