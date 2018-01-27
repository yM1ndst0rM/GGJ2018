using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerControlSchema
{
    public enum Player
    {
        P1,
        P2,
        P3,
        P4
    }

    public static PlayerControlSchema Inp(Player player)
    {
        switch (player)
        {
            case Player.P1:
                return Player1;
            case Player.P2:
                return Player2;
            case Player.P3:
                return Player3;
            case Player.P4:
                return Player4;
            default:
                throw new ArgumentOutOfRangeException(nameof(player), player, null);
        }
    }

    public static readonly PlayerControlSchema Player1 = new PlayerControlSchema(1);
    public static readonly PlayerControlSchema Player2 = new PlayerControlSchema(2);
    public static readonly PlayerControlSchema Player3 = new PlayerControlSchema(3);
    public static readonly PlayerControlSchema Player4 = new PlayerControlSchema(4);


    public string Move_HorizontalAxis { get; private set; }
    public string Move_VerticalAxis { get; private set; }
    public string Aim_HorizontalAxis { get; private set; }
    public string Aim_VerticalAxis { get; private set; }
    public string Fire1_Button { get; private set; }
    public string Submit_Button { get; private set; }

    public PlayerControlSchema(int playerNum)
    {
        Move_HorizontalAxis = Move_HorizontalAxisName(playerNum);
        Move_VerticalAxis = Move_VerticalAxisName(playerNum);
        Aim_HorizontalAxis = Aim_HorizontalAxisName(playerNum);
        Aim_VerticalAxis = Aim_VerticalAxisName(playerNum);
        Fire1_Button = Fire1_ButtonName(playerNum);
        Submit_Button = Submit_ButtonName(playerNum);
    }


    private static string Move_HorizontalAxisName(int playerNumber)
    {
        return $"P{playerNumber}_Horizontal";
    }

    private static string Move_VerticalAxisName(int playerNumber)
    {
        return $"P{playerNumber}_Vertical";
    }

    private static string Aim_HorizontalAxisName(int playerNumber)
    {
        return $"P{playerNumber}_AimHorizontal";
    }

    private static string Aim_VerticalAxisName(int playerNumber)
    {
        return $"P{playerNumber}_AimVertical";
    }
    private static string Fire1_ButtonName(int playerNumber)
    {
        return $"P{playerNumber}_Fire1";
    }
    private static string Submit_ButtonName(int playerNumber)
    {
        return $"P{playerNumber}_Submit";
    }
}
