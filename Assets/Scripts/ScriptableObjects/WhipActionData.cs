using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WhipActionData")]
public class WhipActionData : ScriptableObject
{
    // If this bool is true, then character cannot "create" another whip projectile.
    [SerializeField] private bool isWhippingActive = false;

    public bool Getiswhippingactive()
    {
        return isWhippingActive;
    }

    public void Setiswhippingactive(bool result)
    {
        isWhippingActive = result;
    }
}
