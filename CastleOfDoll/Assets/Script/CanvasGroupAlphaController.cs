using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupAlphaController : MonoBehaviour
{

    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlphaControl()
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

    public void AlphaOn()
    {
        canvasGroup.alpha = 1f;
    }
    public void AlphaOff()
    {
        canvasGroup.alpha = 0f;
    }
}
