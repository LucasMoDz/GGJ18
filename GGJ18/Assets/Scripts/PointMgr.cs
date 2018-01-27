using UnityEngine;


public class PointMgr : MonoBehaviour {

	int spaceShipMultiplier;
	public int currentPoints;

	public void init() {
		spaceShipMultiplier = 0;
	}

	public void spaceShipRight(float timeLeft, float totalTime) {
		currentPoints += (spaceShipMultiplier - (int)(timeLeft/totalTime*10));
	}

	public void spaceShipWrong() {
		spaceShipMultiplier = 0;
		currentPoints = (int)Mathf.Clamp(currentPoints - 100, 0, Mathf.Infinity);
	}

	void Start () {
		
	}

}
