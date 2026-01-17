using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public LifeUIManager uiManager;
    public GameObject gameOverTextObject; // ← Textオブジェクトを登録！

    void Start()
    {
        currentHealth = maxHealth;
        uiManager.UpdateLifeUI(currentHealth, maxHealth);

        if (gameOverTextObject != null)
            gameOverTextObject.SetActive(false); // 初期状態では非表示
    }

    public void TakeDamage(int damage)
    {
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
    }
}