using UnityEngine;
using System.Collections.Generic;

namespace ControlWrapping
{
    public class Button
    {
        GamePadWrapper gamePadWrapper;

        public Button(GamePadWrapper gamePadWrapper)
        {
            this.gamePadWrapper = gamePadWrapper;
        }

        public ButtonState X
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.X == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState Y
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.Y == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState A
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.A == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState B
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.B == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState LeftBumper
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.LeftShoulder == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState RightBumper
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.RightShoulder == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState LeftStick
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.LeftStick == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState Start
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.Start == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState Select
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.Back == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState Guide
        {
            get
            {
                return gamePadWrapper.CurrentState.Buttons.Guide == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState LeftTrigger
        {
            get
            {
                if (gamePadWrapper.CurrentState.Triggers.Left > gamePadWrapper.TriggerSensitivity)
                {
                    return ButtonState.Pressed;
                }
                return ButtonState.Released;
            }
        }
        public ButtonState RightTrigger
        {
            get
            {
                if (gamePadWrapper.CurrentState.Triggers.Right > gamePadWrapper.TriggerSensitivity)
                {
                    return ButtonState.Pressed;
                }
                return ButtonState.Released;
            }
        }
        public ButtonState DPadUp
        {
            get
            {
                return gamePadWrapper.CurrentState.DPad.Up == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState DPadRight
        {
            get
            {
                return gamePadWrapper.CurrentState.DPad.Right == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState DPadDown
        {
            get
            {
                return gamePadWrapper.CurrentState.DPad.Down == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }
        public ButtonState DPadLeft
        {
            get
            {
                return gamePadWrapper.CurrentState.DPad.Left == XInputDotNetPure.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Released;
            }
        }

    }

    public enum ButtonState
    {
        Pressed,
        Released
    }

}