using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetObject; // �������������I�u�W�F�N�g��Transform

    void Update()
    {
        if (targetObject != null)
        {
            // �^�[�Q�b�g�I�u�W�F�N�g��X���W�ɍ��킹�Ĉړ�
            Vector3 newPosition = transform.position;
            newPosition.x = targetObject.position.x;
            transform.position = newPosition;
        }
    }
}

