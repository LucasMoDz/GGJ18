using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthEnergyHandler : MonoBehaviour {

    public int earthEnergyValue = 3;

	public GameObject[] shields;
	public Image laser;

	public GameManager manager;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Spaceship" || coll.gameObject.tag == "Laserbeam") {
			//Debug.Log("ENTER");
			damage();
			coll.enabled = false;
			if(earthEnergyValue > 0) {
				StartCoroutine(manager.delayedGamePhase(1f));
			}
		}
        Debug.Log("La terra è stata attaccata! Energia rimasta= " + earthEnergyValue);
    }

	public void damage() {
		earthEnergyValue -= 1;
		CheckEnergy();
		GetComponent<CircleCollider2D>().radius *= .9f;
	}

	public void attack() {
		
		StartCoroutine(fill(.8f));
	}

	public void reset()
    {
        if (laser == null)
            return;

		laser.fillAmount = 0;
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

	void Update() {
		if(earthEnergyValue == 3) {
			GetComponent<Image>().color = Color.cyan;
		}
		if(earthEnergyValue == 2) {
			GetComponent<Image>().color = Color.yellow;
		}
		else if(earthEnergyValue == 1) {
			GetComponent<Image>().color =  Color.red;
		}
	}


    public void CheckEnergy ()
    {
        switch (earthEnergyValue)
        {
            case 2:

                //Far partire effetto distruzione della prima barriera

                // Turn off shield earth
                //transform.GetChild(0).gameObject.SetActive(false);
				shields[0].gameObject.SetActive(false);
				
                break;

            case 1:

                //Far partire effetto distruzione della prima barriera

                // Turn off shield earth
                //this.transform.GetChild(1).gameObject.SetActive(false);
				shields[1].gameObject.SetActive(false);
                break;

            case 0:
                //Far partire effetto distruzione della terra

                // Turn off earth
                this.transform.gameObject.SetActive(false);
                
                // Call open game over panel request
                GameOverEvent.OpenPanel();

                break;
        }
    }
}
