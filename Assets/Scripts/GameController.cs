using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public PlayerController myPlayerController;
	private Vector3 playerStartPoint;
	public GameOverMenu myGameOverMenu;
	public GameOverMenu myWinMenu;

	public int maxNumEnemies = 10;
	private int currentEnemies = 0;
	// Use this for initialization
	void Start () {
		playerStartPoint = myPlayerController.transform.position;
		Physics2D.IgnoreLayerCollision (30, 31);
		Physics2D.IgnoreLayerCollision (28, 31);
		Physics2D.IgnoreLayerCollision (31, 31);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool canSpawnEnemy() {
		return currentEnemies < maxNumEnemies;
	}

	public void enemySpawned() {
		currentEnemies++;
	}

	public void GameRestart(){
		myPlayerController.gameObject.SetActive (false);
		myGameOverMenu.gameObject.SetActive (true);
	}

	public void Reset(){
		//myGameOverMenu.gameObject.SetActive (false);
		myPlayerController.transform.position = playerStartPoint;
		myPlayerController.gameObject.SetActive (true);
	}

	public void GameWin(){
		myPlayerController.gameObject.SetActive (false);
		myWinMenu.gameObject.SetActive (true);
	}
}
