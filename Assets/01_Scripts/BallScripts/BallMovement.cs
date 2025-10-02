using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 8f;
    public float maxBounceAngle = 75f; // �ngulo m�ximo de rebote
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // Direcci�n inicial m�s aleatoria
        float randomDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
        float randomAngle = Random.Range(-0.7f, 0.7f);

        Vector2 direction = new Vector2(randomDirection, randomAngle).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Rebote especial con paletas
        if (collision.gameObject.CompareTag("Paddle"))
        {
            BounceFromPaddle(collision);
        }
        // Rebote normal con paredes
        else
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflected = Vector2.Reflect(rb.velocity.normalized, normal);
            rb.velocity = reflected * speed;
        }
    }

    void BounceFromPaddle(Collision2D collision)
    {
        // C�lculo del �ngulo de rebote basado en d�nde golpea la paleta
        Rigidbody2D paddleRb = collision.collider.attachedRigidbody;
        float paddleHeight = collision.collider.bounds.size.y;

        // Posici�n de contacto relativa al centro de la paleta
        float contactY = (transform.position.y - collision.transform.position.y) / (paddleHeight / 2);

        // Limitar el valor entre -1 y 1
        contactY = Mathf.Clamp(contactY, -1f, 1f);

        // Calcular �ngulo de rebote
        float bounceAngle = contactY * (maxBounceAngle * Mathf.Deg2Rad);

        // Determinar direcci�n X (opuesta a la direcci�n actual)
        float directionX = rb.velocity.x > 0 ? -1f : 1f;

        // Nueva direcci�n con �ngulo calculado
        Vector2 newDirection = new Vector2(directionX, Mathf.Sin(bounceAngle)).normalized;

        rb.velocity = newDirection * speed;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;
        Invoke("LaunchBall", 1f);
    }
}