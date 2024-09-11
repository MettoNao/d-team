using UnityEngine;
using TMPro;  // TextMeshProを使用

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; }

    public TextMeshProUGUI timerText;  // 経過時間を表示するTextMeshPro
    private float elapsedTime = 0f;
    private bool isCounting = false;

    void Awake()
    {
        // Singletonの設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンが切り替わっても破棄されない
        }
        else
        {
            Destroy(gameObject); // すでにインスタンスがある場合、削除
        }
    }

    void Update()
    {
        // カウントアップのロジック
        if (isCounting)
        {
            elapsedTime += Time.deltaTime;
            DisplayElapsedTime(); // 秒数を表示
        }
    }

    // カウントを開始する関数
    public void StartTimer()
    {
        isCounting = true;
        elapsedTime = 0f; // タイマーをリセット
    }

    // カウントを停止する関数
    public void StopTimer()
    {
        isCounting = false;
    }

    // 現在の経過秒数を取得する関数
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    // 経過秒数を小数点第二位まで表示する
    private void DisplayElapsedTime()
    {
        float roundedTime = Mathf.Round(elapsedTime * 100f) / 100f; // 小数点第二位で四捨五入
        if (timerText != null)
        {
            timerText.text = roundedTime.ToString("F2") + "秒"; // 小数点以下2桁まで表示
        }
    }
}
