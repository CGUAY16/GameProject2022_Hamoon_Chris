using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    //public GameObject door;
    //float force = 500;

    float openHeight = 1;
    float openduration = 1;
    float closeduration = 5;
    bool isOpen;
    Vector2 targetPosition;
    Vector2 closeposition;
    Vector2 openposition;


    // Start is called before the first frame update
    void Start()
    {
        closeposition = transform.position;
        openposition = new Vector2(transform.position.x, transform.position.y + openHeight);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool click = Input.GetMouseButtonUp(0);
        if (click)
		{
            DoorController();
        }
    }

    void DoorController()
	{
        StopAllCoroutines();
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
        float timeElapsed = 0;
        Vector2 startPosition = transform.position;
            while (timeElapsed < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }


}
