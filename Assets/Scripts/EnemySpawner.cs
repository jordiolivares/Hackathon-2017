using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 5f;            // How long between each spawn.
	private Transform spawnPoint;         // An array of the spawn points this enemy can spawn from.
	private GameController gameController;

	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		spawnPoint = GetComponent<Transform> ();
		gameController = GameObject.Find ("Game Controller").GetComponent<GameController> ();
	}


	void Spawn ()
	{
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		if (gameController.canSpawnEnemy ()) {
			Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
			gameController.enemySpawned ();
		}
	}
}
