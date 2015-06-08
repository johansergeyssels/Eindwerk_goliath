using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	private RectTransform rect;
	public static Menu current;

	void Awake () {
		rect = GetComponent<RectTransform>();
		current = this;
	}
	
	void Update () {
		if(Input.GetButtonUp("Cancel")) {
			Pause();
		}
	}
	
	public void Pause() {
		rect.position = new Vector3(0, rect.rect.height, 0);
		Time.timeScale = 0;
	}
	
	public void LoadLevel(string name) {
		Application.LoadLevel(name);
		Time.timeScale = 1;
	}
	
	public void QuitGame() {
		Application.Quit();
	}
	
	public void RestartLevel() {
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1;
	}
	
	public void Continue() {
		rect.position = new Vector3(0, 0, 0);
		Time.timeScale = 1;
	}
}
