using UnityEngine;

public class GlideController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("滑空の設定")]
    [SerializeField]
    // 通常時の移動速度（右下方向）
    private Vector2 defaultVelocity = new Vector2(5f, -5f);

    [SerializeField]
    // 元の速度に戻る速さ（値が大きいほど速く戻る）
    private float returnSpeed = 2f;


    void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 常に目標の速度（defaultVelocity）に向かって、現在の速度を滑らかに変化させる
        rb.velocity = Vector2.Lerp(
            rb.velocity,
            defaultVelocity,
            returnSpeed * Time.fixedDeltaTime
        );
    }

    // 外部から垂直方向の力を加えるためのメソッド(テスト用)
    public void AddVerticalForce(float force)
    {
        // 瞬間的に力を加える（ForceMode2D.Impulse）
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    // スペースキーを押したら上向きに力を加える(テスト用)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddVerticalForce(12f);
        }
    }
}
