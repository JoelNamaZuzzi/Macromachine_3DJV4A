using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCam : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("-1 Life");
            other.transform.position = RaceManager.Instance.Getfirstplaceplayer().transform.position;
            other.transform.rotation = RaceManager.Instance.Getfirstplaceplayer().transform.rotation;
            // on donne au perdant les stats du premier joueur
            other.GetComponent<CarcpManager>().cpCrossed = RaceManager.Instance.Getfirstplaceplayer().GetComponent<CarcpManager>().cpCrossed;
            RaceManager.Instance.CarCollectedCp(other.GetComponent<CarcpManager>().CarNumber, other.GetComponent<CarcpManager>().cpCrossed);

        }
    }
}
