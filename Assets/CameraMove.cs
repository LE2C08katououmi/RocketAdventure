using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetObject; // 同期させたいオブジェクトのTransform

    void Update()
    {
        if (targetObject != null)
        {
            // ターゲットオブジェクトのX座標に合わせて移動
            Vector3 newPosition = transform.position;
            newPosition.x = targetObject.position.x;
            transform.position = newPosition;
        }
    }
}

