using UnityEngine;
using System.Collections;

public class LightObstacle : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;
    [SerializeField] private float triggerXDistance = 5f;

    [Header("Warning Blink")]
    [SerializeField] private int blinkCount = 3;
    [SerializeField] private float blinkOnTime = 0.15f;
    [SerializeField] private float blinkOffTime = 0.15f;

    [Header("Activation")]
    [SerializeField] private float delayAfterBlink = 0.5f;
    [SerializeField] private float activeDuration = 2f;

    [Header("Colors")]
    [SerializeField] private Color warningColor = Color.yellow; // 点滅予告
    [SerializeField] private Color activeColor = Color.red;     // 本番

    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private bool hasTriggered = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        // 初期状態：透明・当たり判定なし
        SetInvisible();
        SetCollision(false);
    }

    void Update()
    {
        if (hasTriggered || player == null)
            return;

        float xDistance = Mathf.Abs(transform.position.x - player.position.x);

        if (xDistance <= triggerXDistance)
        {
            hasTriggered = true;
            StartCoroutine(ActivateSequence());
        }
    }

    private IEnumerator ActivateSequence()
    {
        // 点滅予告
        for (int i = 0; i < blinkCount; i++)
        {
            SetVisible(warningColor);
            yield return new WaitForSeconds(blinkOnTime);

            SetInvisible();
            yield return new WaitForSeconds(blinkOffTime);
        }

        // 少し待つ
        yield return new WaitForSeconds(delayAfterBlink);

        // 本番
        SetVisible(activeColor);
        SetCollision(true);

        yield return new WaitForSeconds(activeDuration);

        // 消滅
        Destroy(gameObject);
    }

    private void SetVisible(Color color)
    {
        spriteRenderer.color = color;
    }

    private void SetInvisible()
    {
        Color c = spriteRenderer.color;
        c.a = 0f;
        spriteRenderer.color = c;
    }

    private void SetCollision(bool enabled)
    {
        col.enabled = enabled;
    }
}