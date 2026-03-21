using UnityEngine;

public class ChasingObstacle : MonoBehaviour
{
    [Header("追尾設定")]
    public float moveSpeed = 2f;
    public float chaseRange = 10f; // これ以上離れてたら追尾しない
    public float lifeTime = 5f;    // 追尾開始後の寿命

    private Transform player;

    private bool isChasing = false;
    private float chaseStartTime;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            // 追尾開始を記録
            if (!isChasing)
            {
                isChasing = true;
                chaseStartTime = Time.time;
            }

            // プレイヤーに向かって移動
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }

        // 追尾開始から5秒経過したら消滅
        if (isChasing && Time.time - chaseStartTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}