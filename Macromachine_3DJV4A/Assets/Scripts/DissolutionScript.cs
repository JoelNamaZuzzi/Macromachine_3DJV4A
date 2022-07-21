using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolutionScript : MonoBehaviour
{

    private float timeRespawn = 0.0f;
    public bool isRespawning = false;
    public Color CarColor = Color.red;

    public static DissolutionScript Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    

    [SerializeField] private Renderer[] carBody = new Renderer[0];
    
    void Start()
    {
        foreach(Renderer body in carBody)
        {
            body.material.SetColor("_ColorBody",CarColor);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.LogWarningFormat("test");
            isRespawning = true;
        }
        if(isRespawning == true)
        {
            if(timeRespawn <= 1)
            {
                timeRespawn = timeRespawn + Time.deltaTime/2;
                Debug.LogWarningFormat(timeRespawn.ToString());

                foreach(Renderer body in carBody)
                {
                    body.material.SetFloat("_TimeRespawn",timeRespawn);
                }
            }
            else
            {
                timeRespawn = 0.0f;
                isRespawning = false;
            }
        }
        
    }
}
