using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Transform slot;

    private PickableItem pickedItem;

    private readonly float distance = 3.0f;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button pressed");
            if (pickedItem)
            {
                Debug.Log("Drop item");
                DropItem(pickedItem);
            }
            else
            {
                // var ray = playerCamera.ViewportPointToRay(Vector3.one * 0.5f);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Raycast hit");
                    PickableItem pickable = hit.transform.GetComponent<PickableItem>();

                    if (pickable)
                    {
                        Debug.Log("Pick up item");
                        PickItem(pickable);
                    }
                }
            }
        }

        
        if (pickedItem)
        {
            // pickedItem.transform.localPosition = Vector3.forward * distance;
            
            pickedItem.transform.position = playerCamera.transform.position +
                playerCamera.transform.forward * distance;
            
            /*
            pickedItem.transform.localPosition =
                playerCamera.transform.forward * distance;
            */
        }
        
    }

    private void PickItem(PickableItem item)
    {
        pickedItem = item;

        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        /*
        pickedItem.transform.SetParent(slot);

        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
        */
    }

    private void DropItem(PickableItem item)
    {        
        pickedItem = null;

        // item.transform.SetParent(null);
        item.Rb.isKinematic = false;
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
}
