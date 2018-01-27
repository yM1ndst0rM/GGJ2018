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

	void InitializeRigidBody() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void InitiateVelocity() {
 		rigidBody.velocity = this.transform.rotation * Vector3.up * bulletSpeed;
	}

}
