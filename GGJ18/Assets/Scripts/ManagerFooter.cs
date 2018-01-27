using UnityEngine;

public class ManagerFooter : MonoBehaviour
{
	public GameManager gameManager;

	public void sendPeace() {
		gameManager.handleAnswer(Meaning.PEACE);
	}

	public void sendWar() {
		gameManager.handleAnswer(Meaning.WAR);
	}

	public void sendNeutral() {
		gameManager.handleAnswer(Meaning.NEUTRAL);
	}
}