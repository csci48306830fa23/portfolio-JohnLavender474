using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GripControllerModelSwitcher : MonoBehaviour
{
    [SerializeField]
    private ActionBasedController actionBasedController;

    [SerializeField]
    private GameObject openControllerModel;

    [SerializeField]
    private GameObject closedControllerModel;

    private bool isGripPressed = false;

    private void Start()
    {
        Debug.Log("Script running");
        if (actionBasedController == null)
        {
            Debug.LogError("ActionBasedController is not set!");
            return;
        }
        Debug.LogError("Script running");
        // Subscribe to grip button events
        actionBasedController.selectAction.action.performed += OnGripButtonPressed;
        actionBasedController.selectAction.action.canceled += OnGripButtonReleased;

        // Initially, show the open controller model
        if (openControllerModel != null)
        {
            openControllerModel.SetActive(true);
        }

        // Initially, hide the closed controller model
        if (closedControllerModel != null)
        {
            Debug.LogError("Here");
            closedControllerModel.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from grip button events when the script is destroyed
        actionBasedController.selectAction.action.performed -= OnGripButtonPressed;
        actionBasedController.selectAction.action.canceled -= OnGripButtonReleased;
    }

    private void OnGripButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isGripPressed = true;
        UpdateControllerModel();
    }

    private void OnGripButtonReleased(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isGripPressed = false;
        UpdateControllerModel();
    }

    private void UpdateControllerModel()
    {
        if (openControllerModel != null)
        {
            openControllerModel.SetActive(!isGripPressed);
        }

        if (closedControllerModel != null)
        {
            closedControllerModel.SetActive(isGripPressed);
        }
    }
}
