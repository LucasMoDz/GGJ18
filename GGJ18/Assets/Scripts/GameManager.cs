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

    private void Awake()
    {
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

    private void GamePhase()
    {
        // Randomize race
        lastRace = Random.Range(0, 3);
        SpaceshipEvents.setSprite(lastRace);

        // Set lastMeaning variable (that will be called by PhraseGenerator)
        var meanings = UtilitiesGen.GetEnumValues<Meaning>();
        lastMeaning = meanings[Random.Range(0, meanings.Length-1)]; //only war and peace intention

        // Get symbols and generate symbols class
        SymbolsEvents.ActivatePanel(PhraseEvents.GetPhrase().symbols);

        // Activate slider
        SliderEvents.SliderActivation(true);

        // Move space ship
        SpaceshipEvents.moveToPosition(timeToReachEarth);
    }

	public void handleAnswer(Meaning meaning) {

		Debug.Log(meaning);

		if(meaning.Equals(Meaning.PEACE)) {
			if(lastMeaning.Equals(Meaning.PEACE)) {
				Debug.Log("RIGHT");
				pointMgr.spaceShipRight(spaceShip.remainingTimePerc);
			}
			else {
				Debug.Log("WRONG");
				pointMgr.spaceShipWrong();
			}
		}
	 	else if(meaning.Equals(Meaning.WAR)) {
			if(lastMeaning.Equals(Meaning.WAR)) {
				Debug.Log("RIGHT");
				pointMgr.spaceShipRight(spaceShip.remainingTimePerc);
			}
			else {
				Debug.Log("WRONG");
				pointMgr.spaceShipWrong();
			}
		}
		else if(meaning.Equals(Meaning.NEUTRAL)) {
			if(lastMeaning.Equals(Meaning.NEUTRAL)) {
				Debug.Log("RIGHT");
				pointMgr.spaceShipRight(spaceShip.remainingTimePerc);
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