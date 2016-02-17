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

        //Debug.Log(gamePad.Button.X == ButtonState.Released);
        if (gamePad.ButtonPress.A == ButtonPressState.Pressed)
        {
            Debug.Log("A Pressed");
        }
        if (gamePad.ButtonPress.A == ButtonPressState.Released)
        {
            Debug.Log("A Released");
        }
	}
}
