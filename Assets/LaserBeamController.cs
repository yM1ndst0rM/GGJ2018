using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserBeamController : MonoBehaviour
{
    public Transform SourceObjectTransform;

    public GameObject LaserBeam;
    public GameObject ImpactEffect;

    private bool IsFollowing { get; set; } = true;
    public bool IsLockedOut { get; private set; } = false;

	// Update is called once per frame
	void Update () {
	    if (IsFollowing)
	    {
            transform.position = new Vector3(SourceObjectTransform.position.x, SourceObjectTransform.position.y, transform.position.z);
	        transform.up = SourceObjectTransform.up;
	    }
	}

    public void Shoot()
    {
        IsLockedOut = true;
        GetComponent<Animator>().SetTrigger("Charge Laser");
    }

    public void OnLaserCharged()
    {
        IsFollowing = false;
        var hit = Physics2D.Raycast(transform.position, transform.up, float.PositiveInfinity, ~LayerMask.NameToLayer("Ignored By Weapons"));
        if (hit)
        {
            var impactedByLaserHit = hit.collider.GetComponent<IImpactedByLaserHit>();
            if (impactedByLaserHit != null)
            {
                impactedByLaserHit.OnLaserImpact(SourceObjectTransform.gameObject);
            }

            LaserBeam.transform.localScale.Set(hit.distance, LaserBeam.transform.localScale.y,
                LaserBeam.transform.localScale.z);

            ImpactEffect.transform.position = hit.point;

            GetComponent<Animator>().SetTrigger("Impact on Object");
        }
        else
        {
            //assuming 3000 length is enough
            LaserBeam.transform.localScale.Set(3000, LaserBeam.transform.localScale.y,
                LaserBeam.transform.localScale.z);
        }

        GetComponent<Animator>().SetTrigger("Fire Laser");
    }

    public void OnLaserFired()
    {
        LaserBeam.transform.localScale.Set(0, LaserBeam.transform.localScale.y,
            LaserBeam.transform.localScale.z);
        IsFollowing = true;
        IsLockedOut = false;
    }
}
