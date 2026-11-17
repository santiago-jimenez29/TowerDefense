
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    private bool defeated = false;

    public void TakeDamage(int damage)
    {
        if (GameManager.IsGameOver || defeated)
            return;

        health -= damage;

        Debug.Log(gameObject.name + " health: " + health);

        if (health <= 0)
        {
            defeated = true;

            Debug.Log(gameObject.name + " destroyed!");

            GameManager manager =
                FindFirstObjectByType<GameManager>();

            if (manager != null)
            {
                manager.EnemyDefeated();
            }

            Destroy(gameObject);
        }
    }
}
