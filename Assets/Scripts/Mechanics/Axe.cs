using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
	[SerializeField] float forceMagnitude;
	private Rigidbody2D rb;
	private Vector2 hangingPosition;
	private bool isAxeSwinging;
	// Start is called before the first frame update

	private void Awake()
	{
		Switch.switchTriggered += MoveAxe;
		isAxeSwinging = false;
		rb = GetComponent<Rigidbody2D>();
		hangingPosition = transform.position;
	}


	void Start()
    {
		
    }


    void MoveAxe()
	{
		if (!isAxeSwinging)
		{
			rb.AddForce(Vector2.left * forceMagnitude, ForceMode2D.Force);
		}

		else
		{
			if (transform.position.x > hangingPosition.x) { }
		}
		isAxeSwinging = !isAxeSwinging;
			
	}

}
