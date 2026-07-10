using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField] private GameFlowManager gameFlowManager;
    private int saveevaluate;//Saveに渡す評価値
    [Header("各種テキスト")]
    [SerializeField] private TextMeshProUGUI restHealthText;
    [SerializeField] private TextMeshProUGUI coinCountText;
    [SerializeField] private TextMeshProUGUI airPowerText;
    [SerializeField] private TextMeshProUGUI rankText;

    [Header("ボタン")]
    [SerializeField] private GameObject[] seals;

    [Header("評価基準")]
    [SerializeField] private float[] criterion = { 0.5f, 0.3f, 0.1f };
    [SerializeField] private string[] rank = { "A", "B", "C" ,"D"};

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"criterion.count{criterion.Count()}");
        StartCoroutine(SetResult());
    }

    private IEnumerator SetResult()
    {
        int maxHealth = gameFlowManager.MaxHealth;
        int restHealth = gameFlowManager.RestHealth;
        int maxCoin = gameFlowManager.MaxCoinCount;
        int totalCoin = gameFlowManager.TotalCoinCount;
        float maxAirPower = gameFlowManager.MaxAirPower;
        float restAirPower = gameFlowManager.RestAirPower;

        restHealthText.SetText($"残りライフ：{restHealth}/{maxHealth}");
        coinCountText.SetText($"コイン獲得数：{totalCoin}/{maxCoin}");
        //airPowerText.SetText($"残り気流量：{Mathf.Floor(restAirPower)}/{maxAirPower}");
        airPowerText.SetText($"残り気流量：{Mathf.Round(100*restAirPower/maxAirPower)}%");

        float score = ((float)restHealth / (float)maxHealth + (float)totalCoin / (float)maxCoin + restAirPower / maxAirPower) / 3.0f;

        rankText.SetText($"");
        //rankText.SetText($"{rank[criterion.Count()]}");

        yield return new WaitForSecondsRealtime(5.5f);

        rankText.SetText("悪");
        saveevaluate=1;
        for (int i = criterion.Count() - 1; i >= 0; i--)
        {
            if (score > criterion[i])
            {
                rankText.SetText($"{rank[i]}");
                saveevaluate=4-i;
            }
        }
        GameObject gamemanager = GameObject.Find("GameManager");//Save
        ScoreManager scoremanager = gamemanager.GetComponent<ScoreManager>();
        scoremanager.Save(gameFlowManager.stageNumber,saveevaluate);

        yield return new WaitForSecondsRealtime(0.8f);

        // 各種ボタンを使用可能にする
        for(int i = 0; i < seals.Count(); i++)
        {
            seals[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //coinCountText.SetText($"{gameFlowManager.TotalCoinCount}");
    }
}
