using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button gameOverMenuSelected;
    public Menu gameOverMenu;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateScore(int scoreAdd)
    {
        this.score += scoreAdd;
        this.scoreText.text = score.ToString();
    }

    public void ToggleGameOverMenu()
    {
        this.gameOverMenu.TogglePause();
        this.gameOverMenuSelected.Select();
    }
}
