using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] private Vector3 beginPos;
    [SerializeField] private Vector3 initRot;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = beginPos;
        transform.rotation = Quaternion.Euler(initRot);
    }

    void FixedUpdate()
    {
        rb.velocity =transform.up *1.0f;
    }
}
