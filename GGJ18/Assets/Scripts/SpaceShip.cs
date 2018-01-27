using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpaceShip : MonoBehaviour {

	Image laser;

	// Use this for initialization
	void Start () {
		laser = transform.GetChild(0).GetComponentInChildren<Image>();
		//laser.fillAmount = .5f;

	}

	public void reset() {
		StopAllCoroutines();
		laser.fillAmount = 0;
	}

	public void attack() {
		//TODO add laser sound here
		StartCoroutine(fill(.8f));
	}

	IEnumerator fill(float time) {
		yield return new WaitForSeconds(.5f);
		float currTime = 0f;
		while(currTime < time) {
			//Debug.Log(currTime/time);
			currTime += Time.deltaTime;
			laser.fillAmount = currTime/time;
			yield return null;
		}
		laser.fillAmount = 1;


	}

}
