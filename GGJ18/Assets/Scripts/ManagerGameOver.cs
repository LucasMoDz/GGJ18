using System;
using UnityEngine;
using Package.CustomLibrary;
using UnityEngine.UI;

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

        if (canvasGroup == null)
        {
            Debug.LogError("Public reference on ManagerGameOver is null, fix it\n");
        }
        else
        {
            GameOverEvent.OpenPanel += () => { UtilitiesUI.ObjectActivation(canvasGroup, ConstantValues.FADEINTIME); };
        }

        
    }
}