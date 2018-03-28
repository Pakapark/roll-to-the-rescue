using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massKillerBird : MonoBehaviour {
	private Transform birdT;
	public Rigidbody2D birdRB;
	public float movespeed;
	public Rigidbody2D minus;
	public float direction;

	private bool gotShotByPlayer;
	private float timeBetweenBombs;
	private float timeStamp;

	public bool hasTimeLimit;
	private float timeLimit;
	public float limit;


	// Use this for initialization
	void Start () {
		Random.InitState (42);
		birdT = GetComponent<Transform> ();
		birdRB = GetComponent<Rigidbody2D> ();
		gotShotByPlayer = false;
		timeBetweenBombs = Random.Range(2.5f, 7.5f);
		if (hasTimeLimit) {
			timeLimit = Time.time + limit;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timeLimit) {
			Destroy (gameObject);
		}

		if (gotShotByPlayer) {
			Destroy (gameObject);
		}

		if (Time.time >= timeStamp) {
			Instantiate (minus, birdT.position, birdT.rotation);
			timeStamp = Time.time + timeBetweenBombs;
			timeBetweenBombs = Random.Range (2.5f, 7.5f);
		}

		// keep the velocity the same for the bird
		birdRB.velocity = new Vector2(direction*movespeed, birdRB.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player Shot") {
			gotShotByPlayer = true;
		}

		if (other.tag == "Ground") {
			Destroy (gameObject);
		}
	}
}
