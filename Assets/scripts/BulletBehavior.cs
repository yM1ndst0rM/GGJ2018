using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		InitializeRigidBody();
		InitiateVelocity();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.name.Contains("Player") && !gameObject.name.Contains(collider.gameObject.tag)) {
			Hit(collider.gameObject);
			Destroy(gameObject);
		}
	}

	void Hit(GameObject target) {
		// todo: logic on the hit object
	}

	void InitializeRigidBody() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void InitiateVelocity() {
 		rigidBody.velocity = this.transform.rotation * Vector3.up * bulletSpeed;
	}

}
