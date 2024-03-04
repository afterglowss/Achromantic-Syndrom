using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundSource;
    [System.Serializable]
    public struct SoundType
    {
        public string name;
        public AudioClip sound;
    }

    public SoundType[] SoundList;

    public static float volume = 0.2f;
    public static SoundManager instance;

    public void SetSoundVolume(float volume)
    {
        SoundManager.volume = volume;
        soundSource.volume = volume;
    }
    public float GetSoundVolume()
    {
        return soundSource.volume;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }
}
