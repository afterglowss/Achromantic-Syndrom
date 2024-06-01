using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOption : MonoBehaviour
{
    FullScreenMode screenMode;

    public Toggle fullscreenBtn;

    List<Resolution> resolutions = new();

    public TMP_Dropdown resolutionDropdown;

    public int resolutionNum;

    private void Start()
    {
        Debug.Log(Screen.width + ", " + Screen.height);
        InitUI();
    }
    void InitUI()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            float refreshRate = (float)Screen.resolutions[i].refreshRateRatio.value;
            if (refreshRate == 60f)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        //resolutions.AddRange(Screen.resolutions);
        resolutionDropdown.options.Clear();
       

        int optionNum = 0;
        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRateRatio + "hz";
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdown.value = optionNum;
            }
            optionNum++;
        }

        resolutionDropdown.RefreshShownValue();     //새로고침

        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }
    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void OkBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
    }
}
