using UnityEngine;

public class StageMovement : MonoBehaviour
{
    // �S�[���̈ړ����x
    public float moveSpeed = 5f;

    void Update()
    {
        // Z���v���X�����Ɉړ�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
