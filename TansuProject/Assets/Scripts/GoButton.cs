using UnityEngine;
using UnityEngine.UI;

public class GoButton : MonoBehaviour
{
    public Button goButton;  // Go�{�^��
    public Image backgroundImage;  // ��\���ɂ���C���[�W�摜
    public Countdown countdown;  // Countdown�X�N���v�g�̎Q��

    private void Start()
    {
        // �{�^�����N���b�N�����܂ŃJ�E���g�_�E���͕\�����Ȃ�
        countdown.gameObject.SetActive(false);
    }

    // �{�^���������ꂽ�Ƃ��ɌĂ΂��֐�
    public void OnGoButtonPressed()
    {
        // �{�^���Ɣw�i�摜���\���ɂ���
        goButton.gameObject.SetActive(false);
        backgroundImage.gameObject.SetActive(false);

        // �J�E���g�_�E����\�����A�J�E���g�_�E�����J�n����
        countdown.gameObject.SetActive(true);
        countdown.StartCountdown();
    }
}