using UnityEngine;
using TMPro;

public class TimerScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // TextMeshProを使用したスコア表示
    private int score = 0;  // スコアの初期値
    private float timeInterval = 0.5f;  // 0.5秒ごとのインターバル
    private float timer = 0f;  // 0.5秒をカウントするためのタイマー

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
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

    // スコアを取得する関数
    public int GetScore()
    {
        return score;
    }

    // スコアをリセットする関数
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}