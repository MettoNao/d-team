using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // スコアを表示するテキストUI
    private int score = 0;  // スコアの初期値
    private float timeInterval = 0.5f;  // 0.5秒ごとのインターバル
    private float timer = 0f;  // 0.5秒をカウントするためのタイマー

    void Update()
    {
        // GameTimerから経過時間を取得してスコアに反映
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            // 0.5秒経過するたびにスコアを5加算
            score += 5;
            UpdateScoreText();
            timer = 0f;  // タイマーをリセット
        }
    }

    // スコアテキストを更新する関数
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}