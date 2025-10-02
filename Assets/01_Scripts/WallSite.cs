using UnityEngine;

public class WallSite : MonoBehaviour
{
    public GameManager gameManager;
    public SavePuntuationController pointManager;
    public bool isLeftWall; // marcar en el inspector si esta pared es la izquierda

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);

            // Sumar puntos según qué pared fue
            pointManager.AddPoint(isLeftWall);

            // Respawnear pelota
            gameManager.SpawnBall();
        }
    }
}
