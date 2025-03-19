using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    private AudioSource audioSource;
    public Animator gameOverAnimator;
    private int highScore;
    public TextMeshProUGUI highScoreText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        UpdateScoreUI();
        gameOverPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        UpdateHighScoreUI();
        gameOverPanel.SetActive(true);
        gameOverAnimator.SetTrigger("FadeIn");

        // Play Game Over music
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateHighScoreUI()
    {
        highScoreText.text = "High Score: " + highScore;
    }
}
