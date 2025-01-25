using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyOverworldScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<AIDestinationSetter>().target = other.transform;
            Debug.Log("ENTER");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.GetComponent<AIDestinationSetter>().target == other.transform)
        {
            gameObject.GetComponent<AIDestinationSetter>().target = null;
            Debug.Log("EXIT");
        }
    }
}
