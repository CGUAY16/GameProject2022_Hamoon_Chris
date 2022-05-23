using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullet Data")]
public class BulletData : ScriptableObject
{
    [SerializeField] Sprite bulletImage;
    public float bulletSpeed;
    public float bulletCD;
}
