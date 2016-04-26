using UnityEngine;
using System.Collections;
using XInputDotNetPure;

namespace ControlWrapping
{
    public class GamePadWrapper
    {
        private GamePadState currentState;
        private GamePadState oldState;
        private Button button;
        private Stick stick;
        private Trigger trigger;
        private ButtonPress buttonPress;

        private float triggerSensitivity = .85f;

        public GamePadWrapper()
        {
            button = new Button(this);
            stick = new Stick(this);
            trigger = new Trigger(this);
            buttonPress = new ButtonPress(this);
        }

        public GamePadState CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                oldState = currentState;
                currentState = value;
            }
        }

        public GamePadState OldState
        {
            get
            {
                return oldState;
            }
        }

        public float TriggerSensitivity
        {
            get
            {
                return triggerSensitivity;
            }
            set
            {
                triggerSensitivity = Mathf.Clamp(value, 0, 1);
            }
        }

        public Button Button
        {
            get
            {
                return button;
            }
        }
        public Stick Stick
        {
            get
            {
                return stick;
            }
        }
        public Trigger Trigger
        {
            get
            {
                return trigger;
            }
        }
        public ButtonPress ButtonPress
        {
            get
            {
                return buttonPress;
            }
        }
    }
}