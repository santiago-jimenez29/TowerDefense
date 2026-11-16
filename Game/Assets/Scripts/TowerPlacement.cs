
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject basicTowerPrefab;
    public GameObject tallTowerPrefab;
    public Collider groundCollider;

    public int towersRemaining = 5;

    private int selectedTower = 1;

    void Update()
    {
        if (GameManager.IsGameOver)
            return;
        // Select tower type
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedTower = 1;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedTower = 2;

        // Place selected tower
        if (Input.GetMouseButtonDown(0) && towersRemaining > 0)
        {
            PlaceTower();
        }
    }

    void PlaceTower()
    {
        Camera cam = Camera.main;

        if (cam == null)
            return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Only allow placement on the grass
            if (hit.collider != groundCollider)
                return;

            GameObject towerPrefab =
                selectedTower == 1
                ? basicTowerPrefab
                : tallTowerPrefab;

            if (towerPrefab == null)
                return;

            Instantiate(
                towerPrefab,
                hit.point,
                Quaternion.identity
            );

            towersRemaining--;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 280, 90), "Tower Defense");

        GUI.Label(new Rect(20, 35, 260, 20),
            "1 = Basic Tower | 2 = Tall Tower");

        GUI.Label(new Rect(20, 55, 260, 20),
            "Click on grass to place a tower");

        GUI.Label(new Rect(20, 75, 260, 20),
            "Towers Remaining: " + towersRemaining);
    }
}
