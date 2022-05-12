using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipProjectile : MonoBehaviour
{
    private Rigidbody2D rb2d = default;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] HingeJoint2D hinge = default;
    [SerializeField] LayerMask layerMask = default;

    // references
    PlayerController playerOB;
    [SerializeField] private WhipActionData whipData;

    private bool isWhipConnectedToCeiling = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        Collider2D jointLayerChecker = Physics2D.OverlapCircle(
            new Vector2(hinge.anchor.x + transform.position.x, hinge.anchor.y + transform.position.y),
            0.2f,
            layerMask);
        
        if(jointLayerChecker != null)
        {
            isWhipConnectedToCeiling = true;
            ActivateWhip();
        }

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(new Vector2(hinge.anchor.x + transform.position.x, hinge.anchor.y + transform.position.y), 0.2f);
    }

    private void OnEnable()
    {
        whipData.Setiswhippingactive(result: true);
    }

    private void OnDestroy()
    {
        whipData.Setiswhippingactive(result: false);
    }

    private void ActivateWhip()
    {
        //rb2d.velocity = new Vector2(0f,0f);
        rb2d.isKinematic = true;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        hinge.enabled = true;
        // set attached rigidbody to the player's RB
        hinge.connectedBody = playerRB;

        float impulse = (90 * Mathf.Deg2Rad) * playerRB.inertia;
        playerRB.AddTorque(impulse, ForceMode2D.Impulse);
    }
}
