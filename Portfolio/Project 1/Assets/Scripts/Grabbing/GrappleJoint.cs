using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleJoint : MonoBehaviour
{
    private int velocity;
    private bool grappling;

    private void Start()
    {
        velocity = 10;
        grappling = false;
    }
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grappling = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            grappling = false;
        }

        if (grappling)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {         
                if (hit.collider.name == "PushCube") 
                {                    
                    Transform pushCubeTransform =
                        hit.collider.GetComponent<Transform>();

                    Vector3 pushCubePosition = pushCubeTransform.position;

                    Vector3 cameraPosition = Camera.main.transform.position;

                    float step = Time.deltaTime * velocity;
                    pushCubeTransform.position = Vector3.MoveTowards(
                        pushCubePosition,
                        cameraPosition,
                        step
                    );

                    Debug.Log("PushCube should be moved");
                }
            }
        }
    }
}
