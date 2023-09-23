using System;
using UnityEngine;
using UnityEngine.UI;

public class BoxSliderListener : MonoBehaviour
{
    private const float Tolerance = 0.1f;
    private const float Multiplier = 5f;

    private float startX;
    private float oldValue;

    private Slider slider;

    private void Start()
    {
        slider = GameObject.Find("BoxSlider").GetComponent<Slider>();
        startX = transform.position.x;
    }
    
    private void Update()
    {
        var currentValue = slider.value;
        if (Math.Abs(oldValue - currentValue) < Tolerance)
        {
            return;
        }

        Debug.Log("Slider value has changed. Old value: " + oldValue + ". New value: " + currentValue);
        oldValue = currentValue;

        var x = slider.value;
        var t = transform;
        var position = t.position;
        t.position = new Vector3(startX + x * Multiplier, position.y, position.z);
    }
}