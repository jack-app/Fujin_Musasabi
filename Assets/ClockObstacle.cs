using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [Header("回転設定")]
    public float rotationSpeed = 90f; // 1秒あたりの回転角度（度）

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}