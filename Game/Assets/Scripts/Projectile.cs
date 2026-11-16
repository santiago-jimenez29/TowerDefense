
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 5f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Remove bullets that miss after 5 seconds
        Destroy(gameObject, lifetime);
    }

    public void Launch(Vector3 direction, float speed)
    {
        // Fire the projectile forward using 3D physics
        rb.linearVelocity = direction.normalized * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            // Destroy the bullet after a successful hit
            Destroy(gameObject);
        }
    }
}
