using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour, UIInteractable   //Uses the UIInteractable interface, implement it in all interactable objects
{

    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    float buttonCooldown = 0f;
    public bool Interact(Interactor interactor)
    {
        if (Time.time > buttonCooldown + 1f)
        {

            Debug.Log("Button Press");
            spawnOject();
            buttonCooldown = Time.time;
        }
        return true;
    }

    [SerializeField] Object toBeSpawned;
    [SerializeField] float xPosition = 0;
    [SerializeField] float yPositon = 0;

    public void spawnOject()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos.x = xPosition;
        spawnPos.y = yPositon;
        //spawnPos.z = transform.position.z;
        spawnPos.z = -2;

        Instantiate(toBeSpawned, spawnPos, Quaternion.identity);
    }
}
