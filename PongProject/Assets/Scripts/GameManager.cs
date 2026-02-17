using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scoreP1 = 0;
    public int scoreP2 = 0;

    public TextMeshProUGUI scoreTextP1;
    public TextMeshProUGUI scoreTextP2;
    public GameObject panel;
    public TextMeshProUGUI winnerText;

    private bool isGameOver = false;

    void Awake() { instance = this; }

    void Start() { 
        UpdateUI(); 
        #if UNITY_EDITOR
        // Tells Unity Editor to Focus Game View on Play
        EditorApplication.ExecuteMenuItem("Window/General/Game");
        #endif   
    }

    void OnDestroy()
{
    // If this object is destroyed (like when reloading the scene), 
    // clear the instance so it doesn't point to "Dead" objects.
    if (instance == this)
    {
        instance = null;
    }
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Option A: Only restart if the game is over
            if (isGameOver)
            {
                RestartGame();
            }
            // Option B: Allow mid-game restart ONLY if holding Shift (The "Hard Reset")
            else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                RestartGame();
            }
        }
    }

    public void RestartGame() {
        Time.timeScale = 1f; //Ensure game is unpaused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGoal(int player)
    {
        if (isGameOver) return;

        if (player == 1) scoreP1++;
        else scoreP2++;

        UpdateUI();

        if (scoreP1 >= 5 || scoreP2 >= 5)
        {
            EndGame(player);
        }
    }

    public void UpdateUI()
    {
        if (scoreTextP1 != null) scoreTextP1.text = scoreP1.ToString();
        if (scoreTextP2 != null) scoreTextP2.text = scoreP2.ToString();
    }

    public void EndGame(int winner)
    {
        isGameOver = true;
        panel.SetActive(true);
        winnerText.text = $"Player {winner} Wins!\nPress R to Restart";
        Time.timeScale = 0f; //Freeze game
    }
}
