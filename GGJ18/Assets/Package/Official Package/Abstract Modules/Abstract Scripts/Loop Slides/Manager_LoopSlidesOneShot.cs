using UnityEngine;
using System.Collections;
using Package.EventManager;
using Package.CustomLibrary;

public enum LoopSlidesOneShot_Topics
{
    /// <summary> 1 Result = Coroutine | 0 Parameter </summary>
    PlaySlidesLoopRequest = 0
}

public enum CandidateScene
{
    InventoryShop = 0,
    DeckBuilder = 1,
    DungeonGame = 2
}

public enum LoopTypeEnum { Click = 0, Auto = 1 }

/// <summary> Example: EventManager.Invoke[Coroutine](LoopSlidesOneShot_Topics.PlaySlidesLoopRequest + CandidateScene.InventoryShop.ToString());  </summary>
public class Manager_LoopSlidesOneShot : ManagerBaseClass
{
    [SerializeField] private CandidateScene scene;
    [SerializeField] private LoopTypeEnum loopType;
    [SerializeField] [Header("Work only with: Loop Type > Auto")] private float loopTime;
    [SerializeField] [Space(5)] private Sprite[] spritesToLoop;
    
    private Repo_LoopSlidesOneShot repo;

    protected override void PreInitialization()
    {
        base.PreInitialization();

        repo = this.GetComponent<Repo_LoopSlidesOneShot>();
    }

    protected override void AddEvents()
    {
        base.AddEvents();

        EventManager.AddEvent<Coroutine>(LoopSlidesOneShot_Topics.PlaySlidesLoopRequest + scene.ToString(), TopicType.Function, true);
    }

    protected override void AddListeners()
    {
        base.AddListeners();

        EventManager.AddListener(LoopSlidesOneShot_Topics.PlaySlidesLoopRequest + scene.ToString(), ()=> StartCoroutine(LoopSlidesCO()));
    }

    protected override void Initialization()
    {
        base.Initialization();

        UtilitiesUI.ObjectDeactivation(repo.globalCanvasGroup);
    }

    private IEnumerator LoopSlidesCO()
    {
        repo.image.color = Color.white;
        UtilitiesUI.ObjectActivation(repo.globalCanvasGroup);

        for (int i = 0; i < spritesToLoop.Length; i++)
        {
            //EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.Card);
            repo.image.sprite = spritesToLoop[i];

            if (loopType.Equals(LoopTypeEnum.Click))
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitUntil(()=> Input.GetMouseButtonUp(0));
            }
            else
            {
                yield return new WaitForSecondsRealtime(i == 0 ? loopTime + ConstantValues.FADEINTIME : loopTime);
            }
        }

        yield return UtilitiesUI.ObjectDeactivation(repo.globalCanvasGroup, 0, ConstantValues.FADEOUTTIME);
    }
}