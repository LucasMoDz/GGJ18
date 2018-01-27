using UnityEngine;

public static class AnswerEvents
{
	public delegate Meaning Answer();
	public static Answer GetAnswerMeaning;
}

public class ManagerFooter : MonoBehaviour


{
	public void sendPeace() {
		
	}

	public void sendWar() {
		
	}

	public void sendNeutral() {
		
	}
}