using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicromaniaNetworkManager : NetworkManager
{

    public static event Action ClientOnConnected;
    public static event Action ClienOnDisconnected;


    [SerializeField] private GameObject carPrefab;
    private bool isGameInProgress;
    
    public List<MacromaniaNetworkPlayer> Players { get; } = new List<MacromaniaNetworkPlayer>();

    #region Server

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        if (!isGameInProgress)
        {
            return;
        }

        conn.Disconnect();
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        MacromaniaNetworkPlayer player = conn.identity.GetComponent<MacromaniaNetworkPlayer>();

        Players.Remove(player);
        
        base.OnServerDisconnect(conn);
    }

    public override void OnStopServer()
    {
        Players.Clear();

        isGameInProgress = false;
        
        base.OnStopServer();
    }

    public void StartGame()
    {
        if (Players.Count <2) {return;}

        isGameInProgress = true;
        
        ServerChangeScene("Track");
    }


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        
        MacromaniaNetworkPlayer player = conn.identity.GetComponent<MacromaniaNetworkPlayer>();

        Players.Add(player);
        
        player.SetPartyOwner(Players.Count == 1);
        
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        if (SceneManager.GetActiveScene().name.StartsWith("Track"))
        {
            /*foreach (MacromaniaNetworkPlayer player in Players)
            {
                Instantiate()
            }*/
        }
    }

    #endregion

    #region Client

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        
        ClientOnConnected?.Invoke();
    }

    public override void OnClientDisconnect()
    {
        ClienOnDisconnected?.Invoke();
    }

    #endregion

    


    
}
