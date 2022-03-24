using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] Transform torchLocation;
    private Transform torchTransform = default;
    private float topHeightLimit = default;
    private float bottomHeightLimit = default;
    private Vector2 newEndpointPosition = default;
    private Vector2 ZeroVector = Vector2.zero;

    [SerializeField] private float distanceDelta = default;

    [SerializeField] private float SMOOTH_TIME = 0.1f;

    private void Awake()
    {
        torchTransform = GetComponent<Transform>();
        topHeightLimit = torchTransform.position.y + 3f;
        bottomHeightLimit = torchTransform.position.y - 3f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //topHeightLimit = torchTransform.position.y + 3f;
        //bottomHeightLimit = torchTransform.position.y - 3f;
        //newEndpointPosition = CheckNewTargetLocation(newEndpointPosition);

        transform.position = Vector2.MoveTowards(transform.position, torchLocation.transform.position, distanceDelta);

    }

    private void FixedUpdate()
    {
        //Vector2 newPos = Vector2.SmoothDamp(torchTransform.position, newEndpointPosition, ref ZeroVector, SMOOTH_TIME);
        //torchTransform.position = new Vector2(torchTransform.position.x, torchTransform.position.y + newPos.y);
    }

    private Vector2 CheckNewTargetLocation(Vector2 endpoint)
    {
        if(torchTransform.position.y >= topHeightLimit)
        {
            endpoint = new Vector2(torchTransform.position.x, bottomHeightLimit);
        }
        else if(torchTransform.position.y <= bottomHeightLimit)
        {
            endpoint = new Vector2(torchTransform.position.x, topHeightLimit);
        }
        return endpoint;
    }
}
