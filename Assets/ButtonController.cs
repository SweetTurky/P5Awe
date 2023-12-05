using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Get the XRGrabInteractable component attached to the button GameObject
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to events
        grabInteractable.onHoverEntered.AddListener(OnButtonHoverEnter);
        grabInteractable.onHoverExited.AddListener(OnButtonHoverExit);
        grabInteractable.onActivate.AddListener(OnButtonActivate);
    }

    private void OnButtonHoverEnter(XRBaseInteractor interactor)
    {
        Debug.Log("Hovering over the button");
    }

    private void OnButtonHoverExit(XRBaseInteractor interactor)
    {
        Debug.Log("No longer hovering over the button");
    }

    private void OnButtonActivate(XRBaseInteractor interactor)
    {
        Debug.Log("Button activated");
    }
}
