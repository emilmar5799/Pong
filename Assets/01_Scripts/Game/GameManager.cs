using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;     // Prefab de la pelota
    private GameObject currentBall;   // Pelota activa
    public Transform spawnPoint;      // Punto de spawn (puede ser el centro)

    void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall); // Por si hubiera una anterior
        }

        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }
}
