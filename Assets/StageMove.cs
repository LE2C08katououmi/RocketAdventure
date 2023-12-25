using UnityEngine;

public class StageMovement : MonoBehaviour
{
    // ゴールの移動速度
    public float moveSpeed = 5f;

    void Update()
    {
        // Z軸プラス方向に移動
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
