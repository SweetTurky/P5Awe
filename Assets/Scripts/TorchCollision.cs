using UnityEngine;

public class TorchCollision : MonoBehaviour
{
    public GameObject sphereCollider; // Reference to the sphere collider GameObject

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a TurnMeOn component
        TurnMeOn turnMeOnComponent = other.GetComponent<TurnMeOn>();

        if (turnMeOnComponent != null && other.gameObject == sphereCollider)
        {
            // Activate the lights and particle systems on collision with the sphere collider
            turnMeOnComponent.ActivateLightAndParticles();
        }
    }
}
