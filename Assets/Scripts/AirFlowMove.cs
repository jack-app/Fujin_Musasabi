using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlowMove : MonoBehaviour
{
    public float StageSpeed = 1.0f;//気流の横に動くスピード調整
    public float StageRange = 15.0f;//気流の消える位置調整
    public float SetPower = 1.0f;//それぞれの気流が持つ自身の気流の強さ
    public float PowerPower = 1.0f;//気流の力調製用
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()//SetPowerをもらう
    {
        AirFlowGenerator airflowgenerator;
        GameObject obj = GameObject.Find("AirFlowManager");
        airflowgenerator = obj.GetComponent<AirFlowGenerator>();
        SetPower = airflowgenerator.AirFlowPower;
        Debug.Log(SetPower);
    }
    void OnTriggerStay2D(Collider2D collision)//Playerに力を加える
    {
        Rigidbody2D PlayerRigidBody = collision.GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag == "Player")
        {
            PlayerRigidBody.AddForce(transform.up * SetPower*PowerPower, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()//気流の横移動
    {
        transform.Translate(-1 * StageSpeed, 0,0);
        if (transform.position.x < StageRange * -1)
        {
            Destroy(gameObject);
        }
    }
}
