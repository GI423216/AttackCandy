using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField, Header("U“®‚·‚éŠÔ")]
    private float shaketime;
    [SerializeField, Header("U“®‚Ì‘å‚«‚³")]
    private float shakemagnitude;

    public GameObject Player;
    private float shakecount;
    private int currentPlayerHP;
    void Start()
    {
        currentPlayerHP = PlayerHP.playerHP;
    }

    void Update()
    {
        shakecheck();
    }
    private void shakecheck()
    {
        if (currentPlayerHP != PlayerHP.playerHP)
        {
            currentPlayerHP = PlayerHP.playerHP;
            shakecount = 0.0f;
            StartCoroutine(shake());
        }
    }

    IEnumerator shake()
    {
        Vector3 initpos = transform.position;

        while (shakecount < shaketime)
        {
            float x = initpos.x + Random.Range(-shakemagnitude, shakemagnitude);
            float y = initpos.y + Random.Range(-shakemagnitude, shakemagnitude);
            transform.position = new Vector3(x, y, -100);

            shakecount += Time.deltaTime;
            if (currentPlayerHP <= 0)
            {
                StopAllCoroutines();
            }
            yield return null;

        }
        transform.position = initpos;
    }
}