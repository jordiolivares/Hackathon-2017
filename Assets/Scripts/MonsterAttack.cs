using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour {

	public PlayerController myPlayerController;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log ("ola k ase");
		if (other.gameObject.tag == "Enemy") {
			//Debug.Log ("nomnom");
			myPlayerController.pointsGained(other.gameObject.GetComponent<Enemy> ().food);
			Destroy (other.gameObject);
		}
	}
}