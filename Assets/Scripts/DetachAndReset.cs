using UnityEngine;

public class DetachAndReset : MonoBehaviour
{
    public GameObject collisionSphereObject; // Reference to the GameObject with the Sphere Collider

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the collided object matches the sphere object and has the "Player" tag
        if (hit.gameObject == collisionSphereObject && hit.gameObject.CompareTag("Player"))
        {
            DetachAndResetRotation();
        }
    }

    private void DetachAndResetRotation()
    {
        // Detach the object from its parents
        transform.SetParent(null);

        // Reset the object's rotation on the x and z axis
        Vector3 currentRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);
    }
}
