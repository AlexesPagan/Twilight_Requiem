using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;


    private readonly Collider2D[] colliders = new Collider2D[3];
    [SerializeField] private int numFound;

    private void Update()
    {
        numFound = Physics2D.OverlapCircleNonAlloc(interactionPoint.position, interactionRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            var interactable = colliders[0].GetComponent<UIInteractable>();

            if (interactable != null && gameObject.GetComponent<PlayerMovement>().controls.Player_Overworld.Interact.ReadValue<float>() > 0.5f)
            {
                interactable.Interact(this);

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }
}
