using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coinCount = 0;
    public int CoinCount => coinCount;

    // Start is called before the first frame update
    void Start()
    {

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
