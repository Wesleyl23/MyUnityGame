using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    [SerializeField] const int NUMBERS_OF_HIGHSCORES = 5;
    [SerializeField] const string nameKey = "HighScoreName";
    [SerializeField] const string scoreKey = "HighScore";

    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    [SerializeField] TextMeshProUGUI[] nameTexts;
    [SerializeField] TextMeshProUGUI[] scoreTexts;

    void Start()
    {
        playerName = PData.instance.getName();
        playerScore = PData.instance.getScore();

        SaveScore();
        DisplayHighScores();
    }

    private void SaveScore() 
    {
        for (int i = 0; i < NUMBERS_OF_HIGHSCORES; i++) 
        {
            string currentNameKey = nameKey + i;
            string currentScoreKey = scoreKey + i;

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                if (currentScore > playerScore)
                {
                    int tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);

                    playerScore = tempScore;
                    playerName = tempName;
                }
            }
            else
            {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }
        }  
    }

    public void DisplayHighScores() 
    {
        for(int i = 0; i < NUMBERS_OF_HIGHSCORES; i++) 
        {
            nameTexts[i].text = PlayerPrefs.GetString(nameKey + i);
            scoreTexts[i].text = PlayerPrefs.GetInt(scoreKey + i).ToString();
        }
    }
}
