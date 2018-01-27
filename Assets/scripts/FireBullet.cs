using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public float firingRateInSeconds;
	
	private float lastShotAt;

	public void Fire(int type/*ignored*/) {
	    if (canFire())
	    {
	        FireABullet();
	    }
	}

	private void FireABullet() {
		var bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
		bullet.name = bullet.name + '#' + gameObject.tag;
		lastShotAt = Time.time;
	}

	private bool canFire() {
		return Time.time >= lastShotAt + firingRateInSeconds;
	}

}
