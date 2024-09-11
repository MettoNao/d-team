using UnityEngine;
using UnityEngine.SceneManagement;  // シーン管理に必要
using TMPro;  // TextMeshProに必要

public class RetryButton : MonoBehaviour
{
    public TimerScore timerScore;  // TimerScoreのリファレンス

    // リトライボタンが押されたときに呼ばれる関数
    public void OnRetryButtonPressed()
    {
        // スコアのリセット
        if (timerScore != null)
        {
            timerScore.ResetScore();  // スコアをリセット
        }

        // 現在のシーンを再読み込みして再スタート
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}