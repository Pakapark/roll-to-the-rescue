using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massBirdSpawn : MonoBehaviour {
	public GameObject bird;
	public float spawnTime = 3f;
	public Transform spawnPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn () {
		// Find a random index between zero and one less than the number of spawn points
		int spawnPointIndex = Random.Range (0, spawnPoints.childCount);

		// Create an instance of the prefab at the randomly selected spawn point's position and rotation.
		Instantiate (bird, spawnPoints.GetChild(spawnPointIndex).position, spawnPoints.GetChild(spawnPointIndex).rotation);
	}
}
