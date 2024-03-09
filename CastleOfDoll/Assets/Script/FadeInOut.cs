using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Yarn.Unity;

public class FadeInOut : MonoBehaviour
{

    
    [YarnCommand("fadeIn")]
    public void FadeIn(string image, float time)
    {
        Image img = GameObject.Find(image).GetComponent<Image>();
        img.DOFade(1, time);
    }

    [YarnCommand("fadeOut")]
    public void FadeOut(string image, float time)
    {
        Image img = GameObject.Find(image).GetComponent<Image>();
        img.DOFade(0, time);
    }
    public void Start()
    {
        
    }
    [YarnCommand("fadeInBlur")]
    public void FadeInBlur(string image, float time)
    {
        Material blur = GameObject.Find(image).GetComponent<Image>().material;
        //Debug.Log(blur.GetPropertyNames(MaterialPropertyType.Float)[1]);
        StartCoroutine(FadeInBlurCoroutine(blur));
    }

    IEnumerator FadeInBlurCoroutine(Material blur)
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
    public void FadeOutBlur(string image, float time)
    {
        Material blur = GameObject.Find(image).GetComponent<Image>().material;
        StartCoroutine(FadeOutBlurCoroutine(blur));
    }

    IEnumerator FadeOutBlurCoroutine(Material blur)
    {
        float FadeCount = 0;
        while (FadeCount < 2.0f)
        {
            FadeCount += 0.02f;
            yield return new WaitForSeconds(0.0005f);
            blur.SetFloat("_Size", FadeCount);          //메터리얼 프로퍼티 이름을 쓰고 싶다면 앞에 _붙이는 거 잊지마
        }

    }


}
