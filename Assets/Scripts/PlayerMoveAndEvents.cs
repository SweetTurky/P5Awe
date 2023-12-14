using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlayerMoveAndEvents : MonoBehaviour
{
    public GameObject myXRRig; // Reference to the XR rig GameObject
    public Transform targetPosition;
    public float movementDuration = 2.0f;

    private bool isMoving = false;
    private Vector3 initialPosition;
    private float elapsedTime = 0f;

    // UnityEvent to hold events after movement completes
    [System.Serializable]
    public class EventAfterMovement : UnityEvent { }

    public EventAfterMovement eventsAfterMovement = new EventAfterMovement();

    void Start()
    {
        if (myXRRig == null)
        {
            Debug.LogError("XR rig GameObject not assigned to the script!");
            enabled = false; // Disable the script to avoid issues
            return;
        }

        initialPosition = myXRRig.transform.position; // Store the initial position of the XR rig
    }

    public void MoveToTargetAndFireEvents()
    {
        if (!isMoving)
        {
            initialPosition = myXRRig.transform.position; // Update initial position to the current position of the XR rig
            isMoving = true;
            elapsedTime = 0f;
            eventsAfterMovement.RemoveAllListeners(); // Clear any previously assigned events
        }
    }

    // Assign events to be fired after movement
    public void AssignEventAfterMovement(UnityAction action)
    {
        eventsAfterMovement.AddListener(action);
    }

    void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / movementDuration); // Calculate the interpolation parameter

            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition.position, t);
            myXRRig.transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z); // Update XR rig's position

            if (t >= 1.0f)
            {
                isMoving = false;
                // Movement finished, invoke assigned events
                eventsAfterMovement.Invoke();
            }
        }
    }
}
