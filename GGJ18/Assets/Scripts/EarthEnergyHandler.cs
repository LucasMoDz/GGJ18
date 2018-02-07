using System.Collections;
using System.Collections.Generic;
using Package.EventManager;
using UnityEngine;
using UnityEngine.UI;

public class EarthEnergyHandler : MonoBehaviour {

    public int earthEnergyValue = 3;

	public GameObject[] shields;
	public Image laser;
    public bool hit;

	public GameManager manager;

	public ParticleSystem damageParticle;

	void Start() {
        GetComponent<Image>().color = Color.cyan;

        damageParticle.Stop();
	}

	void OnTriggerEnter2D(Collider2D coll) {

        if (coll.gameObject.tag == "Laserbeam")
        {
            //Debug.Log("ENTER");
            coll.enabled = false;
            damage();
        }

        if (coll.gameObject.tag == "Spaceship")
        {
            hit = true;
            coll.enabled = false;
            damage();
        }

    }

	public void damage() {

        earthEnergyValue -= 1;
        GetComponent<CircleCollider2D>().radius *= .9f;

        if (!this.gameObject.activeSelf)
            return;

        Debug.Log("La terra è stata attaccata! Energia rimasta= " + earthEnergyValue);

        StartCoroutine(explosion());

    }

	IEnumerator explosion() {

        yield return new WaitForSeconds(.5f);
        damageParticle.Play();
        yield return new WaitForSeconds(.5f);
        CheckEnergy();

    }

	public void attack() {
        
	    EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.Laser03);

        StartCoroutine(fill(.4f));
		StartCoroutine(explodeShip(.5f));
	}

	IEnumerator explodeShip(float time) {
		yield return new WaitForSeconds(time);
		manager.spaceShip.shipObjects[0].GetComponent<SpaceShip>().explode();
	}

	public void reset()
    {
        hit = false;

        if (laser == null)
            return;
		laser.fillAmount = 0;
		damageParticle.Stop();
	}


    public bool isCollided;

    IEnumerator fill(float time)
    {
        /*
        yield return new WaitForSeconds(0.1f);
		float currTime = 0f;
		while(currTime < time) {
			//Debug.Log(currTime/time);
			currTime += Time.deltaTime;
			laser.fillAmount = currTime/time;
			yield return null;
		}
		laser.fillAmount = 1;

        yield return new WaitForSeconds(0.3f);

	    float step = 0;

	    while (step < 1)
	    {
	        step += Time.deltaTime / 0.2f;
	        laser.fillAmount = Mathf.Lerp(1, 0, step);
	        yield return null;
	    }
        */

        float test = laser.rectTransform.sizeDelta.y;
        laser.color = new Color(1, 1, 1, 1);
        while (!isCollided)
        {
            test += Time.deltaTime * 2000;
            laser.rectTransform.sizeDelta = new Vector2(laser.rectTransform.sizeDelta.x, test);
            yield return null;
        }

        laser.color = new Color(1, 1, 1, 0);
    }


    /*
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
    */


	//void Update() {
	//	if(earthEnergyValue == 3) {
	//		GetComponent<Image>().color = Color.cyan;
	//	}
	//	if(earthEnergyValue == 2) {
	//		GetComponent<Image>().color = Color.yellow;
	//	}
	//	else if(earthEnergyValue == 1) {
	//		GetComponent<Image>().color =  Color.red;
	//	}
	//}


    public void CheckEnergy ()
    {
        switch (earthEnergyValue)
        {
            case 2:

                //Far partire effetto distruzione della prima barriera

                // Turn off shield earth
                //transform.GetChild(0).gameObject.SetActive(false);
				shields[0].gameObject.SetActive(false);
                GetComponent<Image>().color = Color.yellow;

                CheckHit();

                break;

            case 1:

                //Far partire effetto distruzione della seconda barriera
                GetComponent<Image>().color = Color.red;

                // Turn off shield earth
                //this.transform.GetChild(1).gameObject.SetActive(false);
                shields[1].gameObject.SetActive(false);

                CheckHit();

                break;

            case 0:
                //Far partire effetto distruzione della terra
                CheckHit();

                // Call open game over panel request
                GameOverEvent.OpenPanel();

                break;
        }

    }


    public void CheckHit ()
    {
        if (hit)
        {
            manager.spaceShip.StopCoroutineCustom();
            manager.spaceShip.Jump();
            //Se la vita è maggiore di zero fa partire una nuova game phase
            if (earthEnergyValue > 0)
            {
                Debug.Log("Nuova navicella!");
                StartCoroutine(manager.delayedGamePhase(2f));
            }
            else
            {
                Debug.Log("GAME OVER!");
                // Turn off earth
                this.transform.gameObject.SetActive(false);
            }
        } else
        {
            if (earthEnergyValue <= 0)
            {
                Debug.Log("GAME OVER!");
                // Turn off earth
                this.transform.gameObject.SetActive(false);
            }
        }
    }

}
