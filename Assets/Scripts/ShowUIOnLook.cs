using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIOnLook : MonoBehaviour
{
    public Transform targetObject; // Assign the target object to be observed in the Inspector
    public CanvasGroup canvasGroup; // Reference to the CanvasGroup component attached to your UI elements
    public float maxDistanceToShowUI = 5f; // Maximum distance for the UI to be visible

    private Camera mainCamera;
    public PhysicsPickup physicsPickup;

    void Start()
    {
        mainCamera = Camera.main; // Assuming you want the main camera, otherwise assign the specific camera
        canvasGroup = GetComponent<CanvasGroup>(); // Get the CanvasGroup component
        canvasGroup.alpha = 0f; // Hide the UI initially
    }

    void Update()
    {
        // Check if the camera can see the target object and it's within the specified range
        if (IsCameraLookingAtObject() && IsWithinRange() && physicsPickup.pickedUp == false)
        {
            canvasGroup.alpha = 1f; // Show the UI if the camera is looking at the object within range
        }
        else
        {
            canvasGroup.alpha = 0f; // Hide the UI if the camera is not looking at the object or out of range
        }
    }

    bool IsCameraLookingAtObject()
    {
        if (targetObject == null || mainCamera == null)
            return false;

        Vector3 targetPosition = targetObject.position;
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(targetPosition);

        // If the target object is within the camera's view
        return (viewportPoint.x > 0.3 && viewportPoint.x < 0.7 && viewportPoint.y > 0.3 && viewportPoint.y < 0.7 && viewportPoint.z > 0);
    }

    bool IsWithinRange()
    {
        if (targetObject == null || mainCamera == null)
            return false;

        float distanceToTarget = Vector3.Distance(mainCamera.transform.position, targetObject.position);

        // Check if the distance to the target object is within the specified range
        return distanceToTarget <= maxDistanceToShowUI;
    }
}
