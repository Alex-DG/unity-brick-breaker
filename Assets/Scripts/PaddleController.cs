using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	public float speed;
	public float direction; // Paddle direction : 1 going up, -1 going down, 0 going anywhere
	public float adjustSpeed;

	public Transform rightLimit;
	public Transform leftLimit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// Paddle Movement
		if (Input.GetKey (KeyCode.D)) {
			// Up
			transform.position = new Vector3 (
				transform.position.x + (speed * Time.deltaTime), 
				transform.position.y,
				transform.position.z);
			
			direction = 1;
		} else if (Input.GetKey (KeyCode.A)) {
			// Down
			transform.position = new Vector3 (
				transform.position.x - (speed * Time.deltaTime), 
				transform.position.y,
				transform.position.z);
			
			direction = -1;
		} else {
			direction = 0;
		}
	
		// Check the limit position of the paddle
		if (transform.position.x > rightLimit.position.x) {
			// Right limit
			transform.position = new Vector3 (rightLimit.position.x, transform.position.y, transform.position.z);
		} else if (transform.position.x < leftLimit.position.x) {
			// Left limit
			transform.position = new Vector3 (leftLimit.position.x, transform.position.y, transform.position.z);
		}
			
	}
		 
	// Ball no longer touching a paddle
	// Used to make the ball speed up and add some velocity when the direction of the ball changes
	// it adds some difficulty to the game
	// x velocity will be faster and faster after the end of collision by * 1.1f
	void OnCollisionExit2D(Collision2D other) {
		other.rigidbody.velocity = new Vector2 (
			other.rigidbody.velocity.x + (direction * adjustSpeed), 
			other.rigidbody.velocity.y );
	}
}
