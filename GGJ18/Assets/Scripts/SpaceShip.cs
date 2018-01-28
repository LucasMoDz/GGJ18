using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpaceShip : MonoBehaviour {

	public Image laser;

	public ParticleSystem explosionParticles;

	// Use this for initialization
	void Start () {
		//laser = transform.GetChild(0).GetComponentInChildren<Image>();
		//laser.fillAmount = .5f;
		explosionParticles.Stop();
	}

	public void reset() {
		StopAllCoroutines();

        if (laser == null)
            return;
		//GetComponent<Image>().enabled = true;
		laser.fillAmount = 0;
	}

	public void attack() {
		//TODO add laser sound here
		StartCoroutine(fill(.8f));
	}

	public void explode() {
		Debug.Log("Explode ship");
		//if(explosionParticles != null)
		explosionParticles.Play();
		//GetComponent<Image>().enabled = false;
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
