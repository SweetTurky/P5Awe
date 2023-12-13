using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable{
    public void Interact();
}
public class InteractorPC : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
             {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    interactObj.Interact();
                }
            }
        }
    }
}
