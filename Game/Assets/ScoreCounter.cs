using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float CurrentScore { get; private set; }

    private void Update()
    {
        if (Time.timeScale > 0f)
        {
            CurrentScore += Time.deltaTime;
            scoreText.text = Mathf.RoundToInt(CurrentScore).ToString();
        }
    }

    public void ResetScore()
    {
        CurrentScore = 0f;
        scoreText.text = "0";
    }
}
