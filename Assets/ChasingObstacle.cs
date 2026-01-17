using UnityEngine;

public class ChasingObstacle : MonoBehaviour
{
    [Header("追尾設定")]
    public float moveSpeed = 2f;
    public float chaseRange = 10f; // これ以上離れてたら追尾しない

    private Transform player;

    void Start()
    {
        // Playerタグを持つオブジェクトを探す
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
            // プレイヤーに向かって移動
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}