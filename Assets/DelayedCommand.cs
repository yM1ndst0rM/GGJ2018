using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.Build.AssetBundle;
using UnityEngine;
using UnityEngine.Events;

public class DelayedCommand : MonoBehaviour
{
    [System.Serializable]
    public class CommandEvent : UnityEvent<Command>
    {
    }
    public CommandEvent CommandEmmitter;
    public int InputCommandDelay;

    public enum Command
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ATTACK
    }

    private struct InputEvent
    {
        public float Timestamp { get; set; }
        public Command Type { get; set; }
    }

    private List<InputEvent> _inputs;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    var now = Time.time;
	    if (Input.GetKey(KeyCode.W))
	    {
	        _inputs.Add(new InputEvent{Timestamp = now + InputCommandDelay, Type = Command.UP});
	    }

	    if (Input.GetKey(KeyCode.A))
	    {
	        _inputs.Add(new InputEvent { Timestamp = now + InputCommandDelay, Type = Command.LEFT });
	    }

	    if (Input.GetKey(KeyCode.S))
	    {
	        _inputs.Add(new InputEvent { Timestamp = now + InputCommandDelay, Type = Command.DOWN });
	    }

	    if (Input.GetKey(KeyCode.D))
	    {
	        _inputs.Add(new InputEvent { Timestamp = now + InputCommandDelay, Type = Command.RIGHT });
	    }

	    if (Input.GetKey(KeyCode.Space))
	    {
	        _inputs.Add(new InputEvent { Timestamp = now + InputCommandDelay, Type = Command.ATTACK });
	    }

        foreach (var inputEvent in _inputs.Where(e => e.Timestamp < now))
        {
            CommandEmmitter.Invoke(inputEvent.Type);
        }
    }
}