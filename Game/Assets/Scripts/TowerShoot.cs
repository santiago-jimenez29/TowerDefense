
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    public float projectileSpeed = 20f;

    private float nextFireTime = 0f;
    private TowerAim towerAim;

    void Awake()
    {
        towerAim = GetComponent<TowerAim>();
    }

    void Update()
    {
        if (towerAim == null ||
            towerAim.Target == null ||
            projectilePrefab == null ||
            firePoint == null ||
            fireRate <= 0f)
            return;

        // Fire automatically at a fixed rate
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (towerAim.Target == null)
            return;

        // Calculate the direction directly toward the enemy
        Vector3 direction =
            towerAim.Target.position - firePoint.position;

        if (direction.sqrMagnitude < 0.001f)
            return;

        GameObject bullet = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.LookRotation(direction)
        );

        Projectile projectile =
            bullet.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Launch(direction, projectileSpeed);
        }
    }
}
