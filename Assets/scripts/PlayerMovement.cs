using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;

    public float TRANSLATE_SPEED = 10;

    private Vector2 inputVector;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {

        inputVector.Normalize();
        rb.velocity = inputVector * TRANSLATE_SPEED;
        if (inputVector.magnitude > 0)
        {
            transform.up = Vector3.Lerp(transform.up, inputVector, Time.deltaTime * 15);
        }

        inputVector.Set(0, 0);
    }

    public void Move(Vector2 direction)
    {
        inputVector = direction;
    }
}
