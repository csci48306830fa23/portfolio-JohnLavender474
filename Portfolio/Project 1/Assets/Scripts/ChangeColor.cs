using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    private bool triggered;
    private Color color1;
    private Color color2;

    private void Start()
    {
        triggered = false;

        color1 = Random.ColorHSV();
        color2 = Random.ColorHSV();       
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PushCube")
        {
            GetComponent<Renderer>().material.color = GetColor();
            triggered = !triggered;
        }        
    } 

    private Color GetColor()
    {
        return triggered ? color1 : color2;
    }
}
