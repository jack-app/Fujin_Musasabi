using UnityEngine;

public class SwingingObject : MonoBehaviour
{
    [Header("揺れ設定")]
    public float swingAngle = 30f;   // 最大角度
    public float swingSpeed = 2f;    // 揺れる速さ

    private float startZRotation;

    void Start()
    {
        startZRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        float angle = swingAngle * Mathf.Sin(Time.time * swingSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, startZRotation + angle);
    }
}