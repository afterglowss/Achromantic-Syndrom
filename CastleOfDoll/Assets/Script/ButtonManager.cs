using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    Start,
    Back,
    FadeIn,
    FadeInBlur,
}


public class ButtonManager : MonoBehaviour
{
    public ButtonType type;

    private FadeInOut fade;

    private void Start()
    {
        fade = GetComponent<FadeInOut>();
    }
    public void OnButtonClick()
    {
        switch (type)
        {
            case ButtonType.Start:
                SceneChanger.instance.ChangeScene("GameScene");
                break;
            case ButtonType.Back:
                SceneChanger.instance.ChangeScene("StartScene");
                break;
            case ButtonType.FadeIn:
                fade.FadeIn("Noeul", 1);
                break;
            case ButtonType.FadeInBlur:
                fade.FadeInBlur("Blur", 1);
                break;

            default:
                break;
        }


    }
    
}
