using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 initialDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Dirección inicial aleatoria
        float randomDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
        initialDirection = new Vector2(randomDirection, Random.Range(-0.5f, 0.5f)).normalized;

        // Aplicar velocidad inicial
        rb.velocity = initialDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Rebote más natural
        Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = reflectedVelocity.normalized * speed;
    }

    // Método para resetear la bola
    public void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;

        // Nueva dirección aleatoria después de un breve delay
        Invoke("SetInitialVelocity", 1f);
    }

    void SetInitialVelocity()
    {
        float randomDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
        Vector2 newDirection = new Vector2(randomDirection, Random.Range(-0.5f, 0.5f)).normalized;
        rb.velocity = newDirection * speed;
    }
}