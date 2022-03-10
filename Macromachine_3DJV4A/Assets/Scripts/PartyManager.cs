using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{

    public GameObject LifeCanvas;
    public int nblife;
    public GameObject parentlife = null;
    public GameObject lifeUI;
    public static PartyManager Instance;
    // Start is called before the first frame update


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    void Start()
    {
       
        SetUILife();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUILife()
    {

        for (int i = 0; i < RaceManager.Instance.Cars.Length; i++)
        {
           GameObject CurentGOParent =  Instantiate<GameObject>(parentlife, LifeCanvas.GetComponent<RectTransform>());
            Debug.Log(i);
            RaceManager.Instance.PlayerUILife[i] = CurentGOParent;
            for (int j = 0; j < nblife; j++)
            {
                Instantiate(lifeUI,CurentGOParent.transform);
            } 
        }
    }
}
