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
        Debug.Log(nameof(Shoot));
        if (!IsLockedOut)
        {
            IsLockedOut = true;
            GetComponent<Animator>().SetTrigger("Charge Laser");
        }
    }

    public void OnLaserCharged()
    {
        Debug.Log(nameof(OnLaserCharged));
        IsFollowing = false;
        var hit = Physics2D.Raycast(SourceObjectTransform.position, SourceObjectTransform.up, float.PositiveInfinity, ~(1 << LayerMask.NameToLayer("Ignored By Weapons")));
        if (hit)
        {
            var impactedByLaserHit = hit.collider.GetComponent<IImpactedByLaserHit>();
            if (impactedByLaserHit != null)
            {
                impactedByLaserHit.OnLaserImpact(SourceObjectTransform.gameObject);
            }

            upscaleLazer(hit.distance);

            ImpactEffect.transform.position = hit.point;

            GetComponent<Animator>().SetTrigger("Impact on Object");
        }
        else
        {
            //assuming 3000 length is enough
            upscaleLazer(3000);
        }

        GetComponent<Animator>().SetTrigger("Fire Laser");
    }

    public void OnLaserFired()
    {
        Debug.Log(nameof(OnLaserFired));
        downscaleLazer();
        IsFollowing = true;
        IsLockedOut = false;
    }

    public void upscaleLazer(float targetSize)
    {
       Vector3 rescale = LaserBeam.transform.localScale;
       rescale.x = targetSize;

       LaserBeam.transform.localScale = rescale;

    }

    public void downscaleLazer()
    {
        Vector3 rescale = LaserBeam.transform.localScale;

        rescale.x = 1;

        LaserBeam.transform.localScale = rescale;
    }
}
