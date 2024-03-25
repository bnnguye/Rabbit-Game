using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 5;

    float isRunning = 1;

    public Terrain terrain;

    bool isFacingRight = true;
    public void Move(Controls input) {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Normalize the input vector to ensure consistent speed regardless of direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (input == Controls.LEFT && isFacingRight) {
            Flip();
            isFacingRight = false;
        }
        if (input == Controls.RIGHT && !isFacingRight) {
            Flip();
            isFacingRight = true;
        }

        if (input == Controls.RUN) {
            isRunning = 2;
        }
        else {
            isRunning = 1;
        }

        // Move the character based on the normalized movement direction
        transform.Translate(speed * isRunning * movementDirection * Time.deltaTime);

        ClampToTerrainBoundaries();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void ClampToTerrainBoundaries()
    {
        // Perform a raycast downward from the rabbit's position
        Ray ray = new Ray(transform.position + Vector3.up * 10f, Vector3.down); // Start the ray above the rabbit to avoid self-collision
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
        {
            // Get the terrain height at the hit point
            float terrainHeight = hit.point.y;

            // Clamp the rabbit's position to stay within the terrain boundaries
            float clampedY = Mathf.Clamp(transform.position.y, terrain.transform.position.y, terrainHeight);
            transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        }
    }


}
