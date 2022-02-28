using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorMechanic : MonoBehaviour
{
    //public GameObject door;
    //float force = 500;

    float openHeight = 1;
    float openduration = 1;
    float closeduration = 2;
    bool isOpen;
    Vector2 targetPosition;
    Vector2 closeposition;
    Vector2 openposition;

    bool isDoorMoving;

    // Start is called before the first frame update
    void Start()
    {
        closeposition = transform.position;
        openposition = new Vector2(transform.position.x, transform.position.y + openHeight);
        isOpen = false;
        Switch.switchTriggered += DoorController;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void DoorController()
	{
        if (isDoorMoving)
            return;
        if (isOpen)
		{
            targetPosition = closeposition;
            StartCoroutine(MoveDoor(targetPosition, closeduration));
        }
        else
		{
            targetPosition = new Vector2(transform.position.x, transform.position.y + openHeight);
            StartCoroutine(MoveDoor(targetPosition, openduration));
        }
        isOpen = !isOpen;
	}

    IEnumerator MoveDoor(Vector2 targetposition, float duration)
	{
        isDoorMoving = true;
        float timeElapsed = 0;
        Vector2 startPosition = transform.position;
            while (timeElapsed < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isDoorMoving = false;
    }


}
