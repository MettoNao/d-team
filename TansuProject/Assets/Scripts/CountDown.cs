using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Countdown : MonoBehaviour
{
    [SerializeField] private List<GroundMovement> groundMovements = new List<GroundMovement>();
    public TextMeshProUGUI countdownText;  // �J�E���g�_�E���\���p��TextMeshPro
    public float countdownDuration = 3f;  // �J�E���g�_�E���̎��ԁi3�b�j
    public Vector3 initialScale = new Vector3(0.1f, 0.1f, 0.1f);  // �����̃X�P�[��
    public Vector3 finalScale = new Vector3(1f, 1f, 1f);  // �ŏI�I�ȃX�P�[��
    public float zoomSpeed = 2f;  // �Y�[���̑��x
    public float fadeOutSpeed = 1f;  // �t�F�[�h�A�E�g�̑��x
    public GameTimer gameTimer;  // GameTimer�X�N���v�g�̎Q��
    public GroundMovement groundMovement;  // GroundMovement�X�N���v�g�̎Q��

    private RectTransform countdownRectTransform;

    private void Start()
    {
        countdownRectTransform = countdownText.GetComponent<RectTransform>();
        countdownRectTransform.anchoredPosition = Vector2.zero;  // �ʒu�𒆉��ɐݒ�
        gameObject.SetActive(false);  // �ŏ��̓J�E���g�_�E����\��
    }

    // �J�E���g�_�E�����J�n����֐�
    public void StartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

    // �J�E���g�_�E������
    private IEnumerator CountdownRoutine()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            countdownText.color = new Color(1f, 1f, 1f, 1f);  // �t�F�[�h�A�E�g�O�͊��S�ɕ\��

            float currentTime = 0f;
            countdownText.transform.localScale = initialScale;

            while (currentTime < 1f)
            {
                countdownText.transform.localScale = Vector3.Lerp(initialScale, finalScale, currentTime * zoomSpeed);
                countdownText.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, currentTime * fadeOutSpeed));
                currentTime += Time.deltaTime;
                yield return null;
            }

            countdownText.transform.localScale = initialScale;
        }

        gameObject.SetActive(false);

        // �J�E���g�_�E���I����ɃQ�[���J�n
        OnCountdownFinished();
    }

    // �J�E���g�_�E���I����Ɏ��s���鏈��
    private void OnCountdownFinished()
    {
        Debug.Log("�J�E���g�_�E�����I�����܂����I");
        TimerScore timerScore = FindObjectOfType<TimerScore>();
        if (timerScore != null)
        {
            timerScore.StartScoring();  // �J�E���g�_�E���I����ɃX�R�A���Z���J�n
        }

        foreach (var ground in groundMovements)
        {
            ground.StartMoving();
        }
    }
}