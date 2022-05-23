using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior_BulletFour : MonoBehaviour
{
    #region Variables/Initialization

    public BulletData data;

    #endregion

    #region MonoBehavior callbacks
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
    #endregion

    #region Methods
    public void MoveBullet()
    {
        transform.position =
            Vector2.MoveTowards(transform.position,
            new Vector2(transform.position.x + 1, transform.position.y),
            data.bulletSpeed * Time.fixedDeltaTime);
    }
    #endregion
}
