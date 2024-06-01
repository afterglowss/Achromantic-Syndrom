using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CanvasGroup optionCanvasGroup;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else DestroyImmediate(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        optionCanvasGroup = GameObject.Find("OptionCanvas").GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasGroupOnOff(optionCanvasGroup);
        }
    }

    public static void CanvasGroupOnOff(CanvasGroup canvasGroup)
    {
        if (canvasGroup.alpha >= 1f)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
