using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Package.CustomLibrary;

public static class StartFeedbackEvent
{
    public static FeedbackDelegate StartGame;
    public delegate Coroutine FeedbackDelegate();
}

public class ManagerStartFeedback : MonoBehaviour
{
    public Repo repo;
    public Fields fields;

    [Serializable]
    public class Repo
    {
        public Image image;
        public Sprite[] sprites;
    }

    [Serializable]
    public class Fields
    {
        public float fadeInSeconds = .3f;
        public float waitTime = .5f;
        public float fadeOutSeconds = .2f;
    }

    private void Awake()
    {
        StartFeedbackEvent.StartGame = ()=> StartCoroutine(StartFeedbackCO());
    }

    private IEnumerator StartFeedbackCO()
    {
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < repo.sprites.Length; i++)
        {
            repo.image.sprite = repo.sprites[i];
            UtilitiesUI.ObjectActivation(repo.image.GetComponent<CanvasGroup>());
            yield return UtilitiesUI.ObjectScalingIn(repo.image.gameObject, fields.fadeInSeconds, fields.waitTime, fields.fadeOutSeconds);
        }

        repo.image.gameObject.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}