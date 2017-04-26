using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy {

	public Arrow projectile;
	private GameObject player;
	public float fireRate;
	// Use this for initialization
	new void Start () {
		base.Start ();
		player = GameObject.FindGameObjectWithTag ("Player");
		InvokeRepeating ("Shoot", fireRate, fireRate);
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();

	}

	void Shoot() {
		Arrow arrow = Instantiate (projectile, transform.position, transform.rotation) as Arrow;
		Vector2 playerPos = new Vector2 (player.transform.position.x, player.transform.position.y);
		Debug.Log (playerPos);
		arrow.direction = (playerPos - new Vector2(transform.position.x, transform.position.y));
		Debug.Log ("Firing Arrow");
	}
}
