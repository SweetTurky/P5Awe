using UnityEngine;

public class TorchCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a TurnMeOn component
        TurnMeOn turnMeOnComponent = other.GetComponent<TurnMeOn>();

        if (turnMeOnComponent != null && other.gameObject != gameObject) // Ignore collision with self
        {
            // Activate the lights and particle systems on collision with other objects' sphere colliders
            turnMeOnComponent.ActivateLightAndParticles();
        }
    }
}
