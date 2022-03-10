using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierList : MonoBehaviour
{
    public GameObject[] points = new GameObject[] { };

    public GameObject[] GetList()
    {
        return points;
    }
}
