using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class SpaceshipEvents {
    public static Action<float> moveToPosition;
    public static Action<string> setSprite;
}

public class SpaceShipHandler : MonoBehaviour {

    public GameObject earthObject;
    public Sprite[] spaceshipSprite;

    public void Awake()
    {
        SpaceshipEvents.moveToPosition += reachTime => { StartCoroutine(MoveToPosition(reachTime)); };
        SpaceshipEvents.setSprite += SetCurrentSprite;
    }

    public IEnumerator MoveToPosition(float timeToReachEarth)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToReachEarth;
            transform.position = Vector3.Lerp(currentPos, earthObject.transform.position, t);
            yield return null;
        }
    }


    public void SetCurrentSprite (string raceName)
    {
        switch (raceName) {
            case "rept":
                this.gameObject.GetComponent<Image>().sprite = spaceshipSprite[0];
                break;

            case "robot":
                this.gameObject.GetComponent<Image>().sprite = spaceshipSprite[1];
                break;

            case "bighead":
                this.gameObject.GetComponent<Image>().sprite = spaceshipSprite[2];
                break;
        }
    }
}
