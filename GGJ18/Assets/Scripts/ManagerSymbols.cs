﻿using System;
using UnityEngine;
using Package.CustomLibrary;
using System.Collections.Generic;
using Package.EventManager;

public static class SymbolsEvents
{
    public static Action<List<Symbol>> ActivatePanel;
    public static Action DecreaseAlpha;
    public static Action IncreaseAlpha;
}

public class ManagerSymbols : MonoBehaviour
{

	public ParticleSystem peaceParticle;
	public ParticleSystem warParticle;
	public ParticleSystem neutralParticle;

    public float step = 0.035f;

    private Transform myTransform;

    private void Start()
    {
        myTransform = this.transform;
        UtilitiesUI.ObjectDeactivation(this.GetComponent<CanvasGroup>());

		SymbolsEvents.ActivatePanel = null;
		SymbolsEvents.IncreaseAlpha = null;
		SymbolsEvents.DecreaseAlpha = null;

        SymbolsEvents.ActivatePanel += _list =>
        {
            //EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.RadioNoise);
            UtilitiesUI.ObjectActivation(this.GetComponent<CanvasGroup>(), ConstantValues.FADEINTIME);

            for (int i = 0; i < this.transform.childCount; i++)
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }

            for (int i = 0; i < _list.Count; i++)
            {
                Instantiate(_list[i].img, this.transform);
            }
        };

        SymbolsEvents.IncreaseAlpha += () => { ManageAlpha(1); };
        SymbolsEvents.DecreaseAlpha += () => { ManageAlpha(-1); };

		peaceParticle.Stop();
		warParticle.Stop();
		neutralParticle.Stop();
    }

    private void ManageAlpha(int _multiplier)
    {
        if (myTransform.childCount <= 0)
            return;

        float finalValue = step * _multiplier;
        
        if (_multiplier.Equals(1))
        {
            finalValue *= 0.9f;
        }

        for (int i = 0; i < myTransform.childCount; i++)
        {
            CanvasGroup canvasGroup = myTransform.GetChild(i).GetComponent<CanvasGroup>();

            if (canvasGroup == null)
                continue;

            canvasGroup.alpha += finalValue;
        }
    }

	public void spawnParticles(Meaning meaning) {
		if (meaning.Equals(Meaning.WAR)) {
			warParticle.Play();
		}
		else if (meaning.Equals(Meaning.PEACE)) {
			peaceParticle.Play();
		}
		else if (meaning.Equals(Meaning.NEUTRAL)) {
			neutralParticle.Play();
		}
	}
}