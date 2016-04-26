using UnityEngine;
using System.Collections.Generic;

namespace ControlWrapping
{
    public class ButtonPress
    {
        GamePadWrapper gamePadWrapper;

        public ButtonPress(GamePadWrapper gamePadWrapper)
        {
            this.gamePadWrapper = gamePadWrapper;
        }

        public ButtonPressState X
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.X == gamePadWrapper.OldState.Buttons.X)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.X == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
                
            }
        }
        public ButtonPressState Y
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.Y == gamePadWrapper.OldState.Buttons.Y)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.Y == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState A
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.A == gamePadWrapper.OldState.Buttons.A)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.A == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState B
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.B == gamePadWrapper.OldState.Buttons.B)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.B == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState LeftBumper
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.LeftShoulder == gamePadWrapper.OldState.Buttons.LeftShoulder)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.LeftShoulder == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState RightBumper
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.RightShoulder == gamePadWrapper.OldState.Buttons.RightShoulder)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.RightShoulder == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState LeftStick
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.LeftStick == gamePadWrapper.OldState.Buttons.LeftStick)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.LeftStick == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState RightStick
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.RightStick == gamePadWrapper.OldState.Buttons.RightStick)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.RightStick == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState Start
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.Start == gamePadWrapper.OldState.Buttons.Start)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.Start == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState Select
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.Back == gamePadWrapper.OldState.Buttons.Back)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.Back == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState Guide
        {
            get
            {
                if (gamePadWrapper.CurrentState.Buttons.Guide == gamePadWrapper.OldState.Buttons.Guide)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Buttons.Guide == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState LeftTrigger
        {
            get
            {
                if (gamePadWrapper.CurrentState.Triggers.Left > gamePadWrapper.TriggerSensitivity && gamePadWrapper.OldState.Triggers.Left > gamePadWrapper.TriggerSensitivity)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Triggers.Left > gamePadWrapper.TriggerSensitivity ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
                
            }
        }
        public ButtonPressState RightTrigger
        {
            get
            {
                if (gamePadWrapper.CurrentState.Triggers.Right > gamePadWrapper.TriggerSensitivity && gamePadWrapper.OldState.Triggers.Right > gamePadWrapper.TriggerSensitivity)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.Triggers.Right > gamePadWrapper.TriggerSensitivity ? ButtonPressState.Pressed : ButtonPressState.Released;
                }

            }
        }
        public ButtonPressState DPadUp
        {
            get
            {
                if (gamePadWrapper.CurrentState.DPad.Up == gamePadWrapper.OldState.DPad.Up)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.DPad.Up == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState DPadRight
        {
            get
            {
                if (gamePadWrapper.CurrentState.DPad.Right == gamePadWrapper.OldState.DPad.Right)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.DPad.Right == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState DPadDown
        {
            get
            {
                if (gamePadWrapper.CurrentState.DPad.Down == gamePadWrapper.OldState.DPad.Down)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.DPad.Down == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
        public ButtonPressState DPadLeft
        {
            get
            {
                if (gamePadWrapper.CurrentState.DPad.Left == gamePadWrapper.OldState.DPad.Left)
                {
                    return ButtonPressState.Constant;
                }
                else
                {
                    return gamePadWrapper.CurrentState.DPad.Left == XInputDotNetPure.ButtonState.Pressed ? ButtonPressState.Pressed : ButtonPressState.Released;
                }
            }
        }
    }

    public enum ButtonPressState
    {
        Constant,
        Pressed,
        Released
    }
}