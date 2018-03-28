using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTouch : MonoBehaviour {
	public bool paused;

	// Use this for initialization
	void Start () {
		paused = false;
	}

	public void StartGame() {
		SceneManager.LoadScene ("Difficulty-Selection");
	}

	public void LoadControls() {
		SceneManager.LoadScene ("Controls-Scene");
	}

	public void Story() {
		SceneManager.LoadScene ("Story-Scene");
	}

	public void BackToMainMenu() {
		SceneManager.LoadScene ("Main-Menu");
	}

	public void quit() {
		Application.Quit();
	}

	public void goToEasyMode() {
		SceneManager.LoadScene ("Scenes/Easy-Mode/Level1-1");
	}

	public void goToMediumMode() {
		SceneManager.LoadScene ("Scenes/Medium-Mode/Level1-1");
	}

	public void goToHardMode() {
		SceneManager.LoadScene ("Scenes/Hard-Mode/Level1-1");
	}
}
