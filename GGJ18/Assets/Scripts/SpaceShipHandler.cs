﻿using System.Collections;
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
    public Sprite[] spaceshipSprite;
	public float remainingTimePerc;

    public void Awake()
    {
        SpaceshipEvents.moveToPosition += reachTime => { StartCoroutine(MoveToPosition(reachTime)); };
        SpaceshipEvents.setSprite += SetCurrentSprite;
    }

    public IEnumerator MoveToPosition(float timeToReachEarth)
	{
		transform.position = new Vector3(140.0f, 500.0f, 0.0f);
        var currentPos = transform.position;
		remainingTimePerc = 0f;
		while (remainingTimePerc < 1)
		{
			remainingTimePerc += Time.deltaTime / timeToReachEarth;
			transform.position = Vector3.Lerp(currentPos, earthObject.transform.position, remainingTimePerc);
            yield return null;
        }
    }

    
    public void SetCurrentSprite (int raceName)
    {
        switch (raceName) {
            case 0:
                this.gameObject.GetComponent<Image>().sprite = spaceshipSprite[0];
                break;

            case 1:
                this.gameObject.GetComponent<Image>().sprite = spaceshipSprite[1];
                break;

            case 2:
                this.gameObject.GetComponent<Image>().sprite = spaceshipSprite[2];
                break;
        }
    }
}
