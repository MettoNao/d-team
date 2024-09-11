using UnityEngine;

public class EscapeButton : MonoBehaviour
{
    public void OnEscapeButtonPressed()
    {
#if UNITY_EDITOR
        // エディタの場合、再生モードを停止する
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // ビルドされたゲームの場合、アプリケーションを終了する
            Application.Quit();
#endif
    }
}