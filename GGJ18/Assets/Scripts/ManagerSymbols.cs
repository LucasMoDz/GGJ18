using System;
using UnityEngine;
using Package.CustomLibrary;
using System.Collections.Generic;

public static class SymbolsEvents
{
    public static Action<List<Symbol>> ActivatePanel;
}

public class ManagerSymbols : MonoBehaviour
{
    private void Awake()
    {
        UtilitiesUI.ObjectDeactivation(this.GetComponent<CanvasGroup>());

        SymbolsEvents.ActivatePanel += list =>
        {
            UtilitiesUI.ObjectActivation(this.GetComponent<CanvasGroup>(), ConstantValues.FADEINTIME);

            for (int i = 0; i < list.Count; i++)
            {
                Instantiate(list[i].img, this.transform);
            }
        };
    }
}