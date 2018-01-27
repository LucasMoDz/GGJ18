using UnityEngine;
using System.Collections;
using Package.CustomLibrary;

public static class GameManagerTopics
{
    public static GetRaceEvent GetRandomicMeaning;
    public delegate Meaning GetRaceEvent();
}

public class GameManager : MonoBehaviour
{
    public float timeToReachEarth = 20f;
    private Meaning lastMeaning;

    private void Awake()
    {
        GameManagerTopics.GetRandomicMeaning += () => lastMeaning;
    }
    
    private IEnumerator Start ()
    {
        // 3, 2, 1 feedback
        yield return StartFeedbackEvent.StartGame(); 

        // Randomize race
        RandomRace();

        // Set lastMeaning variable (that will be called by PhraseGenerator
        var meanings = UtilitiesGen.GetEnumValues<Meaning>();
        lastMeaning = meanings[Random.Range(0, meanings.Length)];

        // Get simbols
        Phrase phrase = PhraseEvents.GetPhrase();
        
        //Chiama metodo che avvia la generazione simboli

        //Chiama metodo per attivare gli slider

        //Fa partire il movimento della navicella
        SpaceshipEvents.moveToPosition(timeToReachEarth);
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
        
        SpaceshipEvents.setSprite(raceName);
    }
}