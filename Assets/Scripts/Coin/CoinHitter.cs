using UnityEngine;

public class CoinHitter : MonoBehaviour
{
    private CoinManager coinManager;

    [SerializeField] private int coinWait = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            coinManager = gameManager.GetComponent<CoinManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("コインをゲット！");
            coinManager.AddCoinCount(coinWait);
            Destroy(this.gameObject);
        }
    }
}
