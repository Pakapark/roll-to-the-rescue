using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public Transform shootingHole;
	public Transform player;
	public Rigidbody2D playerRB;

	public bool shoot;
	public float shotSpeed;
	public Rigidbody2D shot;
	public float thresholdRadius;
	public float recoilConstant;

	public float timeBetweenShots;
	private float timeStamp;

	// Use this for initialization
	void Start () {
		shootingHole = GetComponent<Transform> ();
		player = shootingHole.parent;
		playerRB = player.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time >= timeStamp) && Input.GetKey (KeyCode.S)) {
			// Instantiate Shot
			Rigidbody2D shotInstance = Instantiate(shot, shootingHole.position, shootingHole.rotation);
			Vector3 directionVector = shootingHole.position - player.position;
			Vector2 direction = new Vector2 (directionVector.x, directionVector.y);
			shotInstance.AddForce (direction * shotSpeed);

			// Reduce Player's Mass (unless already hit threshold)
			float shotMass = Mathf.PI*Mathf.Pow((shotInstance.GetComponent<Transform>().lossyScale.x), 2);
			float currentMass = Mathf.PI * Mathf.Pow((player.lossyScale.x), 2);
			float newMass = currentMass - shotMass;
			float newRadius = Mathf.Sqrt (newMass / Mathf.PI);
			if (newRadius >= thresholdRadius) {
				player.localScale = new Vector3 (newRadius, newRadius, 1);	
			} else {
				player.localScale = new Vector3 (thresholdRadius, thresholdRadius, 1);
			}

			// Update Player's velocity based on recoil from shooting
			playerRB.AddForce(new Vector2((-shotMass*direction.x)*recoilConstant/newMass, (-shotMass*direction.y)*recoilConstant/newMass));
			timeStamp = Time.time + timeBetweenShots;
		}

		if ((Time.time >= timeStamp) && shoot) {
			Rigidbody2D shotInstance = Instantiate(shot, shootingHole.position, shootingHole.rotation);
			Vector3 directionVector = shootingHole.position - player.position;
			Vector2 direction = new Vector2 (directionVector.x, directionVector.y);
			shotInstance.AddForce (direction * shotSpeed);

			float shotMass = Mathf.PI*Mathf.Pow((shotInstance.GetComponent<Transform>().lossyScale.x), 2);
			float currentMass = Mathf.PI * Mathf.Pow((player.lossyScale.x), 2);
			float newMass = currentMass - shotMass;
			float newRadius = Mathf.Sqrt (newMass / Mathf.PI);
			if (newRadius >= thresholdRadius) {
				player.localScale = new Vector3 (newRadius, newRadius, 1);	
			}

			playerRB.AddForce(new Vector2((-shotMass*direction.x)*recoilConstant/newMass, (-shotMass*direction.y)*recoilConstant/newMass));
			timeStamp = Time.time + timeBetweenShots;
			shoot = false;
		}
	}
}
