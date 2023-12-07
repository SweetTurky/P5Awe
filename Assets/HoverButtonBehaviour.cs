using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverButton : MonoBehaviour
{
    public float hoverDuration = 3f; // Duration in seconds for the hover
    public UnityEvent OnHoverComplete; // Event to be triggered after hovering for the specified duration

    private bool isHovering = false;
    private float hoverTimer = 0f;

    private XRBaseInteractable interactable;

    private void Start()
    {
        // Get the XRBaseInteractable component on this GameObject
        interactable = GetComponent<XRBaseInteractable>();

        // Subscribe to hover events
        if (interactable != null)
        {
            interactable.onHoverEntered.AddListener(OnHoverEnter);
            interactable.onHoverExited.AddListener(OnHoverExit);
        }
    }

    private void Update()
    {
        if (isHovering)
        {
            hoverTimer += Time.deltaTime;

            // Check if the hover duration has been reached
            if (hoverTimer >= hoverDuration)
            {
                OnHoverComplete?.Invoke(); // Trigger the event
                isHovering = false;
                hoverTimer = 0f;
            }
        }
    }

    public void OnHoverEnter(XRBaseInteractor interactor)
    {
        isHovering = true;
    }

    public void OnHoverExit(XRBaseInteractor interactor)
    {
        isHovering = false;
        hoverTimer = 0f; // Reset the timer when the hover exits
    }
}
