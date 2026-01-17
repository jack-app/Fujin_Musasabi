using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [Header("回転設定")]
    public Transform centerPoint;     // 回転の中心（任意のTransform）
    public float radius = 2f;         // 半径
    public float rotationSpeed = 90f; // 回転速度（度/秒）

    private float currentAngle = 0f;

    void Update()
    {
        if (centerPoint == null) return;

        // 回転角度を更新
        currentAngle += rotationSpeed * Time.deltaTime;

        // 角度をラジアンに変換して座標計算
        float rad = currentAngle * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

        // 新しい位置を設定
        transform.position = (Vector2)centerPoint.position + offset;
    }
}