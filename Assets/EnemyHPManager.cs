using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyHPManager : MonoBehaviour
{
    private EnemyManager enemymanager;
    private Score score;
    private SpriteRenderer spriteRenderer;

    public float HP;
    public bool isEnemyHPSet_S, isEnemyHPSet_M, isEnemyHPSet_L;

    public float enemyS_speed = 5.0f;
    public float enemyM_speed = 10.0f;
    public float enemyL_speed = 3f;

    public string enemyTag;
    private int DropCount;

    private bool isFlashingRed = false;
    private float flashTimer = 0f;
    private const float FLASH_DURATION = 0.2f;
    void Start()
    {
        GameObject managerObject = GameObject.FindGameObjectWithTag("Manager");
        score = GameObject.Find("ScoreManager").GetComponent<Score>();

        if (managerObject != null)
        {
            enemymanager = managerObject.GetComponent<EnemyManager>();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();

        enemyTag = this.gameObject.tag;
        if (isEnemyHPSet_S)
        {
            HP = EnemyManager.S_HP;
            DropCount = 1;
        }
        else if (isEnemyHPSet_M)
        {
            HP = EnemyManager.M_HP;
            DropCount = 2;
        }
        else if (isEnemyHPSet_L)
        {
            HP = EnemyManager.L_HP;
            DropCount = 3;
        }
    }

    void Update()
    {
        if (HP > 0)
        {
            if (isEnemyHPSet_S)
            {
                transform.Translate(Vector3.left * enemyS_speed * Time.deltaTime);
            }
            else if (isEnemyHPSet_M)
            {
                transform.Translate(Vector3.left * enemyM_speed * Time.deltaTime);
            }
            else if (isEnemyHPSet_L)
            {
                transform.Translate(Vector3.left * enemyL_speed * Time.deltaTime);

            }
        }
        else if (HP <= 0)
        {

            enemymanager.EnemyHPUP(enemyTag);
            enemymanager.DropHeart(this.transform.position, enemyTag, DropCount);
            score.ScoreAdd();
            Destroy(this.gameObject);
        }

        if (isFlashingRed)
        {
            flashTimer += Time.deltaTime;

            if (flashTimer >= FLASH_DURATION)
            {
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Color.white;
                }
                isFlashingRed = false;
                flashTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
            DamageRed(this.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// ダメージを受けたら赤くなる。
    /// </summary>
    void DamageRed(GameObject enemy)
    {
        if (isFlashingRed)
        {
            return;
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;

            isFlashingRed = true;
            flashTimer = 0f;
        }
    }
}