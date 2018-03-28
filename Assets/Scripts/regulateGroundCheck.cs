using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regulateGroundCheck : MonoBehaviour {
	public Transform player;
	public Transform groundCheck;

	// Use this for initialization
	void Start () {
		groundCheck = GetComponent<Transform> ();
		player = groundCheck.parent;
	}
	
	// Update is called once per frame
	void Update () {
		groundCheck.position = new Vector3 (player.position.x, player.position.y - (player.lossyScale.y / 2), 1);
	}
}
