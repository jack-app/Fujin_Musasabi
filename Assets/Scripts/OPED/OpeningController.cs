using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OpeningController : MonoBehaviour
{
    [System.Serializable]
public class OpeningPage
{
    [TextArea(2, 5)]
    public string message;

    public UnityEngine.Sprite backgroundSprite;
}

    [Header("UI参照")]
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TMP_Text messageText;

    [Header("ページ設定")]
    [SerializeField] private OpeningPage[] pages;

    [Header("表示設定")]
    [SerializeField] private float textSpeed = 0.05f; // 1文字ごとの表示間隔

    [Header("遷移設定")]
    [SerializeField] private bool moveToNextSceneAtEnd = false;
    [SerializeField] private string nextSceneName = "";

    private int currentPageIndex = 0;
    private bool isTyping = false;
    private bool isPageFullyShown = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (pages == null || pages.Length == 0)
        {
            Debug.LogWarning("Opening pages が設定されていません。");
            return;
        }

        ShowPage(currentPageIndex);
    }

    void Update()
    {
        if (pages == null || pages.Length == 0) return;

        // タップ / クリック / Enter / Space で進行
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            OnTap();
        }
    }

    private void OnTap()
    {
        // 文字送り中なら全文表示
        if (isTyping)
        {
            FinishTypingImmediately();
            return;
        }

        // 全文表示済みなら次ページへ
        if (isPageFullyShown)
        {
            currentPageIndex++;

            if (currentPageIndex < pages.Length)
            {
                ShowPage(currentPageIndex);
            }
            else
            {
                FinishOpening();
            }
        }
    }

    private void ShowPage(int pageIndex)
    {
        OpeningPage page = pages[pageIndex];

        if (backgroundImage != null)
        {
            backgroundImage.sprite = page.backgroundSprite;
        }

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeText(page.message));
    }

    private IEnumerator TypeText(string fullText)
    {
        isTyping = true;
        isPageFullyShown = false;
        messageText.text = "";

        for (int i = 0; i < fullText.Length; i++)
        {
            messageText.text += fullText[i];
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
        isPageFullyShown = true;
    }

    private void FinishTypingImmediately()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        messageText.text = pages[currentPageIndex].message;
        isTyping = false;
        isPageFullyShown = true;
    }

    private void FinishOpening()
    {
        Debug.Log("オープニング終了");

        if (moveToNextSceneAtEnd && !string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}