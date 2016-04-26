using UnityEngine;
using System.Collections;

namespace ControlWrapping
{
    public class Trigger
    {
        GamePadWrapper gamePadWrapper;

        public Trigger(GamePadWrapper gamePadWrapper)
        {
            this.gamePadWrapper = gamePadWrapper;
        }

        public float Left
        {
            get
            {
                return gamePadWrapper.CurrentState.Triggers.Left;
            }
        }
        public float Right
        {
            get
            {
                return gamePadWrapper.CurrentState.Triggers.Right;
            }
        }
    }
}