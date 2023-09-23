using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSlot : MonoBehaviour
{

    private readonly float distance = 0.5f;
            
    void Update()
    {
        var transform = GetComponent<Transform>();
        var camera = Camera.main;

        transform.SetParent(camera.transform);
        transform.localPosition = Vector3.forward * distance;        
    }
}
