using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayState : MonoBehaviour
{
    public string currentState;
    public TMP_Text textRef;


    private void Awake()
    {
        textRef.text = currentState;
    }

    // Update is called once per frame
    void Update()
    {
        textRef.text = currentState;
    }

    public void ChangeText(string newText)
    {
        currentState = newText;
    }

    public void ChangeText(P_BaseState state)
    {
        currentState = state.ToString();
    }
}
