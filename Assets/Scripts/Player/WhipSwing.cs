using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipSwing : MonoBehaviour
{
    [SerializeField] private PlayerData p_dataRef;
    [SerializeField] private WhipActionData whipData;
    [SerializeField] float force;

    private GameObject whip;
    private Vector2 currentMousePos = default;
    private Vector2 directionOfProjectile;

    // gameobject to instantiate
    [SerializeField] GameObject prefab = default;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        directionOfProjectile = currentMousePos - new Vector2(transform.position.x, transform.position.y);
    }

    void OnGrapple()
    {
        Debug.Log(currentMousePos);
        if (!whipData.Getiswhippingactive())
        {
            whip = Instantiate(prefab, transform.position, transform.rotation);
            LaunchWhip();
        }
    }

    private void LaunchWhip()
    {
        Debug.Log("Object launched");
        whip.GetComponent<Rigidbody2D>().velocity = directionOfProjectile * force;


    }
}
