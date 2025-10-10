using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private Canvas ResultCanvas;

    private CoinManager coinManager;

    private int totalCoinCount = 0;
    public int TotalCoinCount => totalCoinCount;

    void Awake()
    {
        ResultCanvas.enabled = false;
        coinManager = this.gameObject.GetComponent<CoinManager>();

        StartCoroutine(GameStart());
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GameStart()
    {
        Time.timeScale = 0;
        startText.SetText("");

        yield return new WaitForSecondsRealtime(1.0f);

        startText.SetText("Ready...");

        yield return new WaitForSecondsRealtime(1.0f);

        startText.SetText("GO!");

        yield return new WaitForSecondsRealtime(1.0f);

        startText.SetText("");
        startText.enabled = false;

        Time.timeScale = 1;
    }

    public IEnumerator GameEnd()
    {
        Debug.Log("ゴール！");
        Time.timeScale = 0;
        totalCoinCount = coinManager.CoinCount;
        Debug.Log("1");
        yield return new WaitForSecondsRealtime(1.0f);
        Debug.Log("2");
        ResultCanvas.enabled = true;

        yield return new WaitForSecondsRealtime(0.5f);

        //Time.timeScale = 1.0f;
        //SceneManager.LoadScene("MenuScene");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
    }
}
