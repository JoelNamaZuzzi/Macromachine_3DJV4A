using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] private Vector3 beginPos;
    [SerializeField] private Vector3 initRot;
    private Rigidbody rb;
    public GameObject nextCheck;
    public Vector3 nextPos;
    void Start()
    {
        nextPos = nextCheck.transform.position;
        rb = GetComponent<Rigidbody>();
        transform.position = beginPos;
        transform.rotation = Quaternion.Euler(initRot);
    }

    void FixedUpdate()
    {
        rb.velocity =transform.up *1.0f;
        if (Vector3.Distance(nextPos, transform.position) <= 0.1f)
        {
            transform.position = nextCheck.transform.position;
            transform.rotation = Quaternion.Euler(nextCheck.GetComponent<NextCheckPTS>().Rot);
            nextCheck = nextCheck.GetComponent<NextCheckPTS>().nextCheck;
            nextPos = nextCheck.transform.position;
        }
    }
}
