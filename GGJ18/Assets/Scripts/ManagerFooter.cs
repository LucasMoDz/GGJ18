using Package.EventManager;
using UnityEngine;

public class ManagerFooter : MonoBehaviour
{
	public GameManager gameManager;

	public void sendPeace() {
		gameManager.handleAnswer(Meaning.PEACE);
        EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.AcousticButton);
	}

	public void sendWar() {
		gameManager.handleAnswer(Meaning.WAR);
	    EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.AcousticButton);
    }

    public void sendNeutral() {
		gameManager.handleAnswer(Meaning.NEUTRAL);
        EventManager.Invoke(SoundManagerTopics.PlayEffect, AudioClipName.AcousticButton);
    }
}