using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [Header("回転設定")]
    public Transform centerPoint;
    public float radius = 2f;
    public float rotationSpeed = 90f;

    public bool clockwise = false; // trueなら時計回り

    private float currentAngle = 0f;

    void Update()
    {
        if (centerPoint == null) return;

        // 方向に応じて回転
        float direction = clockwise ? -1f : 1f;
        currentAngle += direction * rotationSpeed * Time.deltaTime;

        float rad = currentAngle * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

        transform.position = (Vector2)centerPoint.position + offset;
    }
}