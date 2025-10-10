using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField] private GameFlowManager gameFlowManager;
    [SerializeField] private TextMeshProUGUI coinCountText;

    // Start is called before the first frame update
    void Start()
    {
        coinCountText.SetText($"{gameFlowManager.TotalCoinCount}");
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.SetText($"{gameFlowManager.TotalCoinCount}");
    }
}
