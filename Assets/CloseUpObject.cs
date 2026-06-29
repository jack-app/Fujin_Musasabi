using UnityEngine;
using System.Collections;

public class CloseUpObject : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera targetCamera;

    [Header("Zoom")]
    [SerializeField] private float targetSize = 2f;
    [SerializeField] private float zoomDuration = 1.5f;

    [Header("Camera Offset")]
    [SerializeField] private float targetXOffset = -3f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered)
            return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ZoomCamera());
        }
    }

    private IEnumerator ZoomCamera()
    {
        float startSize = targetCamera.orthographicSize;
        Vector3 startPos = targetCamera.transform.position;

        Vector3 targetPos = new Vector3(
            startPos.x + targetXOffset,
            startPos.y,
            startPos.z
        );

        float elapsed = 0f;

        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / zoomDuration);

            targetCamera.orthographicSize = Mathf.Lerp(startSize, targetSize, t);
            targetCamera.transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        targetCamera.orthographicSize = targetSize;
        targetCamera.transform.position = targetPos;
    }
}