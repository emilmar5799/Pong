using System.Collections;   
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public bool isLeftPaddle = true;

    [Header("Boundary Settings")]
    public float topBoundary = 4f;
    public float bottomBoundary = -4f;

    private void Update()
    {
        HandleInput();
        ClampPosition();
    }

    private void HandleInput()
    {
        float moveDirection = 0f;

        if (isLeftPaddle)
        {
            // Left paddle controls: W (up) and A (down)
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveDirection = -1f;
            }
        }
        else
        {
            // Right paddle controls: Up Arrow and Down Arrow
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection = 1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDirection = -1f;
            }
        }

        // Move the paddle
        Vector3 newPosition = transform.position + Vector3.up * moveDirection * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void ClampPosition()
    {
        // Restrict paddle movement within boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottomBoundary, topBoundary);
        transform.position = clampedPosition;
    }
}