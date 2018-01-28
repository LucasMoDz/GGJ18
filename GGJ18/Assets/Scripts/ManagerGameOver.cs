using System;
using UnityEngine;
using Package.CustomLibrary;
using Package.EventManager;
using UnityEngine.UI;

public enum FileName
{
    PlayerData = 0
}

public static class GameOverEvent
{
    public static Action OpenPanel;
}

public class ManagerGameOver : MonoBehaviour
{
    public Button retry, exit;
    public Text lastScore, record;
    public GameObject fadeImage;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();

        retry.onClick.AddListener(() => { fadeImage.GetComponent<MainMenu>().LoadLevel(1); }); 
        exit.onClick.AddListener(()=> { fadeImage.GetComponent<MainMenu>().LoadLevel(0); });

        if (canvasGroup == null)
        {
            Debug.LogError("Public reference on ManagerGameOver is null, fix it\n");
        }
        else
        {
            GameOverEvent.OpenPanel += () =>
            {
                EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.Explosion01);

                UtilitiesGen.CallMethod(2, ()=> { UtilitiesUI.ObjectActivation(canvasGroup, ConstantValues.FADEINTIME); });
                PointMgr pointClass = FindObjectOfType<PointMgr>();

                lastScore.text = pointClass.currentPoints.ToString();

                if (pointClass.record < pointClass.currentPoints)
                {
                    pointClass.record = pointClass.currentPoints;
                    UtilitiesGen.WritingToFile(FileName.PlayerData, pointClass.record);
                }

                record.text = pointClass.record.ToString();

                //SpaceShipHandler spaceShip = FindObjectOfType<SpaceShipHandler>();
                //spaceShip.reset();
                //spaceShip.earthObject.GetComponent<EarthEnergyHandler>().reset();
            };
            
        }
    }
}