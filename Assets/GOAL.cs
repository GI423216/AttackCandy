using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAL : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    Score Sm;

    public GameObject GoalParents;
    public GameObject GoalTrigger;

    public float amplitude = 7.25f;
    public float frequency = 2.0f;  
    private Vector2 startPos;

    private float GoalSpeed = 0.075f;
    float TimeCount;

    void Start()
    {
        Sm = GameObject.Find("ScoreManager").GetComponent<Score>();
        audioSource = GetComponent<AudioSource>();
        startPos = new Vector2(0.45f, GoalParents.transform.position.y);
    }

    private void Update()
    {
        if (PlayerHP.playerHP <= 0)
        {
            GoalSpeed = 0.0f;
        }
    }

    void FixedUpdate()
    {
        Vector3 currentPos = GoalParents.transform.position;

        currentPos.x += GoalSpeed;

        if (currentPos.x < -6.8f || currentPos.x > 7.7f)
        {
            GoalSpeed *= -1;
            currentPos.x += GoalSpeed;
        }

        float frequency = 2.0f;
        float amplitude = 0.5f;
        currentPos.y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        if (GoalSpeed > 0)
        {
            GoalParents.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            GoalParents.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }

        GoalParents.transform.position = currentPos;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            TimeCount += Time.deltaTime;
            if (TimeCount > 0.75f)
            {
                audioSource.PlayOneShot(sound1);
                Sm.ScoreAddChange();
                Sm.CandyScoreAdd(1);
                TimeCount = 0;
            }
        }
    }
}