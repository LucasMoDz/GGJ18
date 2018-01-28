﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using Package.CustomLibrary;

public static class SpaceshipEvents {
    public static Action<float> moveToPosition;
    public static Action<int> setSprite;
}

public class SpaceShipHandler : MonoBehaviour {

    public GameObject earthObject;
    //public Sprite[] spaceshipSprite;
	public float remainingTimePerc;

	public GameObject[] shipObjects;
	public int currentRace;

	Vector3 startPos;

    private bool exitToCoro;

    public void Awake()
    {
        SpaceshipEvents.moveToPosition += reachTime => { StartCoroutine(MoveToPosition(reachTime)); };
        SpaceshipEvents.setSprite += SetCurrentSprite;
		
//
//        shipObjects = new GameObject[3];
//
//        for (int i = 0; i < this.transform.childCount; i++)
//        {
//            shipObjects[i] = this.transform.GetChild(i).gameObject;
//        }

        startPos = shipObjects[currentRace].transform.position;
    }

    public void StopCoroutineCustom()
    {
        exitToCoro = true;
        StopAllCoroutines();
    }
    
    public IEnumerator MoveToPosition(float timeToReachEarth)
    {
        exitToCoro = false;
		shipObjects[currentRace].transform.position = startPos;
		var currentPos = shipObjects[currentRace].transform.position;
		float currTime = 0f;
		remainingTimePerc = 0f;
		while (currTime < timeToReachEarth && !exitToCoro)
		{
			currTime += Time.deltaTime;
			remainingTimePerc += Time.deltaTime / timeToReachEarth;
			shipObjects[currentRace].transform.position = Vector3.Lerp(startPos, earthObject.transform.position - new Vector3(0f, 20f, 0f), currTime/timeToReachEarth);
            yield return null;
        }
    }

    public void Jump()
    {
        shipObjects[currentRace].transform.DOJump(shipObjects[currentRace].transform.position + new Vector3(-600f, -100, 0), 40, 1, 2.5f);
    }

	public void attack() {
		StopAllCoroutines();
		shipObjects[currentRace].GetComponent<SpaceShip>().attack();
		earthObject.GetComponent<EarthEnergyHandler>().damage();
	}

	public void reset() {
		for(int i=0; i<shipObjects.Length; i++) {
			shipObjects[i].GetComponent<SpaceShip>().reset();
		}
	}

    
    public void SetCurrentSprite (int raceName) {
		currentRace = raceName;
		for(int i=0; i<shipObjects.Length; i++)
        {
			shipObjects[i] = transform.GetChild(i).gameObject;
			shipObjects[i].SetActive(false);
		}
		shipObjects[currentRace].SetActive(true);
		shipObjects[currentRace].GetComponent<CircleCollider2D>().enabled = true;

    }
}
