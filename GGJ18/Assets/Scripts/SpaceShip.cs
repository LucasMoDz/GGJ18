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
        laser.rectTransform.sizeDelta = new Vector2(laser.rectTransform.sizeDelta.x, 0);
	    laser.color = new Color(laser.color.r, laser.color.g, 1);
    }

	public void attack() {
		//TODO add laser sound here
		StartCoroutine(fill(.8f));
	}

	public void explode() {
		Debug.Log("Explode ship");
        laser.color = new Color(laser.color.r, laser.color.g, 0);
		//if(explosionParticles != null)
		explosionParticles.Play();
		//GetComponent<Image>().enabled = false;

	    var a = FindObjectsOfType<SpaceShip>();

	    for (int i = 0; i < a.Length; i++)
	    {
	        a[i].explosionParticles.Play();
	    }
	}

    public bool isCollided;

	IEnumerator fill(float time)
	{
	    isCollided = false;
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
        
        laser.color = new Color(1, 1, 1 ,0);
	}
}