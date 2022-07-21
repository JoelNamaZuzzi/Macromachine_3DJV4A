using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class OutOfCam : MonoBehaviour
{
    private GameObject cardissolve;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {

            cardissolve = GameObject.Find(other.GetComponent<LinkToCarParent>().CarParent.name);
            cardissolve.GetComponent<DissolutionScript>().isRespawning = true;
            other.transform.position = RaceManager.Instance.Getfirstplaceplayer().transform.position;

            Debug.Log(other.GetComponent<LinkToCarParent>().CarParent.name);
            RaceManager.Instance.Playerslife[other.GetComponent<CarcpManager>().CarNumber] -= 1; //-1 life pour le player sorti

            Destroy(RaceManager.Instance.PlayerUILife[other.GetComponent<CarcpManager>().CarNumber].transform.GetChild(RaceManager.Instance.PlayerUILife[other.GetComponent<CarcpManager>().CarNumber].transform.childCount - 1).gameObject);//Afficher la vie en moins
            RaceManager.Instance.CheckDeath();
            

            other.GetComponent<LinkToCarParent>().CarParent.transform.rotation = RaceManager.Instance.Getfirstplaceplayer().GetComponent<LinkToCarParent>().CarParent.transform.rotation; //On met à la voiture sortante la rotation du winner, le RB ne sert pas pour la rotation dans CarController
            

            // on donne au perdant les stats du premier joueur
            other.GetComponent<CarcpManager>().cpCrossed = RaceManager.Instance.Getfirstplaceplayer().GetComponent<CarcpManager>().cpCrossed;
            RaceManager.Instance.CarCollectedCp(other.GetComponent<CarcpManager>().CarNumber, other.GetComponent<CarcpManager>().cpCrossed);
        }
    }
}
