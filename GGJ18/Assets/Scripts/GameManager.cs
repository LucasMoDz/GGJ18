using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float timeToReachEarth = 20f;
    
    // Use this for initialization
    void Start () {

        //Chiama il metodo che estrae random una razza
        RandomRace();

        //Chiama metodo che avvia la generazione simboli

        //Chiama metodo per attivare gli slider

        //Fa partire il movimento della navicella
        SpaceshipEvents.moveToPosition(timeToReachEarth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RandomRace()
    {
        int randomValue = Random.Range(0, 3);
        string raceName = "null";

        switch (randomValue)
        {
            case 0:
                raceName = "rept";
                break;

            case 1:
                raceName = "robot";
                break;

            case 2:
                raceName = "bigHead";
                break;
        }
        Debug.Log(raceName);
        SpaceshipEvents.setSprite(raceName);

    }


}
