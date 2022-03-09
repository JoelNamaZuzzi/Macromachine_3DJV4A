using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RaceManager : MonoBehaviour
{
    public GameObject Cp;
    public GameObject CheckpointHolder;

    public GameObject[] Cars;
    public Transform[] CheckpointPositions;
    public GameObject[] CheckpointForEachCar;

    private int totalCars;
    private int totalCheckpoints;

    public CinemachineVirtualCamera CineMCam;

    public static RaceManager Instance;

    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        totalCars = Cars.Length;
        totalCheckpoints = CheckpointHolder.transform.childCount;
        setCheckpoints();
        setCarPosition();
    }

    void setCheckpoints()
    {
        CheckpointPositions = new Transform[totalCheckpoints];

        for (int i = 0; i < totalCheckpoints; i++)
        {
            CheckpointPositions[i] = CheckpointHolder.transform.GetChild(i).transform;
        }

        CheckpointForEachCar = new GameObject[totalCars];

        for (int i = 0; i < totalCars; i ++)
        {
            CheckpointForEachCar[i] = Instantiate(Cp, CheckpointPositions[0].position, CheckpointPositions[0].rotation);
            CheckpointForEachCar[i].name = "CP" + i;
            CheckpointForEachCar[i].layer = 6 + i;
        }
    }

    void setCarPosition()
    {
        for (int i = 0; i< totalCars;i++)
        {
            Cars[i].GetComponent<CarcpManager>().CarPosition = i + 1;
            Cars[i].GetComponent<CarcpManager>().CarNumber = i;
        }
    }


    public void CarCollectedCp(int Carnumber, int cpNumber)
    {
        CheckpointForEachCar[Carnumber].transform.position = CheckpointPositions[cpNumber].transform.position;
        CheckpointForEachCar[Carnumber].transform.rotation = CheckpointPositions[cpNumber].transform.rotation;

        comparePositions(Carnumber);
    }

    void comparePositions(int carNumber)
    {
        if(Cars[carNumber].GetComponent<CarcpManager>().CarPosition > 1)
        {
            GameObject currentCar = Cars[carNumber];
            int currentCarPos = currentCar.GetComponent<CarcpManager>().CarPosition;
            int currentCarCp = currentCar.GetComponent<CarcpManager>().cpCrossed;

            GameObject carInFront = null;
            int carInFrontpos = 0;
            int carInFrontcp = 0;

            for (int i =0;i<totalCars; i++)
            {
                if (Cars[i].GetComponent<CarcpManager>().CarPosition == currentCarPos - 1) //car in front
                {
                    carInFront = Cars[i];
                    carInFrontcp = carInFront.GetComponent<CarcpManager>().cpCrossed;
                    carInFrontpos = carInFront.GetComponent<CarcpManager>().CarPosition;
                    break;
                }
            }

            //this car has crossed the car in front

            if (currentCarCp > carInFrontcp)
            {
                currentCar.GetComponent<CarcpManager>().CarPosition = currentCarPos - 1;
                carInFront.GetComponent<CarcpManager>().CarPosition = carInFrontpos + 1;

                Debug.Log("Car" + carNumber + "has over taken" + carInFront.GetComponent<CarcpManager>().CarNumber);
                SetCamFocus();
            }
        }
    }

    public void SetCamFocus() //Set focus on first player
    {
        CineMCam.m_LookAt = Getfirstplaceplayer().transform;
        CineMCam.m_Follow = Getfirstplaceplayer().transform;
          
    }

    public GameObject Getfirstplaceplayer()
    {
        for (int i = 0; i < Cars.Length; i++)
        {
            if (Cars[i].GetComponent<CarcpManager>().CarPosition == 1)
            {
                return Cars[i];
            }

        }

        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
