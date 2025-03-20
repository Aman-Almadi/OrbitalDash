using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

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
    public ParticleSystem deathParticles;
    public GameObject player;
    public Camera cam;

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
        Instantiate(deathParticles, player.transform.position, Quaternion.identity).gameObject.SetActive(true);
        CameraShake.Instance.Shake(0.5f, 0.2f);
        StartCoroutine(PlayGameOverMusicAndEffects());

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

    private IEnumerator PlayGameOverMusicAndEffects()
    {
        gameOverPanel.SetActive(true);
        gameOverAnimator.SetTrigger("FadeIn");

        // Play Game Over music
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UpdateHighScoreUI();
        cam.GetComponent<CameraZoom>().ZoomOut();

        yield return new WaitForSecondsRealtime(0.5f);
    }
}
