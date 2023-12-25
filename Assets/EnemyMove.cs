using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // �G�̈ړ����x
    public float moveSpeed = 5f;

    // ���E�̈ړ��͈�
    public float moveRange = 10f;

    // �G�̏����ʒu
    private Vector3 initialPosition;

    void Start()
    {
        // �����ʒu��ۑ�
        initialPosition = transform.position;
    }

    void Update()
    {
        // �G��X���W���X�V
        float newPositionX = initialPosition.x + Mathf.PingPong(Time.time * moveSpeed, moveRange * 2) - moveRange;
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
