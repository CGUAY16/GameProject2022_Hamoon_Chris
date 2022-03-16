using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSwitch : Switch
{
    [SerializeField] int delaySeconds;


    bool isCRrunning;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
           if (!isCRrunning)
                StartCoroutine(DelaySwtich());
                       
        }
    }


    IEnumerator DelaySwtich()
	{
        isCRrunning = true;
        base.OnSwitchTriggered(EventArgs.Empty);
        yield return new WaitForSeconds(delaySeconds);
        base.OnSwitchTriggered(EventArgs.Empty);
        isCRrunning = false;
	}

}
