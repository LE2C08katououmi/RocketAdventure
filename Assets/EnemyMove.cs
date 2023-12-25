using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // 敵の移動速度
    public float moveSpeed = 5f;

    // 左右の移動範囲
    public float moveRange = 10f;

    // 敵の初期位置
    private Vector3 initialPosition;

    void Start()
    {
        // 初期位置を保存
        initialPosition = transform.position;
    }

    void Update()
    {
        // 敵のX座標を更新
        float newPositionX = initialPosition.x + Mathf.PingPong(Time.time * moveSpeed, moveRange * 2) - moveRange;
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
