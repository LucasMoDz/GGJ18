using Package.CustomLibrary;
using UnityEngine;
using UnityEngine.UI;


public class PointMgr : MonoBehaviour {

	int spaceShipMultiplier;
	public int currentPoints;
    public int record;
	public Text pointsTxt;

    private void Awake()
    {
        int recordSaved = UtilitiesGen.ReadingByFile<int>(FileName.PlayerData);
        record = recordSaved;
    }

	public void init() {
		spaceShipMultiplier = 1;
	}

	public void spaceShipRight(float timeLeftPerc) {
		//Debug.Log( 100f*timeLeftPerc );
		
		currentPoints += (spaceShipMultiplier + (int)(timeLeftPerc*100f));
		spaceShipMultiplier++;
	}

	public void spaceShipWrong() {
		spaceShipMultiplier = 1;
	}

	void Start () {
		
	}

	void Update() {
		pointsTxt.text = currentPoints.ToString();
	}


}
