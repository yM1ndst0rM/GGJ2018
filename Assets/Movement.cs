using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D rb;

    private float ROTATION_SPEED = 80;
    private float TRANSLATE_SPEED = 4;

    private Vector2 forwardVector;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {

        float inputForward = 0;
        if (Input.GetKey(KeyCode.W)) {
            inputForward += 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputForward -= 1;
        }

        float inputRotation = 0;
        if (Input.GetKey(KeyCode.A)) {
            inputRotation += 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputRotation -= 1;
        }

        forwardVector.Set(transform.up.x, transform.up.y);
        rb.velocity = forwardVector * inputForward * TRANSLATE_SPEED;

        rb.angularVelocity = inputRotation * ROTATION_SPEED;
    }
}
