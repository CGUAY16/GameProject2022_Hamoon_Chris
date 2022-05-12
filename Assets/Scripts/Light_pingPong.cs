using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light_pingPong : MonoBehaviour
{
    private Light2D torchLight;
    [SerializeField] float minIntensity;
    [SerializeField] float maxIntensity;

    private void Awake()
    {
        torchLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        torchLight.intensity = NewPingPong(Time.time, minIntensity, maxIntensity);
    }

    private float NewPingPong(float value, float min, float max)
    {
        return Mathf.PingPong(value, max-min) + min;
    }
}
