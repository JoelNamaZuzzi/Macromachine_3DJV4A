using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarcpManager : MonoBehaviour
{
    public int cpCrossed = 0;
    public int CarNumber;

    public string CPnameverif;
    public int CarPosition;
    public RaceManager racemanager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == CPnameverif) 
        {
            cpCrossed += 1;
            racemanager.CarCollectedCp(CarNumber, cpCrossed);
            Debug.Log("Collision with CP");
        }
    }
}
