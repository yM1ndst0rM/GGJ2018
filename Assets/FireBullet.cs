using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform hostTransform;

	// Use this for initialization
	void Start () {
		FireABullet();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FireABullet() {
		var bullet = (GameObject)Instantiate (
		    bulletPrefab,
		    hostTransform.position,
		    hostTransform.rotation);
	}

}
