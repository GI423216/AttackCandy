using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public BigInteger score;
    public int Cscore;
    public BigInteger scoreAdd = 100;
    public int CscoreAdd = 10;

    public Text ScoreText_Score;
    public Text ScoreText_Candy;



    public void ScoreAddChange()
    {
        scoreAdd = scoreAdd * 2;
    }
    public void CScoreAddChange()
    {
        CscoreAdd = CscoreAdd * 2;
    }
    public void CandyScoreAdd(int doub)
    {
        Cscore += (CscoreAdd * doub);
        ScoreText_Candy.text = string.Format("{0}", Cscore);
    }
    public void CandyScoreDown()
    {
        Cscore--;
        ScoreText_Candy.text = string.Format("{0}", Cscore);
    }
    public void ScoreAdd()
    {
        score += scoreAdd;

        ScoreText_Score.text = string.Format("{0}", score);
        Debug.Log("Current Score: " + score);
    }
}