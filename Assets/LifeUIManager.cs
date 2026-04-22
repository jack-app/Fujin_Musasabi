using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeUIManager : MonoBehaviour
{
    [Header("ライフ画像")]
    public Image[] lifeCircles;

    [Header("色設定")]
    public Color aliveColor = Color.white;
    public Color deadColor = Color.gray;

    [Header("点滅設定")]
    public int blinkCount = 4;
    public float blinkInterval = 0.15f;

    private int previousHealth = -1;
    private Coroutine[] blinkCoroutines;

    void Awake()
    {
        blinkCoroutines = new Coroutine[lifeCircles.Length];
    }

    public void UpdateLifeUI(int currentHealth, int maxHealth)
    {
        // 初回は普通に反映
        if (previousHealth < 0)
        {
            previousHealth = currentHealth;
            ApplyLifeState(currentHealth);
            return;
        }

        // ダメージを受けたとき、減った分のライフを点滅させる
        if (currentHealth < previousHealth)
        {
            for (int i = currentHealth; i < previousHealth && i < lifeCircles.Length; i++)
            {
                if (blinkCoroutines[i] != null)
                {
                    StopCoroutine(blinkCoroutines[i]);
                }

                blinkCoroutines[i] = StartCoroutine(BlinkWhiteGrayThenDead(i));
            }
        }

        // 残っているライフは白で維持
        for (int i = 0; i < currentHealth && i < lifeCircles.Length; i++)
        {
            lifeCircles[i].color = aliveColor;
        }

        previousHealth = currentHealth;
    }

    private IEnumerator BlinkWhiteGrayThenDead(int index)
    {
        Image target = lifeCircles[index];

        for (int i = 0; i < blinkCount; i++)
        {
            target.color = aliveColor;
            yield return new WaitForSeconds(blinkInterval);

            target.color = deadColor;
            yield return new WaitForSeconds(blinkInterval);
        }

        // 最後は灰色で確定
        target.color = deadColor;
        blinkCoroutines[index] = null;
    }

    private void ApplyLifeState(int currentHealth)
    {
        for (int i = 0; i < lifeCircles.Length; i++)
        {
            if (i < currentHealth)
                lifeCircles[i].color = aliveColor;
            else
                lifeCircles[i].color = deadColor;
        }
    }
}