using System.Linq;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coinCount = 0;
    public int CoinCount => coinCount;

    private int maxCoin = 0;
    public int MaxCoin => maxCoin;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        maxCoin = coins.Count();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCoinCount(int coin)
    {
        coinCount += coin;
    }
}
