using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinite_Background : MonoBehaviour
{
    public GameObject TopLeft;
    public GameObject TopMiddle;
    public GameObject TopRight;
    public GameObject MiddleLeft;
    public GameObject MiddleRight;
    public GameObject BottomLeft;
    public GameObject BottomMiddle;
    public GameObject BottomRight;

    private float positionX;
    private float positionY;
    private bool isMoving = false; // Flag to check if the coroutine is already running

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Player" tag and the coroutine is not already running
        if (other.CompareTag("MainCamera") && !isMoving)
        {
            // Start the coroutine to add a delay
            StartCoroutine(DelayedPositionUpdate());
        }
    }

    // Coroutine to add a delay
    private IEnumerator DelayedPositionUpdate()
    {
        // Set the flag to true so no other coroutine is started
        isMoving = true;

        // Debug log to confirm coroutine has started
        Debug.Log("Coroutine started, waiting for 1 second...");

        // Wait for 1 second (you can change this to any duration)
        yield return new WaitForSeconds(0.5f);

        // Get the position of horizontalOne (this object)
        positionX = transform.position.x;
        positionY = transform.position.y;

        // Update positions for other GameObjects
        TopLeft.transform.position = new Vector3(positionX - 30, positionY + 30, 0);
        TopMiddle.transform.position = new Vector3(positionX, positionY + 30, 0);
        TopRight.transform.position = new Vector3(positionX + 30, positionY + 30, 0);
        MiddleLeft.transform.position = new Vector3(positionX - 30, positionY, 0);
        MiddleRight.transform.position = new Vector3(positionX + 30, positionY, 0);
        BottomLeft.transform.position = new Vector3(positionX - 30, positionY - 30, 0);
        BottomMiddle.transform.position = new Vector3(positionX, positionY - 30, 0);
        BottomRight.transform.position = new Vector3(positionX + 30, positionY - 30, 0);

        // Debug log to confirm positions were updated
        Debug.Log("Positions updated");

        // Allow new coroutine to run after updating positions
        isMoving = false;
    }
}
