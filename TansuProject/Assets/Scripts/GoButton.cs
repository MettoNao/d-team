using UnityEngine;
using UnityEngine.UI;

public class GoButton : MonoBehaviour
{
    public Button goButton;  // Goボタン
    public Image backgroundImage;  // 非表示にするイメージ画像
    public Countdown countdown;  // Countdownスクリプトの参照

    private void Start()
    {
        // ボタンがクリックされるまでカウントダウンは表示しない
        countdown.gameObject.SetActive(false);
    }

    // ボタンが押されたときに呼ばれる関数
    public void OnGoButtonPressed()
    {
        // ボタンと背景画像を非表示にする
        goButton.gameObject.SetActive(false);
        backgroundImage.gameObject.SetActive(false);

        // カウントダウンを表示し、カウントダウンを開始する
        countdown.gameObject.SetActive(true);
        countdown.StartCountdown();
    }
}