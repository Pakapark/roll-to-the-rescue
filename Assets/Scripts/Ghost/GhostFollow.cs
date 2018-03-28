using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostFollow : MonoBehaviour {
	private Controls player;
	public Rigidbody2D ghostRB;
	public float damage;
	public float deathThresholdRadius;
	public float startTime;
	public float ghostSpeed;
	public bool isDisappear; // Give the condition if ghost disappear
	public float disappearTime; // How long the ghost disappear

	private bool collisionWithPlayer;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Controls> ();
		ghostRB = GetComponent<Rigidbody2D> ();
		collisionWithPlayer = false;
		startTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Transform playerT = player.GetComponent<Transform>();
		Transform ghostT = ghostRB.GetComponent<Transform>();

		if (isDisappear && Time.time > disappearTime) {
			Destroy (ghostRB.gameObject);
		} else if (collisionWithPlayer) {
			// Eat the player
			float currentMass = Mathf.PI * Mathf.Pow ((playerT.lossyScale.x), 2);
			float newMass = currentMass - damage;
			float newRadius = Mathf.Sqrt (newMass / Mathf.PI);

			// Check if the player died
			if (newRadius < deathThresholdRadius) {
				SceneManager.LoadScene ("Game-Over");
			} else {
				playerT.localScale = new Vector3 (newRadius, newRadius, 1);
			}

			// Bounce Ghost back a bit
			ghostRB.AddForce (new Vector2 (-4000 * Mathf.Sign(ghostRB.velocity.x), -2000 * Mathf.Sign(ghostRB.velocity.y)));
			collisionWithPlayer = false;

		} else {
			
			// Get the position of the player
			Vector3 playerPosition = playerT.position;

			// Get direction from ghost to player
			Vector3 directionVector = playerPosition - ghostT.position;
			directionVector = directionVector / directionVector.magnitude;
			Vector2 velocityUpdate = new Vector2 (ghostSpeed * directionVector.x, ghostSpeed * directionVector.y);	

			// Update the velocity of the Ghost to move towards the player
			if (ghostRB.velocity.x * directionVector.x >= 0 || ghostRB.velocity.y * directionVector.y >= 0) {
				ghostRB.velocity = velocityUpdate;

				if (ghostRB.velocity.x < 0) {
					// Change direction the ghost is facing
					ghostT.localScale = new Vector3 (-Mathf.Abs(ghostT.localScale.x), ghostT.localScale.y, ghostT.localScale.z);
				} else {
					ghostT.localScale = new Vector3 (Mathf.Abs(ghostT.localScale.x), ghostT.localScale.y, ghostT.localScale.z);
				}
			} else {
				Vector2 velocityDirection = 5*ghostRB.velocity / ghostRB.velocity.magnitude;
				ghostRB.velocity -= velocityDirection;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			collisionWithPlayer = true;
		}
	}
}
