using System;
using UnityEngine;
using Package.CustomLibrary;
using System.Collections.Generic;

public static class SymbolsEvents
{
    public static Action<List<Symbol>> ActivatePanel;
    public static Action DecreaseAlpha;
    public static Action IncreaseAlpha;
}

public class ManagerSymbols : MonoBehaviour
{
    public float step = 0.01f;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = this.transform;
        UtilitiesUI.ObjectDeactivation(this.GetComponent<CanvasGroup>());

        SymbolsEvents.ActivatePanel += _list =>
        {
            UtilitiesUI.ObjectActivation(this.GetComponent<CanvasGroup>(), ConstantValues.FADEINTIME);

            for (int i = 0; i < _list.Count; i++)
            {
                Instantiate(_list[i].img, this.transform);
            }
        };

        SymbolsEvents.IncreaseAlpha += () => { ManageAlpha(1); };
        SymbolsEvents.DecreaseAlpha += () => { ManageAlpha(-1); };
    }

    private void ManageAlpha(int _multiplier)
    {
        if (myTransform.childCount <= 0)
            return;

        float finalValue = step * _multiplier;

        if (_multiplier.Equals(1))
        {
            finalValue *= 1.8f;
        }

        for (int i = 0; i < myTransform.childCount; i++)
        {
            CanvasGroup canvasGroup = myTransform.GetChild(i).GetComponent<CanvasGroup>();

            if (canvasGroup == null)
                continue;

            canvasGroup.alpha += finalValue;
        }
    }
}