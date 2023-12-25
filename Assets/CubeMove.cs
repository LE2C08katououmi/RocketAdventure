using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理用の名前空間

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float initialGravity = 9.81f; // 初期の重力の強さ
    public float maxGravity = 20.0f; // 最大の重力の強さ
    public Transform goalTransform;
    private Rigidbody rb;
    private bool isReachedGoal = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // 重力を無効化
        rb.freezeRotation = true; // 回転を固定
    }

    void Update()
    {
        if (!isReachedGoal)
        {
            // 上下左右の移動
            float horizontalInput = -Input.GetAxis("Horizontal"); // AとDの移動を逆にする
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
            Vector3 moveVelocity = moveDirection.normalized * moveSpeed;

            rb.velocity = moveVelocity;

            // もし上方向に移動中なら重力を無効化
            if (verticalInput > 0)
            {
                rb.useGravity = false;
            }
            else
            {
                // 上方向に移動していない場合、重力を徐々に増加させる
                float currentGravity = Mathf.Lerp(initialGravity, maxGravity, Time.time / 10.0f);
                rb.useGravity = true;
                rb.AddForce(Vector3.down * currentGravity, ForceMode.Acceleration);
            }

            // ゴールに到達したかチェック
            if (Vector3.Distance(transform.position, goalTransform.position) < 3.0f)
            {
                Debug.Log("ゴールに到達しました！");
                isReachedGoal = true;

                // ゴールに到達したらゲームを終了
                EndGame();
            }
        }
    }

    // ゲームを終了する関数
    void EndGame()
    {
        // アプリケーションを終了
        Application.Quit();
    }
}
