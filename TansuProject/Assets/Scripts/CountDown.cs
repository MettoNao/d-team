using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Countdown : MonoBehaviour
{
    [SerializeField] private List<GroundMovement> groundMovements = new List<GroundMovement>();
    public TextMeshProUGUI countdownText;  // カウントダウン表示用のTextMeshPro
    public float countdownDuration = 3f;  // カウントダウンの時間（3秒）
    public Vector3 initialScale = new Vector3(0.1f, 0.1f, 0.1f);  // 初期のスケール
    public Vector3 finalScale = new Vector3(1f, 1f, 1f);  // 最終的なスケール
    public float zoomSpeed = 2f;  // ズームの速度
    public float fadeOutSpeed = 1f;  // フェードアウトの速度
    public GameTimer gameTimer;  // GameTimerスクリプトの参照
    public GroundMovement groundMovement;  // GroundMovementスクリプトの参照

    private RectTransform countdownRectTransform;

    private void Start()
    {
        countdownRectTransform = countdownText.GetComponent<RectTransform>();
        countdownRectTransform.anchoredPosition = Vector2.zero;  // 位置を中央に設定
        gameObject.SetActive(false);  // 最初はカウントダウン非表示
    }

    // カウントダウンを開始する関数
    public void StartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

    // カウントダウン処理
    private IEnumerator CountdownRoutine()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            countdownText.color = new Color(1f, 1f, 1f, 1f);  // フェードアウト前は完全に表示

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

        // カウントダウン終了後にゲーム開始
        OnCountdownFinished();
    }

    // カウントダウン終了後に実行する処理
    private void OnCountdownFinished()
    {
        Debug.Log("カウントダウンが終了しました！");
        TimerScore timerScore = FindObjectOfType<TimerScore>();
        if (timerScore != null)
        {
            timerScore.StartScoring();  // カウントダウン終了後にスコア加算を開始
        }

        foreach (var ground in groundMovements)
        {
            ground.StartMoving();
        }
    }
}