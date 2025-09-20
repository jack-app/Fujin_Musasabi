using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlowGenerator : MonoBehaviour
{
    public GameObject AirFlow;
    private Vector3 clickPosition;
    [HideInInspector]public float AirFlowPower;//気流の強さを伝える用
    [HideInInspector]public int AirFlowCount = 0;//AirFlowの個数を数える
    public int AirFlowMax = 3;//AirFlowの画面内の最大個数
    private bool AirFlowAllow=false;//バグ防止、trueでAirFlowを生成できる
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//AirFlow生成
    {
        if (AirFlowCount < AirFlowMax)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickPosition = Input.mousePosition;
                AirFlowAllow = true;
            }
            if (Input.GetMouseButtonUp(0)&&AirFlowAllow==true)
            {
                AirFlowPower = Input.mousePosition.y - clickPosition.y;
                Debug.Log(AirFlowPower);
                Debug.Log(clickPosition);
                clickPosition.y = 0;
                clickPosition.z = 100;//カメラに映るようにするため
                Instantiate(AirFlow, Camera.main.ScreenToWorldPoint(clickPosition), AirFlow.transform.rotation);
                AirFlowAllow = false;
            }
        }
        
    }
}
