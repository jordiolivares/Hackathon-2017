using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public Vector2 direction;
	Rigidbody2D body;
	PlayerController player;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		transform.position += (new Vector3 (direction.x, direction.y, 0)) * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Platform") {
			projectileDespawn ();
			Debug.Log ("Suelo!");
		} else if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}

	void projectileDespawn() {
		body.velocity = Vector2.zero;
	}
}

