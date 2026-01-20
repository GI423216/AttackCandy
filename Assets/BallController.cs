using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public GameObject ball;
    float TimeCount;

    void FixedUpdate()
    {
        Vector2 ball_loc = ball.transform.localPosition;
        if (this.gameObject.CompareTag("Ball"))
        {
            if (ball_loc.y <= -7)
            {
                Destroy(ball.gameObject, 0.5f);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        TimeCount += Time.deltaTime;
        if (TimeCount > 0.76f)
        {
            if (other.CompareTag("goal"))
            {
                Destroy(ball.gameObject);
            }
        }
    }
}