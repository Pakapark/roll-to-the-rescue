using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massGainerBird : MonoBehaviour {
	private Transform birdT;
	public Rigidbody2D birdRB;
	public float movespeed;

//	private bool gotShotByPlayer;
	private bool hitWall;
	public Rigidbody2D plus;

	// Use this for initialization
	void Start () {
		birdT = GetComponent<Transform> ();
		birdRB = GetComponent<Rigidbody2D> ();
//		gotShotByPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
//		if (gotShotByPlayer) {
//			Instantiate (plus, birdT.position, birdT.rotation);
//			Destroy (gameObject);
//		}

		// keep the velocity the same for the bird
		birdRB.velocity = new Vector2(movespeed, birdRB.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player Shot") {
//			gotShotByPlayer = true;
			Instantiate (plus, birdT.position, birdT.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Ground") {
			Destroy (gameObject);
		}
	}
}
