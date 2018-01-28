using System;
using UnityEngine;
using Package.CustomLibrary;
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

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();

        retry.onClick.AddListener(() => { UnityEngine.SceneManagement.SceneManager.LoadScene(0); });//Todo: mercury fai il tuo fade! })

        if (canvasGroup == null)
        {
            Debug.LogError("Public reference on ManagerGameOver is null, fix it\n");
        }
        else
        {
            GameOverEvent.OpenPanel += () => { UtilitiesUI.ObjectActivation(canvasGroup, ConstantValues.FADEINTIME); };
            PointMgr pointClass = FindObjectOfType<PointMgr>();

            if (pointClass.record < pointClass.currentPoints)
            {
                pointClass.record = pointClass.currentPoints;
                UtilitiesGen.WritingToFile(FileName.PlayerData, pointClass.record);
            }

            lastScore.text = pointClass.currentPoints.ToString();
            record.text = pointClass.record.ToString();

            SpaceShipHandler spaceShip = FindObjectOfType<SpaceShipHandler>();
            spaceShip.reset();
            spaceShip.earthObject.GetComponent<EarthEnergyHandler>().reset();
        }
    }
}