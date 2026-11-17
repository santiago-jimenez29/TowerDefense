
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver { get; private set; }
    public static bool IsVictory { get; private set; }

    void Awake()
    {
        IsGameOver = false;
        IsVictory = false;
        Time.timeScale = 1f;
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

        float width = 440f;
        float height = 250f;

        float x = (Screen.width - width) / 2f;
        float y = (Screen.height - height) / 2f;

        // Background panel
        GUI.Box(new Rect(x, y, width, height), "");

        // Large title
        GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
        titleStyle.fontSize = 34;
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.alignment = TextAnchor.MiddleCenter;

        titleStyle.normal.textColor = IsVictory
            ? Color.green
            : Color.red;

        string title = IsVictory ? "YOU WIN!" : "GAME OVER";

        GUI.Label(
            new Rect(x + 20, y + 30, 400, 60),
            title,
            titleStyle
        );

        // Description
        GUIStyle messageStyle = new GUIStyle(GUI.skin.label);
        messageStyle.fontSize = 20;
        messageStyle.alignment = TextAnchor.MiddleCenter;
        messageStyle.normal.textColor = Color.white;

        string message = IsVictory
            ? "All enemies destroyed!"
            : "An enemy escaped!";

        GUI.Label(
            new Rect(x + 20, y + 100, 400, 40),
            message,
            messageStyle
        );

        // Larger restart button
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 20;

        if (GUI.Button(
            new Rect(x + 105, y + 165, 230, 55),
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
