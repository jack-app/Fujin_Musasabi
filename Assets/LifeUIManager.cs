using UnityEngine;
using UnityEngine.UI;

public class LifeUIManager : MonoBehaviour
{
    public Image[] lifeCircles; // 5つのImageをInspectorで入れる
    public Color aliveColor = Color.white;
    public Color deadColor = Color.gray;

    public void UpdateLifeUI(int currentHealth, int maxHealth)
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