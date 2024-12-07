using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI nameText;
    public int score;
    public int scoreInCurrentLevel;
    const int score_Threshold_Per_Level = 25;
    [SerializeField] int level;

    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start() 
    {
        score = PData.instance.getScore();
        level = SceneManager.GetActiveScene().buildIndex;
        scoreInCurrentLevel = (level - 1) * score_Threshold_Per_Level;
        UpdateScoreText();
        DisplayScore();
        DisplayLevel();
        DisplayName();
    }

    public void AddScore(int points) 
    {
        score += points;
        UpdateScoreText();
        PData.instance.setScore(score);
        
        if (score >= score_Threshold_Per_Level)
        {
            AdvanceLevel();
        }
        else 
        {
            Restartlevel();
        }
    }

    public void DeductPoints(int points) 
    {
        score -= points;
        scoreInCurrentLevel -= points;
        UpdateScoreText();
    }

    void UpdateScoreText() 
    {
        ScoreText.text = "Score: " + scoreInCurrentLevel;
    }

    private void DisplayScore()
    {
        ScoreText.text = "Score: " + scoreInCurrentLevel;
    }

    private void DisplayLevel()
    {
        LevelText.text = "Level: " + (level + 0); 
    }
    private void AdvanceLevel() 
    {
        if (level < 3)
        {
            SceneManager.LoadScene(level + 1);
        }
        else 
        {
            SceneManager.LoadScene(4);
        }
    }

    private void DisplayName() 
    {
        nameText.text = PData.instance.getName();
    }

    private void Restartlevel() 
    {
        Debug.Log("Restarting Level: " + level);
        SceneManager.LoadScene(level);
    }
}
