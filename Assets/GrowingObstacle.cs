using UnityEngine;
using System.Collections;

public class GrowingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = new Vector3(3f, 3f, 3f);
    [SerializeField] private float growDuration = 2f;

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        float elapsed = 0f;

        while (elapsed < growDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / growDuration);

            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            yield return null;
        }

        // 最終サイズで固定
        transform.localScale = targetScale;
    }
}