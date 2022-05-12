using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingHingeJoint : MonoBehaviour
{
    private Rigidbody2D r = default;
    public float forceMag = 100f;

    private void Awake()
    {
        r = GetComponent<Rigidbody2D>();
    }

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
        if (Input.GetKeyDown(KeyCode.B))
        {
            r.AddForce(Vector2.right * forceMag, ForceMode2D.Force);
        }
        
    }
}
