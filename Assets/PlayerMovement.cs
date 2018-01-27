using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;

    private float TRANSLATE_SPEED = 10;

    private Vector2 inputVector;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {

        rb.velocity = inputVector * TRANSLATE_SPEED;

        inputVector.Set(0, 0);
    }

    public void PerformCommand(DelayedCommand.Command c)
    {
        switch (c)
        {
            case DelayedCommand.Command.UP:
                inputVector.y += 1;
                break;
            case DelayedCommand.Command.DOWN:
                inputVector.y += -1;
                break;
            case DelayedCommand.Command.LEFT:
                inputVector.x += -1;
                break;
            case DelayedCommand.Command.RIGHT:
                inputVector.x += 1;
                break;
            case DelayedCommand.Command.ATTACK:
                //empty
                break;
            default:
                throw new ArgumentOutOfRangeException("c", c, null);
        }
    }
}
