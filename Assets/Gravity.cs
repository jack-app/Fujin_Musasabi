using UnityEngine;

public class ConstantFall : MonoBehaviour
{
    public float fallSpeed = 2f; // 落下速度（一定）

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
}