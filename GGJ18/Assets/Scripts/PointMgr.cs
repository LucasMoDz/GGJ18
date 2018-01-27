using UnityEngine;
using UnityEngine.UI;


public class PointMgr : MonoBehaviour {

	int spaceShipMultiplier;
	public int currentPoints;
	public Text pointsTxt;

	public void init() {
		spaceShipMultiplier = 1;
	}

	public void spaceShipRight(float timeLeftPerc) {
		currentPoints += (spaceShipMultiplier - (int)(timeLeftPerc*10));
	}

	public void spaceShipWrong() {
		spaceShipMultiplier = 1;
		currentPoints = (int)Mathf.Clamp(currentPoints - 100, 0, Mathf.Infinity);
	}

	void Start () {
		
	}

	void Update() {
		pointsTxt.text = currentPoints.ToString();
	}


}
