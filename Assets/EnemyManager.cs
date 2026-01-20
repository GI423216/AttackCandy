using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Score score;
    public GameObject EnemyParent;
    public GameObject HeartParent;
    public List<GameObject> enemies;
    public List<GameObject> Hearts;

    [SerializeField, Header("敵1")]
    public GameObject enemyS;
    public static float S_HP = 0.5f; // 初期値を設定
    [SerializeField, Header("敵2のHP")]
    public GameObject enemyM;
    public static float M_HP = 0.5f; // 初期値を設定
    [SerializeField, Header("敵3のHP")]
    public GameObject enemyL;

    public static float L_HP = 3; // 初期値を設定

    private float S_HP_upper = 0.03f;
    private float M_HP_upper = 0.04f;
    private float L_HP_upper = 1;

    private float TimeCount_S = 0;
    private float TimeCount_M = 0;
    private float TimeCount_L = 0;

    private float spantime_S;
    private float spantime_M;
    private float spantime_L;

    public GameObject HeartPrefab;
    Vector2 CreatePos;
    public void Start()
    {
        CreatePos = EnemyParent.transform.position;
    }
    public void Update()
    {

        //ゲームが続いているとき
        if (PlayerHP.playerHP > 0)
        {
            TimeCount_S += Time.deltaTime;
            TimeCount_M += Time.deltaTime;
            TimeCount_L += Time.deltaTime;
            if (TimeCount_S > 1 + spantime_S)
            {
                EnemyCreate(enemyS);
                TimeCount_S = 0;
                spantime_S = Random.Range(-0.2f, 0.5f);

            }

            if (TimeCount_M > 2 + spantime_M)
            {
                EnemyCreate(enemyM);
                TimeCount_M = 0;
                spantime_M = Random.Range(-0.2f, 0.5f);

            }

            if (TimeCount_L > 3 + spantime_L)
            {
                EnemyCreate(enemyL);
                TimeCount_L = 0;
                spantime_M = Random.Range(-0.8f, 0.5f);

            }
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
    /// <summary>
        /// 敵を生成するスクリプト
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="Cooltime"></param>
    public void EnemyCreate(GameObject enemy)
    {
        if (enemy == null) return;

        GameObject ganerateEnemy = Instantiate(enemy);

        ganerateEnemy.name = enemy.name;
        ganerateEnemy.transform.parent = EnemyParent.transform;
        ganerateEnemy.transform.position = CreatePos;
        enemies.Add(ganerateEnemy);
    }
    /// <summary>
    /// 敵のHPを増加させる
    /// </summary>
    /// <param name="tag"></param>
    public void EnemyHPUP(string tag)
    {
        switch (tag)
        {
            case "EnemyS":
                S_HP += S_HP_upper;
                S_HP = Mathf.Min(S_HP, 20);
                break;
            case "EnemyM":
                M_HP += M_HP_upper;
                M_HP = Mathf.Min(M_HP, 10);
                break;
            case "EnemyL":
                L_HP += L_HP_upper;
                L_HP = Mathf.Min(L_HP, 30);
                break;
        }
    }
    /// <summary>
    /// 敵を倒したらハートが落ちていく
    /// </summary>
    /// <param name="tag">倒した敵のタグ</param>
    /// <param name="DropPoint">落とすハートの数</param>
    public void DropHeart(Vector2 DeathPos, string tag, int DropPoint)
    {
        Vector2 pos = DeathPos;
        Vector2 spawn = new Vector2(pos.x, pos.y - 2.5f);
        for (int i = 0; i < DropPoint; i++)
        {
            GameObject heart = Instantiate(HeartPrefab, spawn, Quaternion.identity);
            Hearts.Add(heart);
        }
    }
}