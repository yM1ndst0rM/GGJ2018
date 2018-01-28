using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrailManager : MonoBehaviour
{

    public Transform SourceObjectPosition;

    public void OnReleaseDust()
    {
        var myTransform = GetComponent<Transform>();
        myTransform.position = new Vector3(SourceObjectPosition.position.x, SourceObjectPosition.position.y, myTransform.position.z);

        GetComponent<Animator>().SetTrigger("Release Dust");
    }
}
