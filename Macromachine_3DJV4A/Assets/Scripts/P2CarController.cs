using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2CarController : MonoBehaviour
{
    public Rigidbody theRB;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180, gravityForce = 10f, dragOnGround =3;
    private float speedInput, turnInput;

    private bool grounded;

    public LayerMask whatisGround;
    public float groundRayLength = .5f;
    public Transform groundRayPoint;

    public Transform leftFrontWheel, rightFrontWheel;
    public float maxwheelturn = 25;

    public ParticleSystem[] dustTrial;
    public float maxEmission = 25f;
    private float emissionRate;
    
    //sounds
    public AudioSource Sauce;
    public AudioClip CarRun;


    // Start is called before the first frame update
    void Start()
    {
        theRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if(Input.GetAxis("Vertical_P2") > 0) //Récupération mouvements vertical
        {
            speedInput = Input.GetAxis("Vertical_P2") * forwardAccel * 1000f;
        }

        else if (Input.GetAxis("Vertical_P2") < 0) 
        {
            speedInput = Input.GetAxis("Vertical_P2") * reverseAccel * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal_P2"); //Récupération mouvements Horizontal

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical_P2"), 0f)); //* Input.GetAxis("Vertical") pour ne pas pouvoir rotate sans avancer
        }

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, turnInput * maxwheelturn - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxwheelturn - 180, rightFrontWheel.localRotation.eulerAngles.z);

        transform.position = theRB.transform.position;
        
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position,-transform.up,out hit, groundRayLength,whatisGround))  //Détection si on touche le sol
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        emissionRate = 0;


        if (grounded)
        {
            theRB.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0) //Faire avancer la voiture
            {
                theRB.AddForce(transform.forward * speedInput);

                emissionRate = maxEmission;
                
                //Play the sound effect if it is activated
                if (SoundManager.Instance.soundPlay == true)
                {
                    if(!Sauce.isPlaying)
                    {
                        Sauce.clip = CarRun;
                        Sauce.Play();
                    }
                    
                }
            }
        }
        else
        {
            theRB.drag = 0.1f;
            theRB.AddForce(Vector3.up * -gravityForce); //Si on avance pas on pousse la voiture vers le sol
            
            //on coupe le son du moteur
            if (SoundManager.Instance.soundPlay == true)
            {
                if(!Sauce.isPlaying)
                {
                    Sauce.Stop();
                }
                    
            }
        }

        foreach (ParticleSystem part in dustTrial)
        {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }
}
