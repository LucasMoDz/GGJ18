using UnityEngine;
using System.Collections;
using Package.EventManager;
using Package.CustomLibrary;

public class Manager_Tutorial : ManagerBaseClass
{
    [SerializeField]
    private TextActivationTypes activationType = TextActivationTypes.Standard;
    private Repo_Tutorial repo;

    protected override void PreInitialization()
    {
        repo = this.gameObject.GetComponent<Repo_Tutorial>();
        repo.textCanvasGroup.alpha = 0;
    }

    protected override void AddEvents()
    {
        EventManager.AddEvent<Coroutine>(Topic.FadeInAbstractTutorial, TopicType.Function, true);
        EventManager.AddEvent<Coroutine>(Topic.FadeOutAbstractTutorial, TopicType.Function, true);
        EventManager.AddEvent<Coroutine, string>(Topic.WriteTextAbstractTutorial, TopicType.Function, true);
        EventManager.AddEvent(Topic.ClearTextAbstractTutorial, true);
    }

    protected override void AddListeners()
    {
        EventManager.AddListener(Topic.FadeInAbstractTutorial, ()=> UtilitiesUI.ObjectActivation(repo.globalCanvasGroup, .5f));
        EventManager.AddListener(Topic.FadeOutAbstractTutorial, ()=> UtilitiesUI.ObjectDeactivation(repo.globalCanvasGroup, 0, .5f));
        EventManager.AddListener<Coroutine, string>(Topic.WriteTextAbstractTutorial, _text => StartCoroutine(new[] {WriteTextStandardMode(_text), WriteTextFadeMode(_text), WriteTextTypewriterMode(_text)} [(int)activationType]));
        EventManager.AddListener(Topic.ClearTextAbstractTutorial, ()=> { repo.textComponent.text = string.Empty; });
    }

    private IEnumerator WriteTextStandardMode(string _textToShow)
    {
        repo.textComponent.text = _textToShow;
        repo.textCanvasGroup.alpha = 1;
        yield break;
    }

    private IEnumerator WriteTextFadeMode(string _textToShow)
    {
        yield return UtilitiesUI.ObjectDeactivation(repo.textCanvasGroup, 0, .3f);
        repo.textComponent.text = _textToShow;
        yield return UtilitiesUI.ObjectActivation(repo.textCanvasGroup, .3f);
    }

    private IEnumerator WriteTextTypewriterMode(string _textToShow)
    {
        repo.textCanvasGroup.alpha = 1;
        yield return UtilitiesUI.WriteTextInTypewriterStyle(repo.textComponent, _textToShow, 0.05f);
    }
}