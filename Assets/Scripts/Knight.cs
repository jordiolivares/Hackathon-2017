using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy {
	private PlayerController player;
	public float attackRadius = 6f;
	public float attackTime = 3f;
	private bool isAttacking = false;
	// Use this for initialization
	new void Start () {
		base.Start ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		Vector2 direction = new Vector2 (base.direction.x, base.direction.y);
		if (!isAttacking && Physics2D.Raycast(transform.position, direction, attackRadius, (1 << 30))) {
			Debug.Log ("Detected monster, charging");
			Invoke ("reenableChange", attackTime);
			base.direction *= 2f;
			base.enableChange = false;
			isAttacking = true;
		}
	}
	
	void reenableChange() {
		base.enableChange = true;
		base.direction /= 2f;
		isAttacking = false;
		Debug.Log ("Stopping charge");	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (isAttacking && other.gameObject.tag == "Player") {
			
		}
	}
}
