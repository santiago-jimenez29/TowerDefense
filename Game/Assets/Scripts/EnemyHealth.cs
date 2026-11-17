
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int damage)
    {
        if (GameManager.IsGameOver)
            return;

        health -= damage;

        Debug.Log("Enemy health: " + health);

        if (health <= 0)
        {
            Debug.Log("Enemy destroyed!");

            // Tell GameManager the player won
            GameManager manager =
                FindFirstObjectByType<GameManager>();

            if (manager != null)
            {
                manager.WinGame();
            }

            Destroy(gameObject);
        }
    }
}
