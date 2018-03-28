using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcupineMove : MonoBehaviour {
	public Rigidbody2D enemyRB;
	public bool sidetoside;
	public bool updown;
	public float moveSpeed;
	public int directionFacing;

	private bool collidedWithPlatform;

	// Use this for initialization
	void Start () {
		enemyRB = GetComponent<Rigidbody2D> ();
		collidedWithPlatform = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (sidetoside) {
			if (collidedWithPlatform) {
				directionFacing *= -1;
				collidedWithPlatform = false;

				Transform enemyT = GetComponent<Transform> ();
				enemyT.localScale = new Vector3 (-directionFacing*enemyT.localScale.x, enemyT.localScale.y, enemyT.localScale.z); 
			}
			enemyRB.velocity = new Vector2 (directionFacing * moveSpeed, enemyRB.velocity.y);
		}

		if (updown) {
			if (collidedWithPlatform) {
				directionFacing *= -1;
//				enemyRB.AddForce(new Vector2(0, directionFacing*moveSpeed));
				collidedWithPlatform = false;

				// Flip the face of the porcupine
				Transform enemyT = GetComponent<Transform>();
				enemyT.localScale = new Vector3 (enemyT.localScale.x, -directionFacing*enemyT.localScale.y, enemyT.localScale.z); 
			}
			enemyRB.velocity = new Vector2 (enemyRB.velocity.x, directionFacing*moveSpeed); 
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Need to fix this when actually implement the 'EndOfPlatform' Transforms to prevent porcupines from moving out of range
		if (other.tag == "EndOfPlatform" || other.tag == "Platform" || other.tag == "Ground" || other.tag == "Cannon" || other.tag == "Porcupine") {
			collidedWithPlatform = true;	
		} else if (other.tag == "Player") {
			Rigidbody2D playerRB = other.GetComponent<Rigidbody2D> ();
			if (sidetoside) {
//				if (Mathf.Sign (playerRB.velocity.x) != Mathf.Sign (enemyRB.velocity.x)) {
					collidedWithPlatform = true;
//				}
			}

			if (updown) {
				if (Mathf.Sign (playerRB.velocity.y) != Mathf.Sign (enemyRB.velocity.y)) {
					collidedWithPlatform = true;
				}
			}
		}
	}
}
