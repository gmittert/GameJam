using UnityEngine;
using System.Collections;
using XInputDotNetPure;

namespace ControlWrapping
{
    public class Stick
    {
        GamePadWrapper gamePadWrapper;

        public Stick(GamePadWrapper gamePadWrapper)
        {
            this.gamePadWrapper = gamePadWrapper;
        }

        public GamePadThumbSticks.StickValue Left
        {
            get
            {
                return gamePadWrapper.CurrentState.ThumbSticks.Left;
            }
        }
        public GamePadThumbSticks.StickValue Right
        {
            get
            {
                return gamePadWrapper.CurrentState.ThumbSticks.Right;
            }
        }
        public GamePadThumbSticks.StickValue DPad
        {
            get
            {
                GamePadThumbSticks.StickValue stick = new GamePadThumbSticks.StickValue();
                if (gamePadWrapper.CurrentState.DPad.Left == XInputDotNetPure.ButtonState.Pressed) 
                {
                    //stick.X = -1; //Noooooooo
                }
                return stick;

            }
        }

    }
}
