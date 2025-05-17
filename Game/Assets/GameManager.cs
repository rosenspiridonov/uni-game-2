using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public GameObject mainMenuPanel;
    public TextMeshProUGUI lastScoreText, bestScoreText;

    [Header("Gameplay References")]
    public ScoreCounter scoreCounter;
    public Spawner spawner;
    public Player playerScript; 
    public Transform playerTransform; 

    private Vector3 playerStartPos;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); return; }
    }

    private void Start()
    {
        playerStartPos = playerTransform.position;
        ShowMenu();
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f;

        scoreCounter.ResetScore();
        spawner.ResetSpawner();
        spawner.StartSpawning();

        playerTransform.position = playerStartPos;
        playerScript.enabled = true;
        playerScript.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        spawner.StopSpawning();
        Time.timeScale = 0f;

        int last = Mathf.RoundToInt(scoreCounter.CurrentScore);
        lastScoreText.text = $"Last Score: {last}";

        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (last > best)
        {
            best = last;
            PlayerPrefs.SetInt("BestScore", best);
        }
        bestScoreText.text = $"Best Score: {best}";

        foreach (var b in GameObject.FindGameObjectsWithTag("Danger"))
        {
            Destroy(b);
        }

        mainMenuPanel.SetActive(true);
    }

    private void ShowMenu()
    {
        Time.timeScale = 0f;
        mainMenuPanel.SetActive(true);
    }
}
