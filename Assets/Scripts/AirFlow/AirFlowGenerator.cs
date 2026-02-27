using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider AirFlowRed;
    public Slider AirFlowBlue;
    private float AirFlowPowerNow;

    // Start is called before the first frame update
    void Start()
    {
        AirFlowRed.maxValue = AirFlowPowerCount;
        AirFlowRed.value = AirFlowPowerCount;
        AirFlowBlue.maxValue = AirFlowPowerCount;
        AirFlowBlue.value = AirFlowPowerCount;
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
            if(Input.GetMouseButton(0) && AirFlowAllow == true)
            {
                AirFlowPowerNow = Input.mousePosition.y - clickPosition.y;
                AirFlowBlue.value = AirFlowPowerCount - Mathf.Abs(AirFlowPowerNow);
            }
            if (Input.GetMouseButtonUp(0) && AirFlowAllow == true)
            {
                AirFlowPower = Input.mousePosition.y - clickPosition.y;
                Debug.Log(AirFlowPower);
                Debug.Log(clickPosition);
                clickPosition.y = 0;
                clickPosition.z = 100;//カメラに映るようにするため
                if (AirFlowPowerCount <= Mathf.Abs(AirFlowPower))
                {
                    if (AirFlowPower > 0)
                    {
                        AirFlowPower = AirFlowPowerCount;
                    }
                    else if(AirFlowPower<0)
                    {
                        AirFlowPower = -1 * AirFlowPowerCount;
                    }
                }
                Instantiate(AirFlow, Camera.main.ScreenToWorldPoint(clickPosition), AirFlow.transform.rotation);
                AirFlowAllow = false;
                if(AirFlowPower<=-0.01f || 0.01f<=AirFlowPower)
                {
                    AirFlowStageCount += 1;
                }
                AirFlowPowerCount += -1 * Mathf.Abs(AirFlowPower);
                AirFlowRed.value = AirFlowPowerCount;
                AirFlowBlue.value = AirFlowPowerCount;
                

            }
        }
        
    }
}
