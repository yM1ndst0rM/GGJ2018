using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D rb;

    private float ROTATION_SPEED = 80;
    private float TRANSLATE_SPEED = 4;

    private Vector2 forwardVector;
    private float inputForward = 0;
    private float inputRotation = 0;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {

        forwardVector.Set(transform.up.x, transform.up.y);
        rb.velocity = forwardVector * inputForward * TRANSLATE_SPEED;

        rb.angularVelocity = inputRotation * ROTATION_SPEED;

        inputRotation = 0;
        inputForward = 0;
    }

    public void PerformCommand(DelayedCommand.Command c)
    {
        switch (c)
        {
            case DelayedCommand.Command.UP:
                inputForward += 1;
                break;
            case DelayedCommand.Command.DOWN:
                inputForward -= 1;

                break;
            case DelayedCommand.Command.LEFT:
                inputRotation += 1;
                break;
            case DelayedCommand.Command.RIGHT:
                inputRotation -= 1;
                break;
            case DelayedCommand.Command.ATTACK:
                //empty
                break;
            default:
                throw new ArgumentOutOfRangeException("c", c, null);
        }
    }
}
