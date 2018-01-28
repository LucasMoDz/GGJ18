using Package.EventManager;
using UnityEngine;

public class ManagerFooter : MonoBehaviour
{
	public GameManager gameManager;

	public void sendPeace() {
		gameManager.symbols.spawnParticles(Meaning.PEACE);
		gameManager.handleAnswer(Meaning.PEACE);
        EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.AcousticButton);
	}

	public void sendWar() {
		gameManager.symbols.spawnParticles(Meaning.WAR);
		gameManager.handleAnswer(Meaning.WAR);
	    EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.AcousticButton);
    }
    
    public void sendNeutral() {
        gameManager.symbols.spawnParticles(Meaning.NEUTRAL);
            gameManager.handleAnswer(Meaning.NEUTRAL);
        EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.AcousticButton);
    }
}