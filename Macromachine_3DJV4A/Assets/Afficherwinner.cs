using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class Afficherwinner : MonoBehaviour
{
    public Text WinnerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinnerText.text = ((MicromaniaNetworkManager) NetworkManager.singleton).GetWinner();
    }
    
    
}
