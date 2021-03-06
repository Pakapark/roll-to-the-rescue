﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject PauseUI;

	private bool paused = false;

	// Use this for initialization
	void Start () {
		PauseUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		} else {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void pauseGame() {
		paused = !paused;

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		} else {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void resumeGame() {
		paused = false;
	}

	public void mainMenu() {
		SceneManager.LoadScene ("Main-Menu");
	}
}
