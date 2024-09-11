using UnityEngine;
using UnityEngine.SceneManagement;  // �V�[���Ǘ��ɕK�v
using TMPro;  // TextMeshPro�ɕK�v

public class RetryButton : MonoBehaviour
{
    public TimerScore timerScore;  // TimerScore�̃��t�@�����X

    // ���g���C�{�^���������ꂽ�Ƃ��ɌĂ΂��֐�
    public void OnRetryButtonPressed()
    {
        // �X�R�A�̃��Z�b�g
        if (timerScore != null)
        {
            timerScore.ResetScore();  // �X�R�A�����Z�b�g
        }

        // ���݂̃V�[�����ēǂݍ��݂��čăX�^�[�g
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}