using UnityEngine;
using System.Collections;

public class BombObstacle : MonoBehaviour
{
    [Header("追尾設定")]
    public float moveSpeed = 2f;
    public float chaseRange = 10f;
    public float lifeTime = 5f;

    [Header("拡大設定")]
    public float growthMultiplier = 1.5f;   // 寿命直前までに何倍まで大きくなるか
    public float explosionMultiplier = 3f;  // 爆発時に一瞬で何倍になるか

    [Header("点滅設定")]
    public float blinkDuration = 1f;        // 爆発直前の点滅時間
    public float blinkInterval = 0.1f;      // 点滅の間隔

    [Header("爆発設定")]
    public float explosionDuration = 0.15f; // 爆発演出を見せる時間

    private Transform player;
    private bool isChasing = false;
    private bool isExploding = false;
    private bool isBlinking = false;
    private float chaseStartTime;

    private Vector3 initialScale;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        initialScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null || isExploding) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            if (!isChasing)
            {
                isChasing = true;
                chaseStartTime = Time.time;
            }

            // 元のChasingObstacleと同じ追尾
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }

        if (!isChasing) return;

        float elapsed = Time.time - chaseStartTime;
        float remaining = lifeTime - elapsed;

        // 徐々に大きくなる
        float t = Mathf.Clamp01(elapsed / lifeTime);
        float currentMultiplier = Mathf.Lerp(1f, growthMultiplier, t);
        transform.localScale = initialScale * currentMultiplier;

        // 爆発直前1秒間は点滅
        if (!isBlinking && remaining <= blinkDuration)
        {
            StartCoroutine(BlinkRoutine());
        }

        // 寿命が来たら爆発
        if (elapsed >= lifeTime)
        {
            StartCoroutine(ExplodeRoutine());
        }
    }

    private IEnumerator BlinkRoutine()
    {
        isBlinking = true;

        if (spriteRenderer == null)
        {
            yield break;
        }

        while (!isExploding && Time.time - chaseStartTime < lifeTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }

        spriteRenderer.enabled = true;
    }

    private IEnumerator ExplodeRoutine()
    {
        if (isExploding) yield break;

        isExploding = true;

        // 点滅終了時に必ず表示状態へ戻す
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        // 一瞬だけ大きくして爆発表現
        transform.localScale = initialScale * explosionMultiplier;

        yield return new WaitForSeconds(explosionDuration);

        Destroy(gameObject);
    }
}