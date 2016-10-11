using System.Collections.Generic;

public static class GameManager {
    private static XInputDotNetPure.PlayerIndex[] playerIndices = new XInputDotNetPure.PlayerIndex[] 
        { XInputDotNetPure.PlayerIndex.One, XInputDotNetPure.PlayerIndex.Two,
            XInputDotNetPure.PlayerIndex.Three, XInputDotNetPure.PlayerIndex.Four };
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
	
    public static XInputDotNetPure.GamePadState GetGamePadState(int playerIndex)
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

/// <summary>
/// Log Levels control if messages are printed.
/// <list type="number">
/// <listheader>Levels</listheader>
/// <item>
/// <term>None: </term>
/// <description>should never be used as no messages are printed at this level.</description>
/// </item>
/// <item>
/// <term>Medium: </term>
/// <description>the default level for debuging.</description>
/// </item>
/// <item>
/// <term>High: </term>
/// <description>for useful information.</description>
/// </item>
/// <item>
/// <term>Verbose: </term>
/// <description>for extrainious information.</description>
/// </item>
/// <item>
/// <term>Facist:</term>
/// <description>for calls which occure every frame.</description>
/// </item>
/// </list>
/// </summary>
public enum LogLevel
{
    None, Low, Medium, High, Verbose, Facist
}
