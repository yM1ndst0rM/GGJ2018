using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InitiateVelocity();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitiateVelocity() {
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
	}
}
