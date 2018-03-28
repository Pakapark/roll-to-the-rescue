using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyShotDestruction : MonoBehaviour {
	private Controls player;

	private bool offScreen;
	private bool encounterPlayer;
	private bool encounterIndestructibleObject;

	public float deathThresholdRadius;
	public float damage;


	// Use this for initialization
	void Start () {
		offScreen = false;
		encounterPlayer = false;
		encounterIndestructibleObject = false;
		player = FindObjectOfType<Controls> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (offScreen || encounterPlayer || encounterIndestructibleObject) {
			Destroy (gameObject);

			if (encounterPlayer) {
				// Update the player's health
				Transform playerT = player.GetComponent<Transform> ();
				float currentMass = Mathf.PI * Mathf.Pow((playerT.lossyScale.x), 2);
				float newMass = currentMass - damage;
				float newRadius = Mathf.Sqrt (newMass / Mathf.PI);

				// Check if player is dead
				if (newRadius < deathThresholdRadius) {
					SceneManager.LoadScene ("Game-Over");
				} else {
					// update Player's mass here
					playerT.localScale = new Vector3 (newRadius, newRadius, 1);
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			encounterPlayer = true;
		}

		if (other.tag == "Ground" || other.tag == "Platform" || other.tag == "Spikes") {
			encounterIndestructibleObject = true;
		}
	}
}
