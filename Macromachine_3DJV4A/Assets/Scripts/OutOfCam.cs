using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCam : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
           
            other.transform.position = RaceManager.Instance.Getfirstplaceplayer().transform.position;

            Debug.Log(other.GetComponent<LinkToCarParent>().CarParent.name);
            Debug.Log(RaceManager.Instance.Getfirstplaceplayer().GetComponent<LinkToCarParent>().CarParent.transform.rotation);

            other.GetComponent<LinkToCarParent>().CarParent.transform.rotation = RaceManager.Instance.Getfirstplaceplayer().GetComponent<LinkToCarParent>().CarParent.transform.rotation; //On met à la voiture sortante la rotation du winner, le RB ne sert pas pour la rotation dans CarController
            

            // on donne au perdant les stats du premier joueur
            other.GetComponent<CarcpManager>().cpCrossed = RaceManager.Instance.Getfirstplaceplayer().GetComponent<CarcpManager>().cpCrossed;
            RaceManager.Instance.CarCollectedCp(other.GetComponent<CarcpManager>().CarNumber, other.GetComponent<CarcpManager>().cpCrossed);
        }
    }
}
