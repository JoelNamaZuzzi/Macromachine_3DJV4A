using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] private InputField addressInput = null;
    [SerializeField] private Button joinButton = null;

    private void OnEnable()
    {
        MicromaniaNetworkManager.ClientOnConnected += HandleClientConnected;
        MicromaniaNetworkManager.ClienOnDisconnected += HandleClientDisconnected;
    }

    private void OnDisable()
    {
        MicromaniaNetworkManager.ClientOnConnected -= HandleClientConnected;
        MicromaniaNetworkManager.ClienOnDisconnected -= HandleClientDisconnected;
    }

    public void Join()
    {
        string address = addressInput.text;

        NetworkManager.singleton.networkAddress = address;
        NetworkManager.singleton.StartClient();

        joinButton.interactable = false;

    }

    private void HandleClientConnected()
    {
        
        joinButton.interactable = true;
        gameObject.SetActive(false);
        
    }

    private void HandleClientDisconnected()
    {
        joinButton.interactable = true;
    }

    
    
    
}
