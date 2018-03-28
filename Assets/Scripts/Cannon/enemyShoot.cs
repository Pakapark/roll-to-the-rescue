using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {
	private Controls player;

	private Transform enemyT;
	private Transform shootingHole;

	public float shotSpeed;
	public Rigidbody2D cannonball;

	private float timeBetweenShots;
	private float timeStamp;

	// Use this for initialization
	void Start () {
		shootingHole = GetComponent<Transform> ();
		enemyT = shootingHole.parent;
		player = FindObjectOfType<Controls> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeBetweenShots = Random.Range (2f, 4f);
		Vector3 directionVector = shootingHole.position - enemyT.position;
		if (Time.time >= timeStamp) {
			// Instantiate Shot
			Rigidbody2D shotInstance = Instantiate(cannonball, shootingHole.position, shootingHole.rotation);
			Vector2 direction = new Vector2 (directionVector.x, directionVector.y);
			shotInstance.AddForce (direction * shotSpeed);
			timeStamp = Time.time + timeBetweenShots;
			timeBetweenShots = Random.Range(2.5f, 5.0f);
		}
	}
}
