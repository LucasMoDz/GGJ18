using UnityEngine;
using System.Collections;
using Package.CustomLibrary;

public static class GameManagerTopics
{
    public static MeaningEvent GetLastMeaning; //INTENTION
    public delegate Meaning MeaningEvent();

    public static RaceEvent GetLastRace;
    public delegate int RaceEvent();
}

[RequireComponent(typeof(PointMgr))]
public class GameManager : MonoBehaviour
{
    public float timeToReachEarth = 20f;

    private Meaning lastMeaning;
    private int lastRace;

	[HideInInspector]
	public PointMgr pointMgr;

	public SpaceShipHandler spaceShip;
	public ManagerSymbols symbols;

    private void Awake()
    {
		GameManagerTopics.GetLastMeaning = null;
		GameManagerTopics.GetLastRace = null;

        GameManagerTopics.GetLastMeaning += ()=> lastMeaning;
        GameManagerTopics.GetLastRace += ()=> lastRace;

		pointMgr = GetComponent<PointMgr>();
    }
    
    private IEnumerator Start ()
    {
        // 3, 2, 1 feedback
        yield return StartFeedbackEvent.StartGame();
		GamePhase();
	}

	public IEnumerator delayedGamePhase(float delay) {
		yield return new WaitForSeconds(delay);
		GamePhase();
	}

    public void GamePhase()
    {
        // Randomize race
        lastRace = Random.Range(0, 3);

		spaceShip.SetCurrentSprite(lastRace);

        // Set lastMeaning variable (that will be called by PhraseGenerator)
        var meanings = UtilitiesGen.GetEnumValues<Meaning>();
        lastMeaning = meanings[Random.Range(0, meanings.Length-1)]; //only war and peace intention

        // Get symbols and generate symbols class
        SymbolsEvents.ActivatePanel(PhraseEvents.GetPhrase().symbols);

        // Activate slider
        SliderEvents.SliderActivation(true);

        // Move space ship
		StartCoroutine(spaceShip.MoveToPosition(timeToReachEarth));

		spaceShip.reset();
		spaceShip.earthObject.GetComponent<EarthEnergyHandler>().reset();
    }

	public void handleAnswer(Meaning meaning) {

		Debug.Log(meaning);

		if(meaning.Equals(Meaning.PEACE)) {
			if(lastMeaning.Equals(Meaning.PEACE)) {
				Debug.Log("RIGHT");
				spaceShip.StopCoroutineCustom();
				//TODO love animation
                spaceShip.Jump();
				pointMgr.spaceShipRight(spaceShip.remainingTimePerc);
				StartCoroutine(delayedGamePhase(2.5f));
                
			}
			else {
				Debug.Log("WRONG");
			    spaceShip.StopCoroutineCustom();
                pointMgr.spaceShipWrong();
				spaceShip.attack();
				StartCoroutine(delayedGamePhase(3.2f));
			    UtilitiesGen.CallMethod(1.8f, () => { spaceShip.Jump(); });
			}
		}
	 	else if(meaning.Equals(Meaning.WAR)) {
			if(lastMeaning.Equals(Meaning.WAR)) {
				Debug.Log("RIGHT");
			    spaceShip.StopCoroutineCustom();
                pointMgr.spaceShipRight(spaceShip.remainingTimePerc);
			
				//TODO explosion effect e pistola simbolo
				spaceShip.earthObject.GetComponent<EarthEnergyHandler>().attack();
				StartCoroutine(delayedGamePhase(2f));

			}
			else {
				Debug.Log("WRONG");
			    spaceShip.StopCoroutineCustom();

                //TODO explosion effect and cuoricino spezzato
                pointMgr.DecreasePoint();
				pointMgr.spaceShipWrong();
				spaceShip.earthObject.GetComponent<EarthEnergyHandler>().attack();
				
				StartCoroutine(delayedGamePhase(2f));
			}
		}
		else if(meaning.Equals(Meaning.NEUTRAL)) {
			if(lastMeaning.Equals(Meaning.NEUTRAL)) {
			    spaceShip.StopCoroutineCustom();
                Debug.Log("RIGHT");
				pointMgr.spaceShipRight(spaceShip.remainingTimePerc);
		
				//TODO neutral effect?
				StartCoroutine(delayedGamePhase(2f));

			}
			else {
				if(lastMeaning.Equals(Meaning.WAR) || lastMeaning.Equals(Meaning.PEACE)) {
					Debug.Log("NEW PHRASE");
					SymbolsEvents.ActivatePanel(PhraseEvents.GetPhrase(true).symbols);
				}
			}
		}
	}
}