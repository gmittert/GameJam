using UnityEngine;
using System.Collections;
using ControlWrapping;

public class Test : MonoBehaviour {
    GamePadWrapper gamePad;
	// Use this for initialization
	void Start () {
        gamePad = new GamePadWrapper();
	}
	
	// Update is called once per frame
	void Update () {
        gamePad.CurrentState = XInputDotNetPure.GamePad.GetState(XInputDotNetPure.PlayerIndex.One);
        Debug.Log(gamePad.Stick.Left.X+", " + gamePad.Stick.Left.Y);
    }
}
