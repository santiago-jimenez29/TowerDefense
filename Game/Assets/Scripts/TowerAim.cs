
using UnityEngine;

public class TowerAim : MonoBehaviour
{
    public Transform towerHead;
    public float range = 12f;

    public Transform Target { get; private set; }

    private TowerShoot towerShoot;

    void Awake()
    {
        towerShoot = GetComponent<TowerShoot>();
    }

    void Update()
    {
        Target = null;
        float closestDistance = range;

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

            if (distance <= closestDistance)
            {
                closestDistance = distance;
                Target = enemy.transform;
            }
        }

        if (towerHead == null || Target == null)
            return;

        float speed = towerShoot != null
            ? towerShoot.projectileSpeed
            : 20f;

        Vector3 predictedPosition =
            GetPredictedPosition(towerHead.position, speed);

        Vector3 direction =
            predictedPosition - towerHead.position;

        if (direction.sqrMagnitude > 0.001f)
        {
            towerHead.rotation =
                Quaternion.LookRotation(direction);
        }
    }

    public Vector3 GetPredictedPosition(
        Vector3 firingPosition,
        float projectileSpeed)
    {
        if (Target == null)
            return firingPosition;

        if (projectileSpeed <= 0f)
            return Target.position;

        EnemyMovement movement =
            Target.GetComponent<EnemyMovement>();

        Vector3 velocity = movement != null
            ? movement.CurrentVelocity
            : Vector3.zero;

        Vector3 displacement =
            Target.position - firingPosition;

        float a = Vector3.Dot(velocity, velocity)
                  - projectileSpeed * projectileSpeed;

        float b = 2f * Vector3.Dot(displacement, velocity);
        float c = displacement.sqrMagnitude;

        float time = -1f;

        if (Mathf.Abs(a) < 0.0001f)
        {
            if (Mathf.Abs(b) > 0.0001f)
                time = -c / b;
        }
        else
        {
            float discriminant = b * b - 4f * a * c;

            if (discriminant >= 0f)
            {
                float root = Mathf.Sqrt(discriminant);

                float t1 = (-b - root) / (2f * a);
                float t2 = (-b + root) / (2f * a);

                if (t1 > 0f && t2 > 0f)
                    time = Mathf.Min(t1, t2);
                else if (t1 > 0f)
                    time = t1;
                else if (t2 > 0f)
                    time = t2;
            }
        }

        // Fall back to direct aiming if interception
        // is not possible at the current projectile speed.
        if (time <= 0f)
            return Target.position;

        return Target.position + velocity * time;
    }
}
