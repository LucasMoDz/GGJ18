using UnityEngine;
using System.Collections;
using Package.CustomLibrary;

public static class GameManagerTopics
{
    public static MeaningEvent GetLastMeaning;
    public delegate Meaning MeaningEvent();

    public static RaceEvent GetLastRace;
    public delegate int RaceEvent();
}

public class GameManager : MonoBehaviour
{
    public float timeToReachEarth = 20f;

    private Meaning lastMeaning;
    private int lastRace;

    private void Awake()
    {
        GameManagerTopics.GetLastMeaning += ()=> lastMeaning;
        GameManagerTopics.GetLastRace += ()=> lastRace;
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
}