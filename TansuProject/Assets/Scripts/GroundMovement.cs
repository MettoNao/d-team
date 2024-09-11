using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 5f;  // �����ړ��X�s�[�h
    public float speedMultiplier = 1.1f;  // �X�s�[�h�������AUnity�G�f�B�^���璲���\
    public float respawnPositionZ = 35f;  // ���X�|�[������Z���ʒu
    public float destroyThreshold = -20f; // ���ł���Z���ʒu
    public int scoreThreshold = 100;  // �X�R�A�����|�C���g�����邲�ƂɃX�s�[�h���������邩��ݒ�
    private Vector3 startPosition;
    private bool isMoving = false;  // �J�E���g�_�E����Ɉړ����J�n���邽�߂̃t���O
    private int previousScore = 0;  // �O��̃X�R�A

    void Start()
    {
        // �I�u�W�F�N�g�̏����ʒu��ۑ�
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            // 1�b�Ԃ�speed������Z���ɉ����Ĉړ�����
            transform.Translate(0, 0, -speed * Time.deltaTime);

            // Z�����w�肵��臒l�܂œ��B�����ꍇ
            if (transform.position.z <= destroyThreshold)
            {
                // Z�������X�|�[���ʒu�Ɉړ�
                Respawn();
            }

            // �X�R�A�Ɋ�Â��ăX�s�[�h������
            AdjustSpeedByScore();
        }
    }

    void Respawn()
    {
        // �I�u�W�F�N�g��Z�������X�|�[���ʒu�ɐݒ肵�A���̈ʒu�ɖ߂�
        transform.position = new Vector3(startPosition.x, startPosition.y, respawnPositionZ);
    }

    // �J�E���g�_�E���I����ɌĂ΂��֐�
    public void StartMoving()
    {
        isMoving = true;
    }

    // �ړ����~����֐��i�K�v�ɉ����āj
    public void StopMoving()
    {
        isMoving = false;
    }

    // �X�R�A�ɉ����ăX�s�[�h�𒲐�����֐�
    void AdjustSpeedByScore()
    {
        TimerScore timerScore = FindObjectOfType<TimerScore>();  // TimerScore�X�N���v�g���擾
        if (timerScore != null)
        {
            int currentScore = timerScore.GetScore();  // ���݂̃X�R�A���擾

            // �X�R�A���ݒ肵��臒l (scoreThreshold) �������邲�ƂɃX�s�[�h�𑝉�������
            if (currentScore >= previousScore + scoreThreshold)
            {
                speed *= speedMultiplier;  // �X�s�[�h��1.1�{�i�܂��͐ݒ肳�ꂽ�{���j�ɂ���
                previousScore = currentScore;  // �O��̃X�R�A���X�V
            }
        }
    }
}
