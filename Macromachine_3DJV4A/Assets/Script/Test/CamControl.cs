using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] private Vector3 beginPos;
    [SerializeField] private Vector3 initRot;
    public float speed=1.0f;
    private Rigidbody rb;
    public GameObject nextCheck;
    public Vector3 nextPos;
    [SerializeField]private bool car1=false;
    [SerializeField]private bool car2=false;
    [SerializeField]private bool car3=false;
    [SerializeField]private bool car4=false;
    public float playerHeigth=0.0f;
    public Vector3 playerRot;

    void Start()
    {
        nextPos = nextCheck.transform.position;
        rb = GetComponent<Rigidbody>();
        transform.position = beginPos;
        transform.rotation = Quaternion.Euler(initRot);
    }

    void FixedUpdate()
    {
        //rb.velocity =transform.up *1.0f;
        //Debug.Log(Vector3.Distance(nextPos, transform.position));
        if (Vector3.Distance(nextPos, transform.position) <= 0.5f)
        {
            playerRot = nextCheck.GetComponent<NextCheckPTS>().playerRot;
            playerHeigth = nextCheck.GetComponent<NextCheckPTS>().ph;
            transform.position = nextCheck.transform.position;
            transform.rotation = Quaternion.Euler(nextCheck.GetComponent<NextCheckPTS>().Rot);
            nextCheck = nextCheck.GetComponent<NextCheckPTS>().nextCheck;
            nextPos = nextCheck.transform.position;
            Debug.Log("test");
        }

        if (car1 || car2 || car3 || car4)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            car1 = true;
        }
        else if (other.gameObject.layer == 8)
        {
            car2 = true;
        }
        else if (other.gameObject.layer == 9)
        {
            car3 = true;
        }
        else if (other.gameObject.layer == 10)
        {
            car4 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            car1 = false;
        }
        else if (other.gameObject.layer == 8)
        {
            car2 = false;
        }
        else if (other.gameObject.layer == 9)
        {
            car3 = false;
        }
        else if (other.gameObject.layer == 10)
        {
            car4 = false;
        }
    }
}
