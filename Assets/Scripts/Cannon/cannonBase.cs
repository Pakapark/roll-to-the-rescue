using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBase : MonoBehaviour {
	public Transform cannonBarrel;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (cannonBarrel.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
	}
}
