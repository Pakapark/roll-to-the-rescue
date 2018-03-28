using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCannonBarrel : MonoBehaviour {
	private Controls player;

	private Transform cannonBarrel;
	public Transform placeOfRotation; // Center of barrel base
	private Vector3 pointOfRotation; // Center of barrel base

	public float rotationDivider; // Larger Value, Smaller Update
	public float angleThreshold; // The angle difference that the barrel will update direction

	private Vector3 currentShootingDirection;
	private Vector3 playerDirection;
	private Transform playerT;
	private float angleChanged;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Controls> ();
		playerT = player.GetComponent<Transform>();
		cannonBarrel = GetComponent<Transform> ();
		pointOfRotation = placeOfRotation.position;
	}
	
	// Update is called once per frame
	void Update () {
		currentShootingDirection = cannonBarrel.position - pointOfRotation;
		playerDirection = playerT.position - pointOfRotation;

		// Compute if the angle is positive or negative
		int sign = Vector3.Cross(currentShootingDirection, playerDirection).z < 0 ? -1 : 1;
		angleChanged = Vector3.Angle (currentShootingDirection, playerDirection);

		// Update the angle if the different in angle is larger than 15
		if (angleChanged > angleThreshold) {
			cannonBarrel.RotateAround (pointOfRotation, new Vector3 (0, 0, 1), sign * angleChanged/rotationDivider );
		}
	}
}
