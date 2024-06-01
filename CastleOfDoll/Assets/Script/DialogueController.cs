using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueController : MonoBehaviour
{
    public static DialogueController instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public DialogueRunner basicRunner;
    public DialogueRunner leoChatRunner;

    //

    [YarnCommand("leoPhoneChat")]
    public static void LeoPhoneChat()
    {
        instance.basicRunner.Stop();
        instance.leoChatRunner.StartDialogue("LeoPhoneChat");
    }

    [YarnCommand("monologue1")]
    public static void Monologue1()
    {
        instance.basicRunner.StartDialogue("Monologue1");
    }

    [YarnCommand("basicDialogue")]
    public static void basicDialogue(string dialogue)
    {
        instance.basicRunner.Stop();
        instance.basicRunner.StartDialogue(dialogue);
    }

    [YarnCommand("leoDialogue")]
    public static void leoDialogue(string dialogue)
    {
        instance.leoChatRunner.Stop();
        instance.leoChatRunner.StartDialogue(dialogue);
    }

}
