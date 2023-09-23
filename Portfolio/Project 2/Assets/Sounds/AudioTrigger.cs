using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{    
    private bool playing;

    private void Start()
    {
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {                        
            {
                AudioSource audio = GetComponent<AudioSource>();
                if (audio)
                {
                    Debug.Log("Audio not null");
                    if (playing)
                    {
                        audio.Stop();
                    }
                    else
                    {
                        audio.Play();
                    }

                    playing = !playing;
                }                
            }            
        }
    }
}
