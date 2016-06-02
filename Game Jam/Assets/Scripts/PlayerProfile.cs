using UnityEngine;
using System.Collections.Generic;
//using XInputDotNetPure;
using ControlWrapping;
public enum Controls
{
    shoot,
    light,
    pause,
    select,
    back
}

//TODO: OK look, this is broken, deal with it later

public class PlayerProfile {
    string name;
    Dictionary<Controls, List<Button>> inputMapping;

    //public delegate

    public PlayerProfile()
    {
        foreach (Controls control in System.Enum.GetValues(typeof(Controls)))
        {
            inputMapping[control] = new List<Button>();
        }
    }

    public bool setControl(Controls control)
    {
        return false;
    }

    private static Dictionary<Controls, List<Button>> getDefaultMapping()
    {
        Dictionary<Controls, List<Button>> mapping = new Dictionary<Controls, List<Button>>();
        
        foreach (Controls control in System.Enum.GetValues(typeof(Controls)))
        {
            mapping[control] = new List<Button>();
        }

        XInputDotNetPure.GamePadState bla = XInputDotNetPure.GamePad.GetState(XInputDotNetPure.PlayerIndex.One);

        //mapping[Controls.shoot].Add(Button.);
        //mapping[Controls.light].Add("test");
        //mapping[Controls.pause].Add("test");
        //mapping[Controls.select].Add("test");
        //mapping[Controls.back].Add("test");

        return mapping;
    }
    

	
}
