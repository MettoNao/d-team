using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 5f;  // 初期移動スピード
    public float speedMultiplier = 1.1f;  // スピード増加率、Unityエディタから調整可能
    public float respawnPositionZ = 35f;  // リスポーン時のZ軸位置
    public float destroyThreshold = -20f; // 消滅するZ軸位置
    public int scoreThreshold = 100;  // スコアが何ポイント増えるごとにスピードが増加するかを設定
    private Vector3 startPosition;
    private bool isMoving = false;  // カウントダウン後に移動を開始するためのフラグ
    private int previousScore = 0;  // 前回のスコア

    void Start()
    {
        // オブジェクトの初期位置を保存
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            // 1秒間にspeed分だけZ軸に沿って移動する
            transform.Translate(0, 0, -speed * Time.deltaTime);

            // Z軸が指定した閾値まで到達した場合
            if (transform.position.z <= destroyThreshold)
            {
                // Z軸をリスポーン位置に移動
                Respawn();
            }

            // スコアに基づいてスピードを加速
            AdjustSpeedByScore();
        }
    }

    void Respawn()
    {
        // オブジェクトのZ軸をリスポーン位置に設定し、元の位置に戻す
        transform.position = new Vector3(startPosition.x, startPosition.y, respawnPositionZ);
    }

    // カウントダウン終了後に呼ばれる関数
    public void StartMoving()
    {
        isMoving = true;
    }

    // 移動を停止する関数（必要に応じて）
    public void StopMoving()
    {
        isMoving = false;
    }

    // スコアに応じてスピードを調整する関数
    void AdjustSpeedByScore()
    {
        TimerScore timerScore = FindObjectOfType<TimerScore>();  // TimerScoreスクリプトを取得
        if (timerScore != null)
        {
            int currentScore = timerScore.GetScore();  // 現在のスコアを取得

            // スコアが設定した閾値 (scoreThreshold) 増加するごとにスピードを増加させる
            if (currentScore >= previousScore + scoreThreshold)
            {
                speed *= speedMultiplier;  // スピードを1.1倍（または設定された倍率）にする
                previousScore = currentScore;  // 前回のスコアを更新
            }
        }
    }
}
