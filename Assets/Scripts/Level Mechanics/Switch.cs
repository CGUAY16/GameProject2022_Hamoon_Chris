using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Switch : MonoBehaviour
{

    public delegate void EventManager();
    public static event EventManager switchTriggered;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetMouseButtonUp(0))
		{
            OnSwitchTriggered(EventArgs.Empty);
		}
    }

    protected virtual void OnSwitchTriggered(EventArgs e)
	{
        switchTriggered?.Invoke();
	}

}
