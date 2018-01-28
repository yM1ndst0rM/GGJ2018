using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEditor.Experimental.Build.AssetBundle;
using UnityEngine;
using UnityEngine.Events;

public class DelayedCommand : MonoBehaviour
{
    [System.Serializable]
    public class DirectionalCommandEvent : UnityEvent<Vector2>
    {
    }

    [System.Serializable]
    public class AttackCommandEvent : UnityEvent<int>
    {
    }

    public PlayerControlSchema.Player Player;
    public DirectionalCommandEvent MovementEmitter;
    public DirectionalCommandEvent AimEmitter;
    public AttackCommandEvent AttackEmitter;
    public float InputCommandDelay;
    public float FireTriggerThreshold;


    public interface IInputEvent
    {
        float Timestamp { get; }
        CommandType CommandType { get; }
    }

    public struct DirectionalInputEvent : IInputEvent
    {
        public float Timestamp { get; set; }
        public CommandType CommandType { get; set; }
        public Vector2 Param { get; set; }
    }

    public struct IntInputEvent : IInputEvent
    {
        public float Timestamp { get; set; }
        public CommandType CommandType { get; set; }
        public int Param { get; set; }
    }

    public enum CommandType
    {
        MOVE,
        AIM,
        ATTACK
    }


    private readonly List<IInputEvent> _inputs = new List<IInputEvent>();

    void Start()
    {
        switch (Player)
        {
            case PlayerControlSchema.Player.P1:
                GetComponent<Animator>().SetInteger("Player Number", 1);
                break;
            case PlayerControlSchema.Player.P2:
                GetComponent<Animator>().SetInteger("Player Number", 2);

                break;
            case PlayerControlSchema.Player.P3:
                GetComponent<Animator>().SetInteger("Player Number", 3);

                break;
            case PlayerControlSchema.Player.P4:
                GetComponent<Animator>().SetInteger("Player Number", 4);

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

	// Update is called once per frame
	void Update () {
	    var now = Time.time;
	    var inp = PlayerControlSchema.Inp(Player);

	    var horizontal = Input.GetAxis(inp.Move_HorizontalAxis);
	    var vertical = Input.GetAxis(inp.Move_VerticalAxis);
	    var aimHorizontal = Input.GetAxis(inp.Aim_HorizontalAxis);
        var aimVertical = Input.GetAxis(inp.Aim_VerticalAxis);

	    var moveVec2 = new Vector2(horizontal, vertical);
	    var aimVec2 = new Vector2(aimHorizontal, aimVertical);

	    if (moveVec2.magnitude > 0)
	    {
	        _inputs.Add(new DirectionalInputEvent{CommandType = CommandType.MOVE, Timestamp = now + InputCommandDelay, Param = moveVec2});
	    }

	    if (aimVec2.magnitude > 0)
	    {
	        _inputs.Add(new DirectionalInputEvent { CommandType = CommandType.AIM, Timestamp = now + InputCommandDelay, Param = aimVec2 });
	    }

        if (Input.GetAxis(inp.Fire1_Button) > FireTriggerThreshold)
	    {
	        _inputs.Add(new IntInputEvent { CommandType = CommandType.ATTACK, Timestamp = now + InputCommandDelay, Param = 1 });
	    }

        foreach (var inputEvent in _inputs.Where(e => e.Timestamp < now))
        {
            var directionalInputEvent = inputEvent is DirectionalInputEvent ? (DirectionalInputEvent?) inputEvent: (DirectionalInputEvent?) null;
            if (directionalInputEvent.HasValue)
            {
                if (directionalInputEvent.Value.CommandType == CommandType.MOVE)
                {
                    MovementEmitter.Invoke(directionalInputEvent.Value.Param);
                }else if (directionalInputEvent.Value.CommandType == CommandType.AIM)
                {
                    AimEmitter.Invoke(directionalInputEvent.Value.Param);
                }
            }

            var intInputEvent = inputEvent is IntInputEvent ? (IntInputEvent?)inputEvent :(IntInputEvent?) null;
            if (intInputEvent?.CommandType == CommandType.ATTACK)
            {
                AttackEmitter.Invoke(intInputEvent.Value.Param);
            }
        }
	    _inputs.RemoveAll(e => e.Timestamp < now);
	}


}