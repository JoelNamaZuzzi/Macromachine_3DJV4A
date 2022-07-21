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
    public AudioSource sauce;
    public SoundObjectClass carRun;


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
            float x = transform.rotation.x;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical_P2"), 0f)); //* Input.GetAxis("Vertical") pour ne pas pouvoir rotate sans avancer, provoque une rotation forcée sur X
            transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, 0f); //provoque rotation forcée sur y
           
        }

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, turnInput * maxwheelturn - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxwheelturn - 180, rightFrontWheel.localRotation.eulerAngles.z);

        transform.position = theRB.transform.position;
        
    }

   
    private void FixedUpdate()
    {
        //Debug.Log(theRB.velocity.x);
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position,-transform.up,out hit, groundRayLength,whatisGround))  //Détection si on touche le sol
        {
            grounded = true;

            float y = transform.eulerAngles.y;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation; //prob of rotate
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, 0f);
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
                SoundManager.Instance.PlaySoundEffect(carRun, sauce);
            }
            if(theRB.velocity.x > -0.001f)
            {
                //on coupe le son du moteur
                SoundManager.Instance.StopSound(sauce);
                //Debug.Log("stopped");
            }
        }
        else
        {
            theRB.drag = 0.1f; 
            theRB.AddForce(Vector3.up * -gravityForce); //Si on avance pas on pousse la voiture vers le sol 
            
            //on coupe le son du moteur
            SoundManager.Instance.StopSound(sauce);
        }

        foreach (ParticleSystem part in dustTrial)
        {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }
   
}
