using UnityEditor;
using UnityEngine;

public class MovingObstacleRand : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private Vector2 moveDirection = Vector2.right; // デフォルトは右方向
    [SerializeField] private float moveDistance = 3f;               // 往復距離
    [SerializeField] private float moveSpeed = 2f;                  // スピード

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private bool movingToTarget = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + moveDirection.normalized * moveDistance;

        float initial = Random.Range(0f, 10f);
        transform.position = startPosition + moveDirection.normalized*initial*moveDistance/10;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector2 start = transform.position;
        if(startPosition != Vector2.zero)
            start = startPosition;
        Vector2 end = start + moveDirection.normalized * moveDistance;
        if(targetPosition != Vector2.zero)
            end = targetPosition;

        Gizmos.DrawLine(start, end);
    }
}