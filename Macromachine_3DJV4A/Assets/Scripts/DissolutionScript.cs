using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolutionScript : MonoBehaviour
{

    private float timeRespawn = 0.0f;
    private bool isRespawning = false;

    [SerializeField] private Renderer[] carBody = new Renderer[0];
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
