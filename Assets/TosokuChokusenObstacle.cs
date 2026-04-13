using UnityEngine;

public class TosokuChokusenObstacle : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private Vector2 moveDirection = Vector2.right; // 進行方向
    [SerializeField] private float moveSpeed = 2f;                  // スピード

    [Header("起動条件")]
    [SerializeField] private float activationRange = 5f; // x軸距離での起動範囲

    private Transform player;
    private bool isActivated = false;

    void Start()
    {
        // Playerタグを持つオブジェクトを取得
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        // x軸方向の距離のみ取得
        float distanceX = Mathf.Abs(transform.position.x - player.position.x);

        // 一度だけ起動
        if (!isActivated && distanceX <= activationRange)
        {
            isActivated = true;
        }

        // 起動後はずっと直進
        if (isActivated)
        {
            Vector2 dir = moveDirection.normalized;
            transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
        }
    }
}