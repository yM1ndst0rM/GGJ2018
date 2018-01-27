using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public float firingRateInSeconds;
	
	private float lastShotAt;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PerformCommand(DelayedCommand.Command c) {
		if (canFire() && c == DelayedCommand.Command.ATTACK) {
			FireABullet();
		}
	}

	public void FireABullet() {
		Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
		lastShotAt = Time.time;
	}

	private bool canFire() {
		return Time.time >= lastShotAt + firingRateInSeconds;
	}

}
