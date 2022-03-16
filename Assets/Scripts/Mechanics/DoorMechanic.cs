using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorMechanic : MonoBehaviour
{
    //public GameObject door;
    //float force = 500;

    [SerializeField] private float openHeight = 1;
    [SerializeField] private float openduration = 1;
    [SerializeField] private float closeduration = 2;
    private bool isOpen;
    private Vector2 targetPosition;
    private Vector2 closeposition;
    private Vector2 openposition;

    private bool isDoorMoving;

    private void Awake()
    {
        Switch.switchTriggered += DoorController;
    }

    // Start is called before the first frame update
    void Start()
    {
        closeposition = transform.position;
        openposition = new Vector2(transform.position.x, transform.position.y + openHeight);
        isOpen = false;
    }

	// Update is called once per frame

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
            float t = Mathf.SmoothStep(0, 1, timeElapsed / duration);
            transform.position = Vector2.Lerp(startPosition, targetPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isDoorMoving = false;
    }

    IEnumerator MoveDoorRB()
	{
        yield return null;
	}
}
