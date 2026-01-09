using UnityEngine;

public class CoinHitter : MonoBehaviour
{
    private CoinManager coinManager;

    [SerializeField] private int coinWait = 1;
    private AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            coinManager = gameManager.GetComponent<CoinManager>();
            audioSource = gameManager.GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(hitSound);
            Destroy(this.gameObject);
        }
    }
}
