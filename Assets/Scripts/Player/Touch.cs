using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {
	private Controls player;
	private Shoot shootingHole;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Controls> ();
		shootingHole = FindObjectOfType<Shoot> ();
	}
	
	public void LeftArrow() {
		player.moveleft = true;
		player.moveright = false;
	}

	public void ReleaseLeftArrow() {
		player.moveleft = false;
	}

	public void RightArrow() {
		player.moveleft = false;
		player.moveright = true;
	}

	public void ReleaseRightArrow() {
		player.moveright = false;
	}

	public void Jump() {
		player.jump = true;
	}

	public void Shoot() {
		shootingHole.shoot = true;
	}
}
