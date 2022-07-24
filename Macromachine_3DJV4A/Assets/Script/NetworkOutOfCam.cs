using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class NetworkOutOfCam : MonoBehaviour
{
    private GameObject cardissolve;
    [SerializeField] private GameObject cam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("die");
            cardissolve = GameObject.Find(other.GetComponent<LinkToCarParent>().CarParent.name);
            cardissolve.GetComponent<DissolutionScript>().isRespawning = true;
            //other.transform.position = RaceManager.Instance.Getfirstplaceplayer().transform.position;
            other.transform.position = new Vector3(cam.transform.position.x,cam.GetComponent<CamControl>().playerHeigth ,cam.transform.position.z);
            Debug.Log(other.GetComponent<LinkToCarParent>().CarParent.name);
            other.GetComponent<LinkToCarParent>().CarParent.gameObject.GetComponent<MacromaniaNetworkPlayer>().cmdReduceLive();
            //RaceManager.Instance.Playerslife[other.GetComponent<CarcpManager>().CarNumber] -= 1; //-1 life pour le player sorti

            //Destroy(RaceManager.Instance.PlayerUILife[other.GetComponent<CarcpManager>().CarNumber].transform.GetChild(RaceManager.Instance.PlayerUILife[other.GetComponent<CarcpManager>().CarNumber].transform.childCount - 1).gameObject);//Afficher la vie en moins
           ((MicromaniaNetworkManager)NetworkManager.singleton).CheckDeath();
            

            //other.GetComponent<LinkToCarParent>().CarParent.transform.rotation = RaceManager.Instance.Getfirstplaceplayer().GetComponent<LinkToCarParent>().CarParent.transform.rotation; //On met à la voiture sortante la rotation du winner, le RB ne sert pas pour la rotation dans CarController
            //other.GetComponent<LinkToCarParent>().CarParent.transform.rotation = Quaternion.Euler(cam.GetComponent<CamControl>().playerRot);

            // on donne au perdant les stats du premier joueur
            //other.GetComponent<CarcpManager>().cpCrossed = RaceManager.Instance.Getfirstplaceplayer().GetComponent<CarcpManager>().cpCrossed;
            //RaceManager.Instance.CarCollectedCp(other.GetComponent<CarcpManager>().CarNumber, other.GetComponent<CarcpManager>().cpCrossed);
        }
    }
}
