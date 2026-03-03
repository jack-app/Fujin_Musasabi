using UnityEngine;
using System.Collections;   // ここ追加
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public int CurrentHealth => currentHealth;

    [Header("無敵設定")]
    public float invincibleDuration = 2.0f;
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer;

    public LifeUIManager uiManager;
    public GameObject gameOverTextObject; // ← Textオブジェクトを登録！

    void Start()
    {
        currentHealth = maxHealth;
        uiManager.UpdateLifeUI(currentHealth, maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (gameOverTextObject != null)
            gameOverTextObject.SetActive(false); // 初期状態では非表示
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Current Health: " + currentHealth);
        uiManager.UpdateLifeUI(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            // ゲームオーバー表示
            if (gameOverTextObject != null)
                gameOverTextObject.SetActive(true);
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        float elapsed = 0f;
        bool visible = true;

        while (elapsed < invincibleDuration)
        {
            visible = !visible;
            if (spriteRenderer != null)
                spriteRenderer.color = visible ? Color.white : new Color(1, 1, 1, 0.3f);

            elapsed += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        if (spriteRenderer != null)
            spriteRenderer.color = Color.white;

        isInvincible = false;
    }
}