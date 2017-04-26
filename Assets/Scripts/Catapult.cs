using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : Enemy {

	public Rock projectile;
	private GameObject player;
	public float fireRate = 3f;
	public float speedProjectile = 3f;

	private bool inRange;

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
		if (inRange) {
			Debug.Log ("Instantiated rock");
			float angle = angleOfLaunch (player.transform.position);
			Vector3 direction = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0) * speedProjectile;
			var rock = Instantiate (projectile, transform.position, transform.rotation);
			rock.GetComponent<Rigidbody2D> ().velocity = new Vector2(direction.x, direction.y);
			Debug.Log (direction);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			inRange = true;
			Debug.Log ("Aids");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player")
			inRange = false;
	}

	float angleOfLaunch(Vector3 target) {
		float v = speedProjectile;
		float g = Physics2D.gravity.y;
		float x = transform.position.x - target.x + 0.05f, y = transform.position.y - target.y + 0.05f;
		Debug.Log (x);
		return Mathf.Atan ((v * v + Mathf.Sqrt (v * v * v * v - g * (g * x * x + 2 * y * v * v))) / (g * x));
	}
}
