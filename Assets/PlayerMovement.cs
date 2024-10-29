using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.0f; // Set move speed

    private Rigidbody2D rb; // Create Rigidbody2D variable 

    Vector2 moveDirection; // Create a 2d vector for move direction, x and y. 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Snatches Rigidbody2D component from the object
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal"); // Get the x-axis input

        float yAxis = Input.GetAxisRaw("Vertical"); // Get the y-axis input
        
        moveDirection = new Vector2(xAxis, yAxis).normalized; // Give move direction this new Vector based on the input
                                                              // Normalize it so it goes the same speed diagnol

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); // Sets the actual velocity

        

    }
}
