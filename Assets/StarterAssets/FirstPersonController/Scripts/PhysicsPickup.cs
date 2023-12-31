using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsPickup : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private LayerMask InteractMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    public Rigidbody CurrentObject;
    public ShowUIOnLook showUIOnLook;
    public bool pickedUp;
    public GameObject runeStone;
    public UnityEvent onInteract; // UnityEvent that can be assigned in the Inspector

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("E is pressed");
            if(CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                pickedUp = false;

                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if(Physics.Raycast(CameraRay, out RaycastHit Hitinfo, PickupRange, PickupMask))
            {
                CurrentObject = Hitinfo.rigidbody;
                CurrentObject.useGravity = false;
                pickedUp = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))
        {
            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit Hitinfo, PickupRange, InteractMask))
            {
                onInteract.Invoke();
            }
        }
    }
    void FixedUpdate() 
    {
        if(CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }    
    }
}
