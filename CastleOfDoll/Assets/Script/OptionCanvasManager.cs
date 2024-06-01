using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvasManager : MonoBehaviour
{
    public static OptionCanvasManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
