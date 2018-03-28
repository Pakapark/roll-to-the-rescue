using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manageHealthBar : MonoBehaviour {
	Text text;
	private Controls player;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		player = FindObjectOfType<Controls> ();
	}
	
	// Update is called once per frame
	void Update () {
		Transform playerT = player.GetComponent<Transform> ();
		float currentMass = Mathf.PI * Mathf.Pow((playerT.lossyScale.x), 2);
		text.text = "Health: " + (int)(currentMass - 51);
	}
}
