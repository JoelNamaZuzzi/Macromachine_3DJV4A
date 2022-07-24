using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MacromaniaNetworkPlayer : NetworkBehaviour
{
    [SyncVar(hook = nameof(AuthorityHandlePartyOwnerStateUpdated))]
    private bool isPartyOwner = false;
    
    [SerializeField]
    [SyncVar]
    private int live = 3;

    [SerializeField] [SyncVar] private string name = "basename";
    
    [SerializeField] [SyncVar] private int playerNumber;
    
    [SerializeField]
    private GameObject car;
    public static event Action<bool> AuthorityOnPartyOwnerStateUpdated;


    public int GetLive()
    {
        return live;
    }

    public GameObject GetCar()
    {
        return car;
    }
    
    public string GetName()
    {
        return name;
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }
    
    [Server]
    public void SetPlayerNumber(int nb)
    {
        playerNumber = nb;
    }
    
    [Server]
    public void SetPlayerName(string n)
    {
        name = n;
    }

    private void OnDestroy()
    {
        ((MicromaniaNetworkManager)NetworkManager.singleton).Players.Remove(this);
    }

    public bool GetIsPartyOwner()
    {
        return isPartyOwner;
    }

    public override void OnStartServer()
    {
        //DontDestroyOnLoad(gameObject);
    }

    public override void OnStartClient()
    {
        if (NetworkServer.active) {return;}
        
        //DontDestroyOnLoad(gameObject);
        
        ((MicromaniaNetworkManager)NetworkManager.singleton).Players.Add(this);
    }

    public override void OnStopClient()
    {
        if (!isClientOnly) {return;}
        
        ((MicromaniaNetworkManager)NetworkManager.singleton).Players.Remove(this);
    }

    [Server]
    public void SetPartyOwner(bool state)
    {
        isPartyOwner = state;
    }

    [Command]
    public void CmdStartGame()
    {
        if(!isPartyOwner){return;}
        
        ((MicromaniaNetworkManager)NetworkManager.singleton).StartGame();
    }

    [Server]
    public void reducePlayerLive()
    {
        live--;

        if (live <= 0)
        {
            ((MicromaniaNetworkManager)NetworkManager.singleton).checkWinner();
        } 
    }

    [Command]
    public void cmdReduceLive()
    {
        //if (!hasAuthority) { return; }
        reducePlayerLive();
    }
    private void AuthorityHandlePartyOwnerStateUpdated(bool oldState, bool newState)
    {
        if (!hasAuthority)
        {
            return;
        }

        AuthorityOnPartyOwnerStateUpdated?.Invoke(newState);
    }
}
