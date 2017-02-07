using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float maxHorizontalSpeed;
	public float vertSeepd; // how fast the ball will starts moving in vertical direction

	private Rigidbody2D theRB;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
		theRB.velocity = new Vector2 (vertSeepd, maxHorizontalSpeed);
	}
	
	// Update is called once per frame
	void Update () {

		if (theRB.velocity.x > maxHorizontalSpeed) {
			theRB.velocity = new Vector2 (maxHorizontalSpeed, theRB.velocity.y);
		} else if (theRB.velocity.x < -maxHorizontalSpeed) {
			theRB.velocity = new Vector2 (-maxHorizontalSpeed, theRB.velocity.y);
		}

		Debug.Log (theRB.velocity);
	}
}
