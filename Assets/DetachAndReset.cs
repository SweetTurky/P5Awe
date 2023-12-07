using UnityEngine;

public class DetachAndReset : MonoBehaviour
{
    public GameObject collisionSphereObject; // Reference to the GameObject with the Sphere Collider

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the specific sphere collider
        if (collision.gameObject == collisionSphereObject)
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
