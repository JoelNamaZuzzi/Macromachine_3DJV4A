using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicromaniaNetworkManager : NetworkManager
{

    public static event Action ClientOnConnected;
    public static event Action ClienOnDisconnected;


    [SerializeField] private GameObject carPrefab;
    private bool isGameInProgress;
    
    [SerializeField]
    private WinnerCollector winner;

    [SerializeField]
    public List<MacromaniaNetworkPlayer> Players;

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
        
        ServerChangeScene("MTrack");
    }


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        
        MacromaniaNetworkPlayer player = conn.identity.GetComponent<MacromaniaNetworkPlayer>();

        Players.Add(player);
        
        player.SetPlayerNumber(numPlayers);
        
        player.SetPlayerName($"Player{numPlayers}");

        CarController controller = conn.identity.GetComponent<CarController>();

        if (!conn.identity.isLocalPlayer)
        {
            controller.enabled = false;
        }
        
        
        player.SetPartyOwner(Players.Count == 1);
        
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        if (SceneManager.GetActiveScene().name.StartsWith("MTrack"))
        {
            foreach (MacromaniaNetworkPlayer player in Players)
            {
                player.transform.position = GetStartPosition().position;
                player.GetCar().GetComponent<CarController>().theRB.transform.position=GetStartPosition().position;
            }
        }
        
        if (SceneManager.GetActiveScene().name.StartsWith("WIN"))
        {
            RaceManager.Instance.Winner = winner.GetWinner();
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

    public void CheckDeath()
    {
       foreach (MacromaniaNetworkPlayer player in Players)
        {
            if (player.GetLive() <= 0)
            {
                //Debug.Log("Player " + player.GetCar().GetComponent<LinkToCarParent>().CarParent.name + " is Dead");
                checkWinner();
                return;
            }
        }
    }

    public void checkWinner()
    {
        foreach (MacromaniaNetworkPlayer player in Players)
        {
            if (player.GetLive() > 0)
            {
                winner.SetWinner(player.GetName());
                ServerChangeScene("MWIN");
                return;
            }
        }
        
    }
    
    public string GetWinner()
    {
        return winner.GetWinner();
    }
    
    public void Disconnect() 
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
           StopHost();
        }
        else
        {
            StopClient();
        }

    }



}
