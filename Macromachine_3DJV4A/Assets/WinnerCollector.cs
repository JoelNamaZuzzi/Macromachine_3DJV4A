using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class WinnerCollector : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string winner;

    public override void OnStartServer()
    {
        DontDestroyOnLoad(gameObject);
    }

    public override void OnStartClient()
    {
        if (NetworkServer.active)
        {
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    [Server]
    public void SetWinner(string w)
    {
        winner = w;
    }

    [Command]
    public void CmdSetWinner(string w)
    {
        SetWinner(w);
    }

    public string GetWinner()
    {
        return winner;
    }
}
