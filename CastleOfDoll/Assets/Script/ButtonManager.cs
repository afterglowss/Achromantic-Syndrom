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
    Message,
}


public class ButtonManager : MonoBehaviour
{
    public ButtonType type;

    private FadeInOut fade;

    
    private void Start()
    {
        fade = GetComponent<FadeInOut>();
    }
    public void Awake()
    {
        
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
                FadeInOut.FadeIn("Doctor", 1);
                break;
            case ButtonType.FadeInBlur:
                FadeInOut.FadeInBlur();
                break;

            case ButtonType.Message:
                MessageController.MessageOnOff();
                break;

            default:
                break;
        }


    }

    
    
}
