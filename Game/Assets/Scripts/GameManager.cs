
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver { get; private set; }

    void Awake()
    {
        IsGameOver = false;
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;
        Debug.Log("GAME OVER!");

        // Pause the game
        Time.timeScale = 0f;
    }

    void OnGUI()
    {
        if (IsGameOver)
        {
            float x = Screen.width / 2f - 150;
            float y = Screen.height / 2f - 50;

            GUI.Box(
                new Rect(x, y, 300, 100),
                "GAME OVER"
            );

            GUI.Label(
                new Rect(x + 65, y + 45, 220, 30),
                "An enemy escaped!"
            );
        }
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
