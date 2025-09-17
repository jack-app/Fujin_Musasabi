using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlowGenerator : MonoBehaviour
{
    public GameObject AirFlow;
    private Vector3 clickPosition;
    public float AirFlowPower;
    //気流の強さを伝える用
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//AirFlow生成
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            AirFlowPower = Input.mousePosition.y - clickPosition.y;
            Debug.Log(AirFlowPower);
            Debug.Log(clickPosition);
            clickPosition.y = 0;
            clickPosition.z = 100;//カメラに映るようにするため
            Instantiate(AirFlow, Camera.main.ScreenToWorldPoint(clickPosition), AirFlow.transform.rotation);
        }
    }
}
