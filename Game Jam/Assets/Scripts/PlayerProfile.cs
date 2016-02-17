using UnityEngine;
using System.Collections.Generic;
using XInputDotNetPure;

public enum Controls
{
    shoot,
    light,
    pause,
    select,
    back
}

public class PlayerProfile {
    string name;
    Dictionary<Controls, List<GamePadButtons>> inputMapping;

    

    public PlayerProfile()
    {
        foreach (Controls control in System.Enum.GetValues(typeof(Controls)))
        {
            inputMapping[control] = new List<GamePadButtons>();
        }
    }

    public bool setControl(Controls control)
    {
        return false;
    }

    private static Dictionary<Controls, List<string>> getDefaultMapping()
    {
        Dictionary<Controls, List<string>> mapping = new Dictionary<Controls, List<string>>();
        
        foreach (Controls control in System.Enum.GetValues(typeof(Controls)))
        {
            mapping[control] = new List<string>();
        }

        mapping[Controls.shoot].Add("test");
        mapping[Controls.light].Add("test");
        mapping[Controls.pause].Add("test");
        mapping[Controls.select].Add("test");
        mapping[Controls.back].Add("test");

        return mapping;
    }
    

	
}
