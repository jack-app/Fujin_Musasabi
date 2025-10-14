using UnityEngine;
using System.Collections;   // ここ追加
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public LifeUIManager uiManager;

    [Header("無敵設定")]
    public float invincibleDuration = 2.0f;
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        uiManager.UpdateLifeUI(currentHealth, maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
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