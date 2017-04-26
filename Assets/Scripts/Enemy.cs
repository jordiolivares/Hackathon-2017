using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int food;
	public int damage;
	protected Vector3 direction = new Vector3 (1, 0, 0);
	public float directionTimer = 2f;
	protected bool enableChange = true;

	// Use this for initialization
	public void Start () {
		InvokeRepeating ("maybeChangeDirection", directionTimer, directionTimer);
	}
	
	// Update is called once per frame
	public void Update () {
		transform.position += direction * Time.deltaTime;
	}

	void maybeChangeDirection() {
		if (enableChange && Random.value < 0.6) {
			changeDirection ();
			Debug.Log ("Change Direction");
		}
	}
		
	void changeDirection() {
		direction = -direction;
		transform.RotateAround (transform.position, new Vector3 (0, 1, 0), 180);
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Platform Sides")) {
			changeDirection ();
		}
	}
}
