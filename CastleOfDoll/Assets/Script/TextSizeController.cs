using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeController : MonoBehaviour
{
    public List<Toggle> textSizeToggleList = new();

    public List<TextMeshProUGUI> textList = new();

    private void Start()
    {
        textSizeToggleList.Clear();
        textList.Clear();

        textSizeToggleList.Add(GameObject.Find("DialogueSizeToggle1").GetComponent<Toggle>());
        textSizeToggleList.Add(GameObject.Find("DialogueSizeToggle2").GetComponent<Toggle>());
        textSizeToggleList.Add(GameObject.Find("DialogueSizeToggle3").GetComponent<Toggle>());

        textList.Add(GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>());
        textList.Add(GameObject.Find("Last Line").GetComponent<TextMeshProUGUI>());
        textList.Add(GameObject.Find("Option View").GetComponent<TextMeshProUGUI>());

    }

    public void ChangedTextSize(Toggle toggle)
    {
        if (toggle == textSizeToggleList[0])        //작게
        {
            foreach (TextMeshProUGUI text in textList)
            {
                text.fontSize = 28f;
            }
        }
        else if (toggle == textSizeToggleList[1])   //보통
        {
            foreach (TextMeshProUGUI text in textList)
            {
                text.fontSize = 32f;
            }
        }
        else                                        //크게
        {
            foreach (TextMeshProUGUI text in textList)
            {
                text.fontSize = 36f;
            }
        }
    }

}
