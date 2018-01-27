using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Vector2 AimVector { get; set; }
	
	// Update is called once per frame
	void Update ()
	{
	    if (AimVector.magnitude > 0)
	    {
	        GetComponent<Transform>().up = AimVector.normalized;
	    }
	}

    public void Aim(Vector2 aimDirection)
    {
        AimVector = aimDirection;
    }
}
