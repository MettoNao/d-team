using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; }

    private float elapsedTime = 0f;
    private bool isCounting = false;

    void Awake()
    {
        // Singleton�̐ݒ�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����؂�ւ���Ă��j������Ȃ�
        }
        else
        {
            Destroy(gameObject); // ���łɃC���X�^���X������ꍇ�A�폜
        }
    }

    void Start()
    {
        // �Q�[���N�����Ɏ����Ń^�C�}�[���J�n
        StartTimer();
    }

    void Update()
    {
        // �J�E���g�A�b�v�̃��W�b�N
        if (isCounting)
        {
            elapsedTime += Time.deltaTime;
            DisplayElapsedTime(); // �b����\��
        }
    }

    // �J�E���g���J�n����֐�
    public void StartTimer()
    {
        isCounting = true;
        elapsedTime = 0f; // �^�C�}�[�����Z�b�g
    }

    // �J�E���g���~����֐�
    public void StopTimer()
    {
        isCounting = false;
    }

    // ���݂̌o�ߕb�����擾����֐�
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    // �o�ߕb���������_���ʂ܂ŕ\������
    private void DisplayElapsedTime()
    {
        float roundedTime = Mathf.Round(elapsedTime * 10f) / 10f; // �����_���ʂŎl�̌ܓ�
        Debug.Log("�o�ߎ���: " + roundedTime.ToString("F1") + "�b"); // �����_�ȉ�2���܂ŕ\��
    }
}