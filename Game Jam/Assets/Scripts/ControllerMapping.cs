using UnityEngine;
using System.Collections.Generic;
using ControlWrapping;
public enum Controls
{
    shoot,
    light,
    pause,
    select,
    back
}

public class ControllerMapping
{
    Dictionary<Controls, List<Button>> inputMapping;

    //public delegate

    public ControllerMapping()
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
        
        //mapping[Controls.shoot].Add(Button.);
        //mapping[Controls.light].Add("test");
        //mapping[Controls.pause].Add("test");
        //mapping[Controls.select].Add("test");
        //mapping[Controls.back].Add("test");

        return mapping;
    }
}
