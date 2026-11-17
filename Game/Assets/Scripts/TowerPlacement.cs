
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
        if (GameManager.IsGameOver)
            return;

        // Instruction panel
        GUI.Box(new Rect(15, 15, 460, 170), "");

        GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
        titleStyle.fontSize = 26;
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.normal.textColor = Color.white;

        GUIStyle textStyle = new GUIStyle(GUI.skin.label);
        textStyle.fontSize = 20;
        textStyle.normal.textColor = Color.white;

        GUI.Label(
            new Rect(30, 25, 420, 35),
            "TOWER DEFENSE",
            titleStyle
        );

        GUI.Label(
            new Rect(30, 65, 420, 30),
            "1 = Basic Tower    |    2 = Tall Tower",
            textStyle
        );

        GUI.Label(
            new Rect(30, 95, 420, 30),
            "Left-click grass to place towers",
            textStyle
        );

        string selected = selectedTower == 1
            ? "Basic Tower"
            : "Tall Tower";

        GUI.Label(
            new Rect(30, 130, 430, 30),
            "Selected: " + selected +
            "    |    Towers Left: " + towersRemaining,
            textStyle
        );
    }

}
