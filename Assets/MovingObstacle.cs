using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("移動設定")]
    public Vector2 moveDirection = Vector2.right; // デフォルトは右方向
    public float moveDistance = 3f;               // 往復距離
    public float moveSpeed = 2f;                  // スピード

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private bool movingToTarget = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + moveDirection.normalized * moveDistance;
    }

    void Update()
    {
        Vector2 destination = movingToTarget ? targetPosition : startPosition;
        transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        // 到達したら方向を反転
        if (Vector2.Distance(transform.position, destination) < 0.01f)
        {
            movingToTarget = !movingToTarget;
        }
    }
}