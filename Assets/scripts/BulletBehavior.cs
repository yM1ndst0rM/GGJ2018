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
		if (HitsMountain(collider.gameObject.tag) || HitsPlayer(collider.gameObject.tag)) {
			Hit(collider.gameObject);
			Destroy(gameObject);
		}
	}

	private bool HitsMountain(string tag) {
		return tag == "Mountain";
	}

	private bool HitsPlayer(string tag) {
		return tag.Contains("Player") && !gameObject.name.Contains(tag);
	}

	void Hit(GameObject target) {
        PlayerHealth ph = target.GetComponent<PlayerHealth>();
        if (!ph) return;

        ph.DamagePlayer(1);
		// todo: logic on the hit object
	}

	void InitializeRigidBody() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void InitiateVelocity() {
 		rigidBody.velocity = this.transform.rotation * Vector3.up * bulletSpeed;
	}

}
