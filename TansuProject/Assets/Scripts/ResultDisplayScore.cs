using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultDisplayScore : MonoBehaviour
{
    public TextMeshProUGUI resultScoreText; // ���U���g��ʂŃX�R�A��\������e�L�X�gUI

    void Start()
    {
        // TimerScore����X�R�A���擾���ĕ\��
        TimerScore timerScore = FindObjectOfType<TimerScore>();

        if (timerScore != null)
        {
            int finalScore = timerScore.GetScore();
            DisplayScore(finalScore);
        }
    }

    // �X�R�A�����U���g��ʂ̃e�L�X�g�ɕ\������
    void DisplayScore(int score)
    {
        resultScoreText.text = score.ToString();
    }
}