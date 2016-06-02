using System.Collections.Generic;

public static class GameManager {
    private static XInputDotNetPure.PlayerIndex[] playerIndices = new XInputDotNetPure.PlayerIndex[] { XInputDotNetPure.PlayerIndex.One, XInputDotNetPure.PlayerIndex.Two, XInputDotNetPure.PlayerIndex.Three, XInputDotNetPure.PlayerIndex.Four };
    static Player[] playerList = new Player[4];

    static LogLevel currentLogLevel = LogLevel.Medium;

    public static int AddPlayer(Player player)
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            if (playerList[i] == null)
            {
                playerList[i] = player;
                return i;
            }
        }
        return -1;
    }
	
    public static XInputDotNetPure.GamePadState GetPlayerIndex(int playerIndex)
    {
        return XInputDotNetPure.GamePad.GetState(playerIndices[playerIndex]);
    }

    public static void Log(object toPrint, object callingClass = null, LogLevel logLevel = LogLevel.Medium)
    {
        if (currentLogLevel != LogLevel.None && currentLogLevel >= logLevel)
        {
            if (callingClass != null)
            {
                UnityEngine.Debug.Log(callingClass + ": " + toPrint);
            }
            else
            {
                UnityEngine.Debug.Log(toPrint);
            }
            
        }
    }
}

public enum LogLevel
{
    None, Low, Medium, High, Verbose, Facist
}
