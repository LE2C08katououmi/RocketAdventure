using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��p�̖��O���

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float initialGravity = 9.81f; // �����̏d�͂̋���
    public float maxGravity = 20.0f; // �ő�̏d�͂̋���
    public Transform goalTransform;
    private Rigidbody rb;
    private bool isReachedGoal = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // �d�͂𖳌���
        rb.freezeRotation = true; // ��]���Œ�
    }

    void Update()
    {
        if (!isReachedGoal)
        {
            // �㉺���E�̈ړ�
            float horizontalInput = -Input.GetAxis("Horizontal"); // A��D�̈ړ����t�ɂ���
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
            Vector3 moveVelocity = moveDirection.normalized * moveSpeed;

            rb.velocity = moveVelocity;

            // ����������Ɉړ����Ȃ�d�͂𖳌���
            if (verticalInput > 0)
            {
                rb.useGravity = false;
            }
            else
            {
                // ������Ɉړ����Ă��Ȃ��ꍇ�A�d�͂����X�ɑ���������
                float currentGravity = Mathf.Lerp(initialGravity, maxGravity, Time.time / 10.0f);
                rb.useGravity = true;
                rb.AddForce(Vector3.down * currentGravity, ForceMode.Acceleration);
            }

            // �S�[���ɓ��B�������`�F�b�N
            if (Vector3.Distance(transform.position, goalTransform.position) < 3.0f)
            {
                Debug.Log("�S�[���ɓ��B���܂����I");
                isReachedGoal = true;

                // �S�[���ɓ��B������Q�[�����I��
                EndGame();
            }
        }
    }

    // �Q�[�����I������֐�
    void EndGame()
    {
        // �A�v���P�[�V�������I��
        Application.Quit();
    }
}
