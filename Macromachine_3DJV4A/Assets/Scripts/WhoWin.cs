using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = System.Random;

public class WhoWin : MonoBehaviour
{
    public static WhoWin Instance;
    public String Winner = "test";
    public Text WinnerText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    void Start()
    {
        Winner = RaceManager.Instance.Winner;
        Debug.Log(Winner);
        WinnerText.text = Winner;
    }
}
