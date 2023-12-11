using UnityEngine;
using UnityEngine.Events;

public class Enabler: MonoBehaviour
{
    // Reference to the XR-Origin Rig (assign this in the Unity Editor)
    public GameObject xrOriginRig;

    // Unity Event to be triggered on collision
    public UnityEvent onCollisionEvent;

    // Flag to check if the event has been triggered
    private bool eventTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the XR-Origin Rig and the event hasn't been triggered yet
        if (!eventTriggered && other.gameObject == xrOriginRig)
        {
            // Trigger the Unity Event
            onCollisionEvent.Invoke();

            // Set the flag to true to indicate that the event has been triggered
            eventTriggered = true;
            Debug.Log("Gravity Re-enabled. "  +  "Rig Rotation reset. ");

            // You can add more logic here as needed
        }
    }
}
