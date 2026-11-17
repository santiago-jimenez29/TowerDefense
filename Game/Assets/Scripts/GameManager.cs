
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver { get; private set; }
    public static bool IsVictory { get; private set; }
    private int enemiesRemaining;
    public int EnemiesRemaining => enemiesRemaining;

    void Awake()
    {
        enemiesRemaining = 0;
        IsGameOver = false;
        IsVictory = false;
        Time.timeScale = 1f;
    }

    
    public void RegisterEnemy()
    {
        enemiesRemaining++;

        Debug.Log("Enemies remaining: " + enemiesRemaining);
    }



    // Called when an enemy reaches the end
    public void EndGame()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;
        IsVictory = false;

        Debug.Log("GAME OVER!");
        Time.timeScale = 0f;
    }

    public void EnemyDefeated()
    {
        if (IsGameOver)
            return;

        enemiesRemaining = Mathf.Max(0, enemiesRemaining - 1);

        Debug.Log("Enemies remaining: " + enemiesRemaining);
    }

    // Called when the enemy is destroyed
    public void WinGame()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;
        IsVictory = true;

        Debug.Log("YOU WIN!");
        Time.timeScale = 0f;
    }

    // Restart the current scene
    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

    void OnGUI()
    {
        if (!IsGameOver)
            return;

        // Larger centered panel
        float width = Mathf.Min(600f, Screen.width - 20f);
        float height = Mathf.Min(320f, Screen.height - 20f);

        float x = (Screen.width - width) / 2f;
        float y = (Screen.height - height) / 2f;

        GUI.Box(new Rect(x, y, width, height), "");

        // Victory or Game Over title
        GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
        titleStyle.fontSize = 44;
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.alignment = TextAnchor.MiddleCenter;

        titleStyle.normal.textColor = IsVictory
            ? Color.green
            : Color.red;

        string title = IsVictory ? "YOU WIN!" : "GAME OVER";

        GUI.Label(
            new Rect(x + 20, y + 35, width - 40, 75),
            title,
            titleStyle
        );

        // Description
        GUIStyle messageStyle = new GUIStyle(GUI.skin.label);
        messageStyle.fontSize = 26;
        messageStyle.alignment = TextAnchor.MiddleCenter;
        messageStyle.normal.textColor = Color.white;

        string message = IsVictory
            ? "All enemies destroyed!"
            : "An enemy escaped!";

        GUI.Label(
            new Rect(x + 20, y + 120, width - 40, 55),
            message,
            messageStyle
        );

        // Larger restart button
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 26;

        float buttonWidth = Mathf.Min(280f, width - 40f);
        float buttonX = x + (width - buttonWidth) / 2f;

        if (GUI.Button(
            new Rect(buttonX, y + height - 95, buttonWidth, 65),
            "Restart Game",
            buttonStyle
        ))
        {
            RestartGame();
        }
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
