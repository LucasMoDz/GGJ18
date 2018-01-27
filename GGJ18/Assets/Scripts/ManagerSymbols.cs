using System;
using UnityEngine;
using System.Collections.Generic;

public static class SymbolsEvents
{
    public static Action<List<Symbol>> ActivatePanel;
}

public class ManagerSymbols : MonoBehaviour
{
    public Transform parent;

    private void Awake()
    {
        if (parent == null)
        {
            Debug.LogError("Public reference on ManagerSymbols is null, please fix it\n");
            return;
        }

        SymbolsEvents.ActivatePanel += list =>
        {
            for (int i = 0; i < list.Count; i++)
            {
                Instantiate(list[i].img, parent);
            }
        };
    }
}