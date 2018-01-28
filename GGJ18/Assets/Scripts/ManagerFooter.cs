using UnityEngine;

public class ManagerFooter : MonoBehaviour
{
	public GameManager gameManager;

	public void sendPeace() {
		//gameManager.symbols.spawnParticles(Meaning.PEACE);
		gameManager.handleAnswer(Meaning.PEACE);
	}

	public void sendWar() {
		//gameManager.symbols.spawnParticles(Meaning.WAR);
		gameManager.handleAnswer(Meaning.WAR);
	}

	public void sendNeutral() {
		//gameManager.symbols.spawnParticles(Meaning.NEUTRAL);
		gameManager.handleAnswer(Meaning.NEUTRAL);
	}
}