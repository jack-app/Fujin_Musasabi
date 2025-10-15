using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject resultCanvas;

    private PlayerHealth playerHealth;
    private CoinManager coinManager;
    private AirFlowGenerator airFlowGenerator;

    private int maxHealth = 1;
    public int MaxHealth => maxHealth;
    private int restHealth = 1;
    public int RestHealth => restHealth;

    private int maxCoinCount = 0;
    public int MaxCoinCount => maxCoinCount;
    private int totalCoinCount = 0;
    public int TotalCoinCount => totalCoinCount;

    private float maxAirPower = 0;
    public float MaxAirPower => maxAirPower;
    private float restAirPower = 0;
    public float RestAirPower => restAirPower;

    void Awake()
    {
        resultCanvas.SetActive(false);
        gameOver.SetActive(false);

        GameObject player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        maxHealth = playerHealth.maxHealth;

        coinManager = this.gameObject.GetComponent<CoinManager>();

        GameObject airFlowManager = GameObject.Find("AirFlowManager");
        airFlowGenerator = airFlowManager.GetComponent<AirFlowGenerator>();
        maxAirPower = airFlowGenerator.AirFlowPowerCount;

        StartCoroutine(GameStart());
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        restHealth = playerHealth.CurrentHealth;
        if (restHealth <= 0)
            Dead();
    }
    
    private void Dead()
    {
        Time.timeScale = 0;
        messageText.enabled = true;
        messageText.SetText("GameOver");
        gameOver.SetActive(true);
    }

    IEnumerator GameStart()
    {
        Time.timeScale = 0;
        messageText.SetText("");

        yield return new WaitForSecondsRealtime(1.0f);

        messageText.SetText("Ready...");

        yield return new WaitForSecondsRealtime(1.0f);

        messageText.SetText("GO!");

        yield return new WaitForSecondsRealtime(1.0f);

        messageText.SetText("");
        messageText.enabled = false;

        Time.timeScale = 1;
    }

    public IEnumerator GameEnd()
    {
        Debug.Log("ゴール！");
        Time.timeScale = 0;
        restHealth = playerHealth.CurrentHealth;
        maxCoinCount = coinManager.MaxCoin;
        totalCoinCount = coinManager.CoinCount;
        restAirPower = airFlowGenerator.AirFlowPower;
        Debug.Log("1");
        yield return new WaitForSecondsRealtime(1.0f);
        Debug.Log("2");
        resultCanvas.SetActive(true);

        //yield return new WaitForSecondsRealtime(0.5f);

        //Time.timeScale = 1.0f;
        //SceneManager.LoadScene("MenuScene");
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("FaiyakitoriScene");
    }
    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
    }
}
