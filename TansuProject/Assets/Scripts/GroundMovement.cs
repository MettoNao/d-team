using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 5f;  // 移動スピード
    public float respawnPositionZ = 35f;  // リスポーン時のZ軸位置
    public float destroyThreshold = -20f; // 消滅するZ軸位置
    private Vector3 startPosition;

    void Start()
    {
        // オブジェクトの初期位置を保存
        startPosition = transform.position;
    }

    void Update()
    {
        // 1秒間にspeed分だけZ軸に沿って移動する
        transform.Translate(0, 0, -speed * Time.deltaTime);

        // Z軸が指定した閾値まで到達した場合
        if (transform.position.z <= destroyThreshold)
        {
            // Z軸をリスポーン位置に移動
            Respawn();
        }
    }

    void Respawn()
    {
        // オブジェクトのZ軸をリスポーン位置に設定し、元の位置に戻す
        transform.position = new Vector3(startPosition.x, startPosition.y, respawnPositionZ);
    }
}
