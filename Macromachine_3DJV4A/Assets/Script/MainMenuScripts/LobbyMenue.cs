using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMenue : MonoBehaviour
{
    [SerializeField] private GameObject lobbyUI = null;
    [SerializeField] private Button startGameButton = null;
    private void Start()
    {
        MicromaniaNetworkManager.ClientOnConnected += HandleClientConnected;
        MacromaniaNetworkPlayer.AuthorityOnPartyOwnerStateUpdated += AuthorityHandlerPartyOwnerStateUpdated;
    }

    private void OnDestroy()
    {
        MicromaniaNetworkManager.ClientOnConnected -= HandleClientConnected;
        MacromaniaNetworkPlayer.AuthorityOnPartyOwnerStateUpdated -= AuthorityHandlerPartyOwnerStateUpdated;
    }

    private void HandleClientConnected()
    {
        lobbyUI.SetActive(true);
    }

    private void AuthorityHandlerPartyOwnerStateUpdated(bool state)
    {
        startGameButton.gameObject.SetActive(state);
    }
    public void LeaveLobby()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        else
        {
            NetworkManager.singleton.StopClient();

            SceneManager.LoadScene(0);
        }
        
    }

    public void StartGame()
    {
        NetworkClient.connection.identity.GetComponent<MacromaniaNetworkPlayer>().CmdStartGame();
    }
}
