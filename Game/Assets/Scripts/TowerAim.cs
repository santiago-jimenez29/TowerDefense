
using UnityEngine;

public class TowerAim : MonoBehaviour
{
    public Transform towerHead;
    public float range = 12f;

    public Transform Target { get; private set; }

    void Update()
    {
        Target = null;
        float closestDistance = range;

        // Find all enemies in the scene
        EnemyHealth[] enemies =
            FindObjectsByType<EnemyHealth>(
                FindObjectsSortMode.None
            );

        foreach (EnemyHealth enemy in enemies)
        {
            float distance = Vector3.Distance(
                transform.position,
                enemy.transform.position
            );

            // Choose the closest enemy within range
            if (distance <= closestDistance)
            {
                closestDistance = distance;
                Target = enemy.transform;
            }
        }

        // Aim toward the selected enemy
        if (towerHead != null && Target != null)
        {
            Vector3 direction =
                Target.position - towerHead.position;

            if (direction.sqrMagnitude > 0.001f)
            {
                towerHead.rotation =
                    Quaternion.LookRotation(direction);
            }
        }
    }
}
