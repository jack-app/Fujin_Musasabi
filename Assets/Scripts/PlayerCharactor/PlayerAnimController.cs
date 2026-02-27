using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    // "Y" というパラメータ名をハッシュ値に変換してキャッシュ（パフォーマンス向上のため）
    private readonly int animParamY = Animator.StringToHash("Y");

    void Start()
    {
        // 必要なコンポーネントを取得
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Rigidbody2Dから現在のY軸の速度を取得
        float verticalVelocity = rb.velocity.y;

        // 2. Animatorの "Y" パラメータに速度の値を設定
        anim.SetFloat(animParamY, verticalVelocity);
    }
}
