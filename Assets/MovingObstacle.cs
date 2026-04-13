using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("移動設定")]
    public Vector2 moveDirection = Vector2.right; // 任意方向
    public float moveDistance = 3f;               // 距離
    public float moveSpeed = 2f;                  // スピード

    private Vector2 startPosition;
    private float moveTimer = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // 正規化して方向を安定させる
        Vector2 dir = moveDirection.normalized;

        // 往復運動（PingPong）
        float t = Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        transform.position = startPosition + dir * t;
    }
}