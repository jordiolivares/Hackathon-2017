using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy {

	public GameObject projectile;

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	void Shoot(Vector2 at) {
		var arrow = Instantiate (projectile, this.transform);
		arrow.GetComponent<Rigidbody2D> ().AddForce (at - new Vector2(transform.position.x, transform.position.y));
	}
}
