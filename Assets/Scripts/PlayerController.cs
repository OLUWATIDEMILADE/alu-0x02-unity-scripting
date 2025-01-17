using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public variable to control the player's movement speed
    public float speed = 5.0f;

    // Private variable to keep track of the player's score
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score to 0 and log it
        Debug.Log("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement using WASD or Arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the Player based on the input
        transform.Translate(movement * speed * Time.deltaTime);
    }

    // Trigger detection for collecting pickups
    void OnTriggerEnter(Collider other)
    {
        // Check if the Player collided with a Pickup
        if (other.CompareTag("Pickup"))
        {
            // Increment the score
            score++;

            // Log the new score to the console
            Debug.Log("Score: " + score);

            // Disable or destroy the Coin (Pickup)
            other.gameObject.SetActive(false);
        }
    }
}
