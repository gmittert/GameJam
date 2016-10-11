using UnityEngine;
using System.Collections;
using ControlWrapping;

public class PlayerController : MonoBehaviour {
    GamePadWrapper gamePad;
	

	void Start () {
        gamePad = new GamePadWrapper();
	}
	
    public void UpdateGamePadState(int playerIndex)
    {
        gamePad.CurrentState = GameManager.GetGamePadState(playerIndex);
    }

    public ButtonPressState ShootEvent()
    {
        if (gamePad.ButtonPress.RightTrigger != ButtonPressState.Constant)
        {
            return gamePad.ButtonPress.RightTrigger;
        }
        else
        {
            return gamePad.ButtonPress.LeftTrigger;
        }
    }

    public XInputDotNetPure.GamePadThumbSticks.StickValue MovementValues()
    {
        return gamePad.Stick.Left;
    }

    public XInputDotNetPure.GamePadThumbSticks.StickValue AimValues()
    {
        if (gamePad.Stick.Right.X != 0 || gamePad.Stick.Right.Y != 0)
        {
            return gamePad.Stick.Right;
        }
        else
        {
            return gamePad.Stick.Left;
        }
    }
}
