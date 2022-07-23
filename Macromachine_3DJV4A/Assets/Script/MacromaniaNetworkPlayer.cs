using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MacromaniaNetworkPlayer : NetworkBehaviour
{
    [SyncVar(hook = nameof(AuthorityHandlePartyOwnerStateUpdated))]
    private bool isPartyOwner = false;

    public static event Action<bool> AuthorityOnPartyOwnerStateUpdated;

    public bool GetIsPartyOwner()
    {
        return isPartyOwner;
    }
    public override void OnStartClient()
    {
        if (NetworkServer.active) {return;}
        
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

    private void AuthorityHandlePartyOwnerStateUpdated(bool oldState, bool newState)
    {
        if (!hasAuthority)
        {
            return;
        }

        AuthorityOnPartyOwnerStateUpdated?.Invoke(newState);
    }
}
