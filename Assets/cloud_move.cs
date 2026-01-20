using UnityEngine;

public class cloud_move : MonoBehaviour
{
    public Vector2 respawnPos = new Vector2(90f, 35f);
    [SerializeField] private float cloudSpeed = -15.0f;
    [SerializeField] private float leftLimitX = -200f;

    void Update()
    {
        // プレイヤー死亡時は停止
        if (PlayerHP.playerHP <= 0) return;

        // 移動
        transform.Translate(cloudSpeed * Time.deltaTime, 0, 0);

        // 画面外判定
        if (transform.localPosition.x <= leftLimitX)
        {
            Destroy(gameObject);
        }
    }
}