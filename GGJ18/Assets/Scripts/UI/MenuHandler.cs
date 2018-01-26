using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

	public Dictionary<string, GameObject> menus = new Dictionary<string, GameObject>();

	GameObject currMenu;

	void Start () {
		foreach (Transform child in transform) {
			menus.Add(child.name, child.gameObject);
			if(!child.name.Equals("MainMenu"))
				child.gameObject.SetActive(false);
		}
		currMenu = menus["MainMenu"];
		//currMenu.SetActive(true);

	}

	public void showMenu(string menuName) {
		currMenu.SetActive(false);
		currMenu = menus[menuName];
		currMenu.SetActive(true);
	}

	public void loadLevel(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
