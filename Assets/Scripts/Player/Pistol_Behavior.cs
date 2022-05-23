using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Behavior : MonoBehaviour
{
    #region Initialization
    [SerializeField] public Dictionary<GameObject, BulletData> bulletObjects;
    [SerializeField] public List<BulletData> bulletDataList;
    [SerializeField] public List<GameObject> bullets;
    private GameObject bulletToFire;

    // Input Variables

    public bool IsBulOneActive { get; private set; }
    public bool IsBulTwoActive { get; private set; }
    public bool IsBulThreeActive { get; private set; }
    public bool IsBulFourActive { get; private set; }
    public bool IsBulBasicActive { get; private set; }

    public enum BulletType {Basic, BulletOne, BulletTwo, BulletThree, BulletFour}
    public BulletType currentBullet;

    private Vector2 spawnLocation;
    #endregion

    #region Monobehavior Callbacks
    // Start is called before the first frame update
    private void Start()
    {
        currentBullet = BulletType.Basic;
    }

    // Update is called once per frame
    private void Update()
    {
        spawnLocation = transform.position;
    }

    #endregion

    #region Input Handling
    void OnShootingPistol()
    {
        SpawnBullet();
    }

    void OnActivateBullet1()
    {
        currentBullet = BulletType.BulletOne;
    }

    void OnActivateBullet2()
    {
        currentBullet = BulletType.BulletTwo;
    }

    void OnActivateBullet3()
    {
        currentBullet = BulletType.BulletThree;
    }

    void OnActivateBullet4()
    {
        currentBullet = BulletType.BulletFour;
    }
    #endregion

    #region Methods
    public void SpawnBullet()
    {
        SetBulletToFire();
        Instantiate(bulletToFire, spawnLocation, Quaternion.Euler(0,0,-90));
    }

    public void SetBulletToFire()
    {
        switch (currentBullet)
        {
            case BulletType.Basic:
                {
                    bulletToFire = bullets[0];
                    break;
                }
            case BulletType.BulletOne:
                {
                    bulletToFire = bullets[1];
                    break;
                }
            case BulletType.BulletTwo:
                {
                    bulletToFire = bullets[2];
                    break;
                }
            case BulletType.BulletThree:
                {
                    bulletToFire = bullets[3];
                    break;
                }
            case BulletType.BulletFour:
                {
                    bulletToFire = bullets[4];
                    break;
                }
        }
    }
    #endregion


}
