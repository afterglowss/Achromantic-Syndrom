using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MessageController : MonoBehaviour
{
    //public static MessageController instance;
    public static List<Animator> messageAnimator = new();
    //public List<CanvasGroup> chatCanvasGroups = new(); 

    void Start()
    {
        messageAnimator.Add(GameObject.Find("LeoMail").GetComponent<Animator>());
        messageAnimator.Add(GameObject.Find("LeoMomMail").GetComponent<Animator>());
        messageAnimator.Add(GameObject.Find("ExtraMail").GetComponent<Animator>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("messageOnOff")]
    public static void MessageOnOff()
    {
        if (messageAnimator[0].GetBool("MailOn"))
        {
            for (int i = 0; i < messageAnimator.Count; i++)
            {
                messageAnimator[i].SetBool("MailOn", false);
            }
        }
        else
        {
            for (int i = 0; i < messageAnimator.Count; i++)
            {
                messageAnimator[i].SetBool("MailOn", true);
            }
        }
    }

}
