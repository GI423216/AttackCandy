using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public struct HighScoreEntry
{
    public BigInteger scoreValue;

    public string scoreDisplay;

    public HighScoreEntry(BigInteger value, string display)
    {
        this.scoreValue = value;
        this.scoreDisplay = display;
    }
}

public class HighScoreRanking : MonoBehaviour
{

    public static HighScoreRanking Instance { get; private set; }

    public List<HighScoreEntry> highScores = new List<HighScoreEntry>();

    private const int MAX_RANKING_COUNT = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeRanking();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeRanking()
    {
        if (highScores.Count == 0)
        {
            for (int i = 0; i < MAX_RANKING_COUNT; i++)
            {
                highScores.Add(new HighScoreEntry(BigInteger.Zero, "0"));
            }
        }
    }

    public void UpdateRanking(BigInteger newScore)
    {
        string scoreDisplayString = newScore.ToString("N0");

        var newEntry = new HighScoreEntry(newScore, scoreDisplayString);

        highScores.Add(newEntry);

        highScores = highScores
          .OrderByDescending(e => e.scoreValue)
          .Take(MAX_RANKING_COUNT)
          .ToList();
    }
}