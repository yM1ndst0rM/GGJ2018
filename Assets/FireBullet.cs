using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
		Fire();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Fire() {
		var bullet = (GameObject)Instantiate (
		    bulletPrefab,
		    bulletSpawn.position,
		    bulletSpawn.rotation);

	    // Adding velocity
	    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6; // todo: link this to the player's rotation
	}

}
