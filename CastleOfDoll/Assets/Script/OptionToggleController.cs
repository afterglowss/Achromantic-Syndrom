using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionToggleController : MonoBehaviour
{
    Toggle toggle;
    public CanvasGroup canvasGroup;
    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void ChangedToggle()
    {
        if (toggle.isOn)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

    }
}
