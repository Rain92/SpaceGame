using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class NetworkScript : MonoBehaviour
{
    public void CreateServer()
    {
        //MasterServer.ipAddress = "127.0.0.1";
        //MasterServer.port = 23466;

        string sname = GameObject.Find("ServerText").GetComponent<Text>().text;
        int port = int.Parse(GameObject.Find("PortText").GetComponent<Text>().text);

        var n = Network.InitializeServer(3, port, !Network.HavePublicAddress());
        Debug.Log(n.ToString());
        MasterServer.RegisterHost("SpaceGame", sname , "another game");
    }
    public void CheckForGames()
    {
        MasterServer.RequestHostList("SpaceGame");

        HostData[] data = MasterServer.PollHostList();

        Debug.Log(data.Length);

        foreach (var d in data)
        {
            Debug.Log(d.gameName);
            GetComponent<GuiScript>().AddPanel(d);
        }

    }
    public void ConnectToServer(HostData s)
    {
        var n = Network.Connect(s);
        Debug.Log(n.ToString());
    }


}
