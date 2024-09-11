using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 5f;  // �ړ��X�s�[�h
    public float respawnPositionZ = 35f;  // ���X�|�[������Z���ʒu
    public float destroyThreshold = -20f; // ���ł���Z���ʒu
    private Vector3 startPosition;

    void Start()
    {
        // �I�u�W�F�N�g�̏����ʒu��ۑ�
        startPosition = transform.position;
    }

    void Update()
    {
        // 1�b�Ԃ�speed������Z���ɉ����Ĉړ�����
        transform.Translate(0, 0, -speed * Time.deltaTime);

        // Z�����w�肵��臒l�܂œ��B�����ꍇ
        if (transform.position.z <= destroyThreshold)
        {
            // Z�������X�|�[���ʒu�Ɉړ�
            Respawn();
        }
    }

    void Respawn()
    {
        // �I�u�W�F�N�g��Z�������X�|�[���ʒu�ɐݒ肵�A���̈ʒu�ɖ߂�
        transform.position = new Vector3(startPosition.x, startPosition.y, respawnPositionZ);
    }
}
