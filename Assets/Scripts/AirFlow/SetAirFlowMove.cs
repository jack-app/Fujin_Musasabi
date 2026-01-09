using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAirFlowMove : MonoBehaviour
{
    public float SetStageSpeed = 1.0f;//気流の横に動くスピード調整
    public float SetStageRange = 15.0f;//気流の消える位置調整
    public float SetSetPower = 1.0f;//それぞれの気流が持つ自身の気流の強さ
    public float SetPowerPower = 1.0f;//気流の力調製用
    Animator animator;//animation用
    
    void Start()//component取得
    {
        animator = GetComponent<Animator>();
    }
    void Awake()//SetPowerをもらう
    {
        if (SetSetPower > 0)//上下反転、アニメーション関係
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 1, transform.localScale.z);
            animator = GetComponent<Animator>();
            animator.SetFloat("AirFlowAnimationSpeed", SetSetPower);
        }
        else if (SetSetPower < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
            animator = GetComponent<Animator>();
            animator.SetFloat("AirFlowAnimationSpeed", SetSetPower*-1);
        }
    }
    void OnTriggerStay2D(Collider2D collision)//Playerに力を加える
    {
        Rigidbody2D PlayerRigidBody = collision.GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag == "Player")
        {
            PlayerRigidBody.AddForce(transform.up * SetSetPower*SetPowerPower, ForceMode2D.Impulse);
        }
    }
    void Update()//気流の横移動（現在未使用）
    {
        transform.Translate(-1 * SetStageSpeed, 0, 0);
        if (transform.position.x < SetStageRange * -1)
        {
            Destroy(gameObject);
        }
    }
}
