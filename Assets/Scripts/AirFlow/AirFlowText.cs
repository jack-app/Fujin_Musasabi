using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AirFlowText : MonoBehaviour
{
    TextMeshProUGUI AirFlow;
    private int AirFlowStageMax = 0;//AirFlowMaxの値を保存
    private int AirFlowScore;//AirFlowMaxからこのStage内でAirFlowを使った数を引いたものになる
    private float AirFlowPowerCount;
    // Start is called before the first frame update
    void Start()
    {
        AirFlow = GetComponent<TextMeshProUGUI>();
        AirFlowGenerator airflowgenerator;
        GameObject obj = GameObject.Find("AirFlowManager");
        airflowgenerator = obj.GetComponent<AirFlowGenerator>();
        AirFlowStageMax = airflowgenerator.AirFlowStageMax;//AirFlowMaxの値を受け取る
    }

    // Update is called once per frame
    void Update()
    {
        AirFlowGenerator airflowgenerator;
        GameObject obj = GameObject.Find("AirFlowManager");
        airflowgenerator = obj.GetComponent<AirFlowGenerator>();
        AirFlowScore=AirFlowStageMax - airflowgenerator.AirFlowStageCount;
        AirFlowPowerCount = Mathf.Round(airflowgenerator.AirFlowPowerCount);
        AirFlow.text = "AirFlow:"+AirFlowScore.ToString()+"\nPower:"+AirFlowPowerCount.ToString();//表示
    }
}
