using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudioOnStart : MonoBehaviour
{

    void Start()
    {
        GetComponent<AudioSource>().Stop();
    }
                    
}
