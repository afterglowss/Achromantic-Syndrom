using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else DestroyImmediate(gameObject);
    }
    private Camera mainCamera;
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // �̺�Ʈ�� �߰�
        
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // �̺�Ʈ���� ����*
        Debug.Log("OnDestroy");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mainCamera = FindAnyObjectByType<Camera>();
        gameObject.GetComponent<Canvas>().worldCamera = mainCamera;

        Fade_img.DOFade(0, fadeDuration)
        .OnStart(() => {
            Loading.SetActive(false);
        })
        .OnComplete(() => {
            Fade_img.blocksRaycasts = false;
        });
    }

    public CanvasGroup Fade_img;
    float fadeDuration = 1; //�����Ǵ� �ð�

    public void ChangeScene(string sceneName){
        
        Fade_img.DOFade(1, fadeDuration)
        .OnStart(()=>{
            Fade_img.blocksRaycasts = true; //�Ʒ� ����ĳ��Ʈ ����
        })
        .OnComplete(()=>{
            StartCoroutine("LoadScene", sceneName); /// �� �ε� �ڷ�ƾ ���� ///
        });
    }

    public GameObject Loading;
    public TextMeshProUGUI Loading_text; //�ۼ�Ʈ ǥ���� �ؽ�Ʈ

    IEnumerator LoadScene(string sceneName)
    {
        Loading.SetActive(true); //�ε� ȭ���� ���

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; //�ۼ�Ʈ �����̿�

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true; //�� ��ȯ �غ� �Ϸ�
                    Debug.Log("allowSceneActivation = true");
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            Loading_text.text = percentage.ToString("0") + "%"; //�ε� �ۼ�Ʈ ǥ��
        }
    }
}
