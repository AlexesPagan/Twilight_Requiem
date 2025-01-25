using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;    //Where the "hitbox" for interaction is
    [SerializeField] private float interactionRadius = 0.5f;    //How big the interactionPoint is
    [SerializeField] private LayerMask interactableMask;    //What the interactionPoint can actually detect
    [SerializeField] private InteractionPromptUI interactionPromptUI;


    private readonly Collider2D[] colliders = new Collider2D[3];    //An array of up to 3 of the most recent interactable objects that touched the hitbox
    [SerializeField] private int numFound;  //The total number of interactable objects currently in radius

    private UIInteractable interactable;    //The interaction script attached to an interactable object

    private void Update()
    {
        numFound = Physics2D.OverlapCircleNonAlloc(interactionPoint.position, interactionRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<UIInteractable>(); //The first interactable object to show up in radius is the first one that can be interacted with

            //if (interactable != null && gameObject.GetComponent<PlayerMovement>().controls.Player_Overworld.Interact.ReadValue<float>() > 0.5f)
            //If there is an interactable present and the player presses the interact button, the behavior for the interact object is called
            if (interactable != null)
            {
                if (!interactionPromptUI.isDisplayed)
                {
                    interactionPromptUI.SetUp(interactable.InteractionPrompt);
                }
                if (gameObject.GetComponent<PlayerMovement>().controls.Player_Overworld.Interact.ReadValue<float>() > 0.5f)
                {
                    interactable.Interact(this);
                }

            }
        }
        else
        {
            if (interactable != null)
            {
                interactable = null;
            }
            if (interactionPromptUI.isDisplayed) interactionPromptUI.Close();
        }

    }

    private void OnDrawGizmos() //Just so we can clearly see the interactionPoint in the editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }
}
