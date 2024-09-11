using UnityEngine;
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

    public void ShowResult()
    {
        gameObject.SetActive(true);
    }

    // スコアをリザルト画面のテキストに表示する
    void DisplayScore(int score)
    {
        resultScoreText.text = score.ToString();
    }
}