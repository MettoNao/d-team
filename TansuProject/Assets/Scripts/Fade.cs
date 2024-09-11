using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    //bool fadeIn = false;
    bool fadeOut = false;

    [SerializeField] float fadeDuration = 1f;
    //[SerializeField] float displayImageDuration = 1f;
    [SerializeField] CanvasGroup canvasGroup;

    float timer;
    void Start()
    {
        //fadeIn = true;
    }

    void Update()
    {
        //if(fadeIn)
        //{
        //    FadeIn();
        //}
        if(fadeOut)
        {
            FadeOut();
        }
    }

    //public void ClickTitleButton()
    //{
    //    fadeOut = true;
    //}

    public void FadeIn()
    {
        timer += Time.deltaTime;

        canvasGroup.alpha = 1 - (timer / fadeDuration);

        //if(timer>fadeDuration)
        //{
        //    SceneManager.LoadScene("Ground");
        //}
    }

    public void FadeOut()
    {
        timer += Time.deltaTime;

        canvasGroup.alpha = timer / fadeDuration;

        //if(timer>fadeDuration+displayImageDuration)
        //{
        //    SceneManager.LoadScene("Ground");
        //}
    }
}
