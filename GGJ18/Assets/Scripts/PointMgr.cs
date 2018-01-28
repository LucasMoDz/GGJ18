using Package.CustomLibrary;
using UnityEngine;
using UnityEngine.UI;


public class PointMgr : MonoBehaviour {

	int spaceShipMultiplier;
	public int currentPoints;
    public int record;
	public Text pointsTxt;
    public Text gainedPoint;

    private void Awake()
    {gainedPoint.gameObject.SetActive(false);
        int recordSaved = UtilitiesGen.ReadingByFile<int>(FileName.PlayerData);
        record = recordSaved;
    }

	public void init() {
		spaceShipMultiplier = 1;
	}

	public void spaceShipRight(float timeLeftPerc)
	{
	    gainedPoint.color = Color.green;
        gainedPoint.gameObject.SetActive(true);
	    gainedPoint.text = "+" + (spaceShipMultiplier + (int)(timeLeftPerc * 100f));
        Color mycolod = pointsTxt.color;
	    //pointsTxt.color = Color.green;
	    UtilitiesGen.CallMethod(1f, () =>
	    {
	        gainedPoint.color = mycolod;

            gainedPoint.gameObject.SetActive(false);
            pointsTxt.color = mycolod;

	        currentPoints += (spaceShipMultiplier + (int)(timeLeftPerc * 100f));
	        spaceShipMultiplier++;
        });

        
	}

	public void spaceShipWrong() {
		spaceShipMultiplier = 1;
	}

    public void DecreasePoint()
    {
        Color defaultcolor = gainedPoint.color;
        gainedPoint.text = "-50";
        gainedPoint.color = Color.red;
        gainedPoint.gameObject.SetActive(true);
        Color mycolod = pointsTxt.color;
        //pointsTxt.color = Color.red;
       

        UtilitiesGen.CallMethod(1, () =>
        {
            gainedPoint.color = defaultcolor;
            gainedPoint.gameObject.SetActive(false);
            pointsTxt.color = mycolod;

            currentPoints -= 50;

            if (currentPoints < 0)
                currentPoints = 0;
        });
    }

	void Start () {
		
	}

	void Update() {
		pointsTxt.text = currentPoints.ToString();
	}


}
