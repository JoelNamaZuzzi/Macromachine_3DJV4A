using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public GameObject Cp;
    public GameObject CheckpointHolder;

    public GameObject[] Cars;
    public Transform[] CheckpointPositions;
    public GameObject[] CheckpointForEachCar;

    private int totalCars;
    private int totalCheckpoints;

    // Start is called before the first frame update
    void Start()
    {
        totalCars = Cars.Length;
        totalCheckpoints = CheckpointHolder.transform.childCount;
        setCheckpoints();
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


    public void CarCollectedCp(int Carnumber, int cpNumber)
    {
        CheckpointForEachCar[Carnumber].transform.position = CheckpointPositions[cpNumber].transform.position;
        CheckpointForEachCar[Carnumber].transform.rotation = CheckpointPositions[cpNumber].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
