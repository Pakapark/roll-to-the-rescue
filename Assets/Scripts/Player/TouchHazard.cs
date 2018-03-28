using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchHazard : MonoBehaviour {
	private Controls player;
	private Transform hazard;
	public float damage;
	public float deathThresholdRadius;
	public float impulse;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Controls> ();
		hazard = GetComponent<Transform> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			// Reduce the player's mass by 'damage' amount
			Transform playerT = player.GetComponent<Transform>();
			Rigidbody2D playerRB = player.GetComponent<Rigidbody2D> ();
			float currentMass = Mathf.PI * Mathf.Pow((playerT.lossyScale.x), 2);
			float newMass = currentMass - damage;
			float newRadius = Mathf.Sqrt (newMass / Mathf.PI);

			// Check if the player died
			if (newRadius < deathThresholdRadius) {
				SceneManager.LoadScene ("Game-Over");
			} else {
				playerT.localScale = new Vector3 (newRadius, newRadius, 1);
			}

			// Move the player in the direction away from the spike
			Vector3 directionVector = playerT.position - hazard.position;
			directionVector = directionVector / directionVector.magnitude;
			playerRB.velocity = -playerRB.velocity;
			playerRB.angularVelocity = -playerRB.angularVelocity;
			playerRB.AddForce (impulse * directionVector, ForceMode2D.Force);
//			float onGround = 1.0f;
//			if (Mathf.Abs (playerRB.velocity.y) < 1.0f) {
//				onGround = 0.0f;
//			}
//
//			playerRB.AddForce (new Vector2 (1500 * directionVector.x, 1500 * directionVector.y * onGround));
		}
	}
}
