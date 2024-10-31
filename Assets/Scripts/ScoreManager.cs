using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI LevelText;
    private int score = 0;
    const int score_Threshold = 25;
    public int level;

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
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        UpdateScoreText();
        DisplayScore();
        DisplayLevel();
    }

    public void AddScore(int points) 
    {
        score += points;
        UpdateScoreText();
        if(score >= score_Threshold)
            AdvanceLevel();
        else
            RestartLevel();
    }

    public void DeductPoints(int points) 
    {
        score -= points;
        UpdateScoreText();
    }
    // Update is called once per frame
    void UpdateScoreText() 
    {
        scoreText.text = "Score: " + score;
    }

    private void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void DisplayLevel()
    {
        LevelText.text = "Level: " + (level + 1);
    }

    private void AdvanceLevel()
    {
        if (level < 2)
        {
            SceneManager.LoadScene(level + 1);
        }
        else 
        {
            SceneManager.LoadScene(0);
        }   
    }
    private void RestartLevel()
    {
        Debug.Log("Restarting Level: " + level);
        SceneManager.LoadScene(level); // Reload the current scene
    }
}
