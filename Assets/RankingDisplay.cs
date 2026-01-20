using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingDisplay : MonoBehaviour
{
    public Text[] rankTexts;

    void Start()
    {
        DisplayScores();
    }

    public void DisplayScores()
    {
        if (HighScoreRanking.Instance == null) { return; }

        var rankingData = HighScoreRanking.Instance.highScores;

        for (int i = 0; i < rankTexts.Length; i++)
        {
            if (i < rankingData.Count)
            {
                string rankDisplay = rankingData[i].scoreDisplay;
                rankTexts[i].text = rankDisplay;
            }
            else
            {
                rankTexts[i].text = (i + 1) + ". 0";
            }
        }
    }
}