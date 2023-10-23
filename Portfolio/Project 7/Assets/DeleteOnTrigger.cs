using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entered object has an XR Grab Interactable component
        XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            // Destroy the XR Grab Interactable
            Destroy(grabInteractable.gameObject);
        }
    }
}
