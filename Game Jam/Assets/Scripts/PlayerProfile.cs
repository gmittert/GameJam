using UnityEngine;
using System.Collections.Generic;
//using XInputDotNetPure;
using ControlWrapping;

//TODO: OK look, this is broken, deal with it later

public class PlayerProfile {
    string name;
    int numberOfKills;
    int numberOfDeaths;
    int numberOfGamesPlayed;

    ControllerMapping controllerMapping;

    public PlayerProfile()
    {
        controllerMapping = new ControllerMapping();
        //read data from savefile
    }
}
