using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotDestruction : MonoBehaviour {
	private bool offScreen;
//	private bool encounterEnemy;
//	private bool encounterIndestructibleObject;

	// Use this for initialization
	void Start () {
		offScreen = false;
//		encounterEnemy = false;
//		encounterIndestructibleObject = false;
	}

	// Update is called once per frame
//	void Update () {
//		if (offScreen || encounterEnemy || encounterIndestructibleObject) {
//			Destroy (gameObject);
//		}
//	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Porcupine" || other.tag == "Bird" || other.tag == "Cannon") {
//			encounterEnemy = true;
			if (other.tag == "Cannon") {
				Transform cannon = other.gameObject.GetComponent<Transform> ();
				cannon = cannon.parent;
				int numChild = cannon.childCount;
				for (var i = numChild - 1; i >= 0; i--) {
					Destroy (cannon.GetChild (i).gameObject);
				}
			} else if (other.tag != "Bird") {
				Destroy (other.gameObject);	
			}
			Destroy (gameObject);
		}

		if (other.tag == "Ground" || other.tag == "Platform" || other.tag == "Spikes") {
			Destroy (gameObject);
		}
	}
}
