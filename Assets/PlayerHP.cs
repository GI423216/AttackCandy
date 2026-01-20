using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHP : MonoBehaviour
{
    public static int playerHP = 5;

    private Score score;

    private void Start()
    {
        score = GameObject.Find("ScoreManager").GetComponent<Score>();

    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyS"))//当たったタグが"EnemyS"の場合
        {
            playerHP--;
            score.CandyScoreAdd(1);
        }
        if (collision.gameObject.CompareTag("EnemyM"))//当たったタグが"EnemyM"の場合
        {
            playerHP -= 2;
            score.CandyScoreAdd(2);
        }
        if (collision.gameObject.CompareTag("EnemyL"))//当たったタグが"EnemyL"の場合
        {
            playerHP -= 3;
            score.CandyScoreAdd(3);
        }
    }
}