using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGravity : MonoBehaviour
{
    [Header("ゲーム中透過させるフラグ")]
    [SerializeField] private bool vanishInGame = true;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        if(sprite != null && vanishInGame)
            sprite.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("重力を無効化");
            GlideController controller = collision.GetComponent<GlideController>();
            if(controller == null)
                return;
            Vector2 speed = new Vector2(controller.DefaultVelocity.x, 0.0f);
            controller.ChangeDefault(speed, true);
            Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }   
    }
}
