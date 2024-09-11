using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultDisplayScore : MonoBehaviour
{
    public TextMeshProUGUI resultScoreText; // リザルト画面でスコアを表示するテキストUI

    void Start()
    {
        // TimerScoreからスコアを取得して表示
        TimerScore timerScore = FindObjectOfType<TimerScore>();

        if (timerScore != null)
        {
            int finalScore = timerScore.GetScore();
            DisplayScore(finalScore);
        }
    }

    // スコアをリザルト画面のテキストに表示する
    void DisplayScore(int score)
    {
        resultScoreText.text = score.ToString();
    }
}