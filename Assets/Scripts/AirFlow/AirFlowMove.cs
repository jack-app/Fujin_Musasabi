using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlowMove : MonoBehaviour
{
    public float StageSpeed = 1.0f;//気流の横に動くスピード調整（現在未使用）
    public float StageRange = 15.0f;//気流の消える位置調整
    public float SetPower = 1.0f;//それぞれの気流が持つ自身の気流の強さ
    public float PowerPower = 1.0f;//気流の力調製用
    Animator animator;//Animation用
    public AudioSource blow;
    
    void Start()//component取得
    {
        animator = GetComponent<Animator>();
    }
    void Awake()//SetPowerをもらう
    {
        AirFlowGenerator airflowgenerator;
        GameObject obj = GameObject.Find("AirFlowManager");
        airflowgenerator = obj.GetComponent<AirFlowGenerator>();
        SetPower = airflowgenerator.AirFlowPower;
        airflowgenerator.AirFlowCameraCount += 1;
        if(airflowgenerator.AirFlowCameraCount==1)
        {
            blow=this.GetComponent<AudioSource>();
            blow.Play();
        }
        Debug.Log(SetPower);
        if (SetPower > -0.01f && SetPower < 0.01f)//力が小さすぎるときの気流の破壊
        {
            airflowgenerator.AirFlowCameraCount += -1;
            Destroy(gameObject);
        }
        if (SetPower > 0)//上下反転、アニメーション関係
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 1, transform.localScale.z);
            animator = GetComponent<Animator>();
            animator.SetFloat("AirFlowAnimationSpeed", SetPower);
        }
        else if (SetPower < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
            animator = GetComponent<Animator>();
            animator.SetFloat("AirFlowAnimationSpeed", SetPower*-1);
        }
    }
    void OnTriggerStay2D(Collider2D collision)//Playerに力を加える
    {
        Rigidbody2D PlayerRigidBody = collision.GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag == "Player")
        {
            PlayerRigidBody.AddForce(transform.up * SetPower*PowerPower, ForceMode2D.Impulse);
        }
    }
    void Update()//元、気流の横移動、今はカメラ外に出たときの気流の消去
    {
        transform.Translate(-1 * StageSpeed, 0, 0);
        if (transform.position.x < StageRange * -1||!GetComponent<Renderer>().isVisible)
        {
            AirFlowGenerator airflowgenerator;
            GameObject obj = GameObject.Find("AirFlowManager");
            airflowgenerator = obj.GetComponent<AirFlowGenerator>();
            airflowgenerator.AirFlowCameraCount += -1;
            if(airflowgenerator.AirFlowCameraCount==0)
            {
                blow=this.GetComponent<AudioSource>();
                blow.Stop();
            }
            Destroy(gameObject);
        }
    }
}
