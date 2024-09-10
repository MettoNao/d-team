using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // �X�R�A��\������e�L�X�gUI
    private int score = 0;  // �X�R�A�̏����l
    private float timeInterval = 0.5f;  // 0.5�b���Ƃ̃C���^�[�o��
    private float timer = 0f;  // 0.5�b���J�E���g���邽�߂̃^�C�}�[

    void Update()
    {
        // GameTimer����o�ߎ��Ԃ��擾���ăX�R�A�ɔ��f
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            // 0.5�b�o�߂��邽�тɃX�R�A��5���Z
            score += 5;
            UpdateScoreText();
            timer = 0f;  // �^�C�}�[�����Z�b�g
        }
    }

    // �X�R�A�e�L�X�g���X�V����֐�
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}