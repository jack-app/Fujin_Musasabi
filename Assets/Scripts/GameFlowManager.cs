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
    [SerializeField] private int stageNumber;

    //音関係
    [Header("音関係")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip readySound;
    [SerializeField] private AudioClip goSound;

    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip gameFinishSound;
    
    [Header("ステージ名")]
    private string stageName;
    [SerializeField] private string nextStageName;


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

        stageName = SceneManager.GetActiveScene().name;

        audioSource = GetComponent<AudioSource>();

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

    void LateUpdate()
    {
        int pastHealth = restHealth;
        restHealth = playerHealth.CurrentHealth;
        if (restHealth <= 0 && pastHealth != restHealth)
            Invoke("Dead", 0.5f);
    }

    private void Dead()
    {
        audioSource.PlayOneShot(gameOverSound);
        Time.timeScale = 0;
        messageText.enabled = true;
        messageText.SetText("失格！");
        gameOver.SetActive(true);
    }

    IEnumerator GameStart()
    {
        Time.timeScale = 0;
        messageText.SetText("");

        yield return new WaitForSecondsRealtime(1.0f);

        audioSource.PlayOneShot(readySound);
        messageText.SetText("よーい...");

        yield return new WaitForSecondsRealtime(3.0f);

        audioSource.Stop();
        audioSource.PlayOneShot(goSound);
        messageText.SetText("はじめ！");

        yield return new WaitForSecondsRealtime(1.0f);

        messageText.SetText("");
        messageText.enabled = false;

        Time.timeScale = 1;
    }

    public IEnumerator GameEnd()
    {
        Debug.Log("ゴール！");

        int stageProgress = PlayerPrefs.GetInt("Progress", 1);
        if(stageNumber >= stageProgress)
        {
            PlayerPrefs.SetInt("Progress", stageNumber+1);
        }

        Time.timeScale = 0;
        restHealth = playerHealth.CurrentHealth;
        maxCoinCount = coinManager.MaxCoin;
        totalCoinCount = coinManager.CoinCount;
        restAirPower = airFlowGenerator.AirFlowPowerCount;
        //Debug.Log("1");
        yield return new WaitForSecondsRealtime(1.0f);
        //Debug.Log("2");
        audioSource.PlayOneShot(gameFinishSound);
        resultCanvas.SetActive(true);

        //yield return new WaitForSecondsRealtime(0.5f);

        //Time.timeScale = 1.0f;
        //SceneManager.LoadScene("MenuScene");
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene($"{stageName}");
    }
    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
    }
    
    public void TryNextStage()
    {
        Time.timeScale = 1.0f;
        if(nextStageName != "")
        {
            SceneManager.LoadScene($"{nextStageName}");
        }
        else
        {
            Debug.Log("シーン名が設定されていません");
        }
    }
}
