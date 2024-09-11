using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitleButton : MonoBehaviour
{
    public void OnBackToTitleButtonPressed()
    {
        SceneManager.LoadScene("Title");
    }
}