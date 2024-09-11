using UnityEngine;
using TMPro;

public class TimerScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // TextMeshPro���g�p�����X�R�A�\��
    private int score = 0;  // �X�R�A�̏����l
    private float timeInterval = 0.5f;  // 0.5�b���Ƃ̃C���^�[�o��
    private float timer = 0f;  // 0.5�b���J�E���g���邽�߂̃^�C�}�[
    private bool isCounting = false;  // �X�R�A�̃J�E���g���n�܂��Ă��邩�ǂ���

    void Start()
    {
        // �X�R�A�e�L�X�g��������ԂŔ�\���ɂ���
        scoreText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isCounting)
        {
            timer += Time.deltaTime;

            if (timer >= timeInterval)
            {
                score += 5;
                UpdateScoreText();
                timer = 0f;  // �^�C�}�[�����Z�b�g
            }
        }
    }

    // �X�R�A�e�L�X�g���X�V����֐�
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // �X�R�A���擾����֐�
    public int GetScore()
    {
        return score;
    }

    // �X�R�A�����Z�b�g����֐�
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    // �J�E���g�_�E���I����ɌĂ΂��֐�
    public void StartScoring()
    {
        // �X�R�A�e�L�X�g��\�����A�X�R�A���Z���J�n
        scoreText.gameObject.SetActive(true);
        isCounting = true;
    }

    // �X�R�A�̉��Z���~�߂�֐�
    public void StopScoring()
    {
        isCounting = false;
    }
}