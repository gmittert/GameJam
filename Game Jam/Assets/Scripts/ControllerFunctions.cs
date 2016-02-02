using UnityEngine;
using System.Collections.Generic;
using XInputDotNetPure;

public enum controlSticks
{
    leftStick,
    rightStick,
    dPad
}

public class ControllerFunctions {

    //// Use this for initialization
    //void Start () {
	
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}

    


    public static Vector2 getMovement(PlayerProfile player)
    {

        return new Vector2(0, 0);
    }
}
