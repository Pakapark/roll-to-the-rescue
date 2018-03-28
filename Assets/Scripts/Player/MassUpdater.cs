using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MassUpdater : MonoBehaviour {
	private Controls player;
	public float amountUpdate;
	public float deathThresholdRadius;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Controls> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			// First destroy the gameObject
			Destroy(gameObject);

			// Update Player's mass (will increase if massgainer, decrease if acid snow)
			Transform playerT = player.GetComponent<Transform> ();
			float currentMass = Mathf.PI * Mathf.Pow((playerT.lossyScale.x), 2);
			float newMass = currentMass + amountUpdate;
			float newRadius = Mathf.Sqrt (newMass / Mathf.PI);

			// Check if dead
			if (newRadius < deathThresholdRadius) {
				SceneManager.LoadScene ("Game-Over");
			} else {
				// update Player's mass here
				playerT.localScale = new Vector3 (newRadius, newRadius, 1);
			}
		}

		if (other.tag == "Ground") {
			Destroy (gameObject);
		}
	}
}
