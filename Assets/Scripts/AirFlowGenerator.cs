using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlowGenerator : MonoBehaviour
{
    public GameObject AirFlow;
    private Vector3 clickPosition;
    [HideInInspector]public float AirFlowPower;//気流の強さを伝える用
    [HideInInspector]public int AirFlowCameraCount = 0;//AirFlowのカメラ内の個数を数える
    public int AirFlowCameraMax = 3;//AirFlowのカメラ内の最大個数
    public int AirFlowStageMax = 10;//AirFlowのStageの最大個数
    [HideInInspector]public int AirFlowStageCount = 0;//AirFlowのStageの個数
    public float AirFlowPowerCount = 10000f;//Stage内で使える力の上限
    private bool AirFlowAllow = false;//バグ防止、trueでAirFlowを生成できる
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//AirFlow生成
    {
        if (AirFlowCameraCount < AirFlowCameraMax&&AirFlowStageCount<AirFlowStageMax)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickPosition = Input.mousePosition;
                AirFlowAllow = true;
            }
            if (Input.GetMouseButtonUp(0) && AirFlowAllow == true)
            {
                AirFlowPower = Input.mousePosition.y - clickPosition.y;
                Debug.Log(AirFlowPower);
                Debug.Log(clickPosition);
                clickPosition.y = 0;
                clickPosition.z = 100;//カメラに映るようにするため
                if (AirFlowPowerCount >= Mathf.Abs(AirFlowPower))
                {
                    Instantiate(AirFlow, Camera.main.ScreenToWorldPoint(clickPosition), AirFlow.transform.rotation);
                    AirFlowAllow = false;
                    AirFlowStageCount += 1;
                    AirFlowPowerCount += -1 * Mathf.Abs(AirFlowPower);
                }

            }
        }
        
    }
}
