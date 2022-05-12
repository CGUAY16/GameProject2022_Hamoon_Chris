using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] int distance;
    [SerializeField] int direction; //0 is horizontal 1 is vertical
    [SerializeField] float duration;
    Vector2 startPosition;
    Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        Switch.switchTriggered += PlatformController;
        startPosition = transform.position;
        if (direction == 0)
            targetPosition = new Vector2(startPosition.x + distance, startPosition.y);
        else
            targetPosition = new Vector2(startPosition.x, startPosition.y + distance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlatformController ()
	{

	}

    IEnumerator MovePlatform()
	{
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        timeElapsed = 0;
    }
}
