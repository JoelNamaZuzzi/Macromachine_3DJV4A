using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentoireScript : MonoBehaviour
{
    private Transform trans;
    public float rot;
    private void Start()
    {
        trans = GetComponent<Transform>();
    }

    private void Update()
    {
        trans.Rotate(0.0f, rot, 0.0f);
    }
}
