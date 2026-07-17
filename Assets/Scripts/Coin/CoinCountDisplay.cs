using UnityEngine;
using TMPro;

public class CoinCountDisplay : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countText.SetText("コイン: " + coinManager.CoinCount.ToString("00"));
    }
}
