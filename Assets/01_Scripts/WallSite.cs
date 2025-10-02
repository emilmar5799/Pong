using System;
using UnityEngine;

public class WallSite : MonoBehaviour
{
    public GameManager gameManager; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Debug.Log("Collisiono");

            Destroy(collision.gameObject);
            gameManager.SpawnBall();
        }
    }
}
