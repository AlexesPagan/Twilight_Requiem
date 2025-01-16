using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4.0f; // Set move speed
    private Controls controls;
    private Rigidbody2D rb; // Create Rigidbody2D variable 
    private Vector2 moveDirection; // Create a 2d vector for move direction, x and y. 


    // Start is called before the first frame update
    void Start()
    {
        /*
        controls = new Controls();
        rb = GetComponent<Rigidbody2D>(); // Snatches Rigidbody2D component from the object
        if (rb is null)
        {
            Debug.LogError("Rigidbody2D is null");
        }*/

    }

    void Awake()
    {
        controls = new Controls();
        rb = GetComponent<Rigidbody2D>(); // Snatches Rigidbody2D component from the object
        if (rb is null)
        {
            Debug.LogError("Rigidbody2D is null");
        }
    }
    private void OnEnable()
    {
        controls.Player_Overworld.Enable();
    }

    private void OnDisable()
    {
        controls.Player_Overworld.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //OLD INPUT STUFF
        /*
        float xAxis = Input.GetAxisRaw("Horizontal"); // Get the x-axis input

        float yAxis = Input.GetAxisRaw("Vertical"); // Get the y-axis input

        moveDirection = new Vector2(xAxis, yAxis).normalized; // Give move direction this new Vector based on the input
                                                              // Normalize it so it goes the same speed diagnol

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); // Sets the actual velocity
    */

        //NEW INPUT STUFF
        moveDirection = controls.Player_Overworld.Movement.ReadValue<Vector2>();
        rb.velocity = moveDirection * moveSpeed;



    }
}
