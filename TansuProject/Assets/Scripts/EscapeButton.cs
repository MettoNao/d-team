using UnityEngine;

public class EscapeButton : MonoBehaviour
{
    public void OnEscapeButtonPressed()
    {
#if UNITY_EDITOR
        // �G�f�B�^�̏ꍇ�A�Đ����[�h���~����
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // �r���h���ꂽ�Q�[���̏ꍇ�A�A�v���P�[�V�������I������
            Application.Quit();
#endif
    }
}