using Unity.VisualScripting;
using UnityEngine;

public class RotatingObstacleRand : MonoBehaviour
{
    [Header("回転設定")]
    [SerializeField] private float radius = 2f;         // 半径
    [Tooltip("正の値なら反時計回り、負の値なら時計回り")]
    [SerializeField] private float rotationSpeed = 90f; // 回転速度（度/秒）

    private float currentAngle = 0f;

    // 回転の中心（Scene上での初期配置を参照する）
    private Vector2 centerPoint; 

    void Start()
    {
        // 回転中心を設定
        centerPoint = transform.position;

        float initialAngle = Random.Range(0f, 360f);
        currentAngle = initialAngle;

        float rad = currentAngle * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

        // 新しい位置を設定
        transform.position = centerPoint + offset;
    }
    void Update()
    {
        if (centerPoint == null) return;

        // 回転角度を更新
        currentAngle += rotationSpeed * Time.deltaTime;

        // 角度をラジアンに変換して座標計算
        float rad = currentAngle * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

        // 新しい位置を設定
        transform.position = centerPoint + offset;
    }

    // エディター上に半径を表示
    private void OnDrawGizmos()
    {
        Vector3 center = transform.position;
        if(centerPoint != Vector2.zero)
            center = centerPoint;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, radius);
    }

    
}