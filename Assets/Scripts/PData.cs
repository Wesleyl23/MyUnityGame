using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    public static PData instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerName = "";
        playerScore = 0;
    }

    public void setScore(int s)
    {
        playerScore = s;
    }

    public void setName(string n)
    {
        playerName = n;
    }

    public string getName()
    {
        return playerName;
    }

    public int getScore()
    {
        return playerScore;
    }
}