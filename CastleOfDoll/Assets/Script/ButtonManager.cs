using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else DestroyImmediate(gameObject);

    }
    public void OnButtonClick(string type)
    {
        switch (type)
        {
            case "StartButton":
                SceneChanger.instance.SceneChange("GameScene");
                break;
            default:
                break;
        }


    }
    
}
