using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public Score score;
    public Canvas scoreCanvas;
    public Canvas gameOverCanvas;
    public Text finalScoreText;
    public float Interval;
    public bool isGameOver = false;

    private void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
        }

        if (SceneManager.GetActiveScene().name == "Game")
        {
            gameOverCanvas.enabled = false;
            Time.timeScale = 1f;
            Interval = 0f;

        }
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if (Input.anyKeyDown)
            {
                ChangeScene_Gamestart();
            }
        }
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (PlayerHP.playerHP <= 0 && !isGameOver)
            {
                isGameOver = true;
                DisplayFinalScore();
                scoreCanvas.enabled = false;
                gameOverCanvas.enabled = true;
            }

            if (isGameOver)
            {
                Interval += Time.unscaledDeltaTime;
                if (Interval > 3)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton3))
                    {
                        ChangeScene_Retry();
                    }
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
                    {
                        ChangeScene_Title();
                    }
                }
            }
        }
    }

    private void DisplayFinalScore()
    {
        BigInteger final = score.score;
        finalScoreText.text = final.ToString("N0");
        HighScoreRanking.Instance.UpdateRanking(final);
        Time.timeScale = 0f;
    }

    public void ChangeScene_Retry()
    {
        ResetStatus(SceneManager.GetActiveScene().name);
    }
    public void ChangeScene_Title()
    {
        ResetStatus("Title");
    }
    public void ChangeScene_Gamestart()
    {
        ResetStatus("Game");
    }

    private void ResetStatus(string scenename)
    {
        SceneManager.LoadScene(scenename);
        PlayerHP.playerHP = 5;
        Time.timeScale = 1;
        EnemyManager.S_HP = 0.5f;//èâä˙íl
        EnemyManager.M_HP = 0.5f;//èâä˙íl
        EnemyManager.L_HP = 3.0f;//èâä˙íl
        isGameOver = false;
    }
}