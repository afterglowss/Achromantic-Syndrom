using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Yarn.Unity;

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut instance;
    private static Material blur;
    
    [YarnCommand("fadeIn")]
    public static void FadeIn(string image, float time)
    {
        Image img = GameObject.Find(image).GetComponent<Image>();
        img.DOFade(1, time);
    }

    [YarnCommand("fadeOut")]
    public static void FadeOut(string image, float time)
    {
        Image img = GameObject.Find(image).GetComponent<Image>();
        img.DOFade(0, time);
    }
    public void Start()
    {
        blur = GameObject.Find("Blur").GetComponent<Image>().material;
        instance = this;
    }



    [YarnCommand("fadeInBlur")]
    public static void FadeInBlur()
    {
        instance.StartCoroutine(FadeInBlurCoroutine());

    }
    
    static IEnumerator FadeInBlurCoroutine()
    {
        float FadeCount = 0;
        while (FadeCount < 2.0f)
        {
            FadeCount += 0.02f;
            yield return new WaitForSeconds(0.0005f);
            blur.SetFloat("_Size", FadeCount);          //메터리얼 프로퍼티 이름을 쓰고 싶다면 앞에 _붙이는 거 잊지마
        }

    }
    [YarnCommand("fadeOutBlur")]
    public static void FadeOutBlur(string image)
    {
        Material blur = GameObject.Find(image).GetComponent<Image>().material;
        instance.StartCoroutine(FadeOutBlurCoroutine(blur));
    }

    static IEnumerator FadeOutBlurCoroutine(Material blur)
    {
        float FadeCount = 2;
        while (FadeCount > 0.02f)
        {
            FadeCount -= 0.02f;
            yield return new WaitForSeconds(0.0005f);
            blur.SetFloat("_Size", FadeCount);          //메터리얼 프로퍼티 이름을 쓰고 싶다면 앞에 _붙이는 거 잊지마
        }

    }


}
