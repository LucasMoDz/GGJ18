using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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


    public void Awake()
    {
        SpaceshipEvents.moveToPosition += reachTime => { StartCoroutine(MoveToPosition(reachTime)); };
        SpaceshipEvents.setSprite += SetCurrentSprite;
		

        shipObjects = new GameObject[3];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            shipObjects[i] = this.transform.GetChild(i).gameObject;
        }

        startPos = shipObjects[currentRace].transform.position;
    }

    public IEnumerator MoveToPosition(float timeToReachEarth)
	{
		shipObjects[currentRace].transform.position = startPos;
		var currentPos = shipObjects[currentRace].transform.position;
		remainingTimePerc = 0f;
		while (remainingTimePerc < 1)
		{
			remainingTimePerc += Time.deltaTime / timeToReachEarth;
			shipObjects[currentRace].transform.position = Vector3.Lerp(currentPos, earthObject.transform.position, remainingTimePerc);
            yield return null;
        }
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
			shipObjects[i].SetActive(false);
		}
		shipObjects[currentRace].SetActive(true);
    }
}
