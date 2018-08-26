using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementeByAle : MonoBehaviour {

        private Rigidbody rb;

        public string runKey;
        public string jumpKey;
        public string crouchKey;

        private float climbTime = 0;
        public float moveSpeed;
        public float jumpforce = 50;
        public float SpeedMolt = 1;

        public bool stanceCheck = true;
        private bool canJump;
        private bool isCrouching = false;
        public bool isgrounded = false;
        public bool canFoward;
        public bool canBackwards;
        public bool canRight;
        public bool canLeft;
        public bool wallclimbing;
        public bool canWallclimb;
        


    // Use this for initialization
    void Start()
        {
        rb = GetComponent<Rigidbody>();
        stanceCheck = true;
        canRight = true;
        canLeft = true;
        canFoward = true;
        canBackwards = true;
        canWallclimb = true;
        wallclimbing = false;
    }


    // Update is called once per frame
    void Update()
        {
        Debug.Log(canWallclimb);

        //MODIFICATORE VOLOCITà PER LA CORSA
        if (Input.GetKey(runKey) && SpeedMolt <= 2)
        {
            SpeedMolt += 0.1f;
        }
        else if (Input.GetKeyUp(runKey) && SpeedMolt > 1) { SpeedMolt = 1; } 
        else if (SpeedMolt > 2.2f) { SpeedMolt -= 0.5f; }

        //QUESTO è IL CONTROLLO PER IL SALTO
        if ((Input.GetKey(KeyCode.Space)==false) && (isgrounded==true))
            {
                canJump = true;
            }
            //QUESTO ROTEA IL PERSONAGGIO DOVE LA TELECAMERA GUARDA
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        //CROUCH
        if (Input.GetKeyDown(crouchKey) && isCrouching==false) 
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            isCrouching = true;
        }
        else if (Input.GetKeyDown(crouchKey) && isCrouching==true && stanceCheck == true)
        { transform.localScale = new Vector3(1, 1, 1);
            isCrouching = false;  }

        //WALLCLIMBING      SISTEMARE! LO SCRIPTE DEVE SEMPRE ESEGUIRE TROPPA ROBA
        if ((climbTime < 60) && (wallclimbing == false) && (canWallclimb == true))
            { climbTime = 60; }
        RaycastHit hit;
        int layerMask = 1 << 8;
        if (climbTime<= 0 || Input.GetKeyUp(jumpKey))
            {
            canWallclimb = false;
            }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.7f, layerMask) && Input.GetKey(jumpKey) && (canWallclimb==true))
        {
            wallclimbing = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rb.useGravity = false;
            rb.velocity = new Vector3(0, 5, 0);
            climbTime -= 1;

        } else if ((!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.7f, layerMask) || !Input.GetKey(jumpKey)))
        {
            wallclimbing = false;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rb.useGravity = true;
        }

    }


    void FixedUpdate()
    {
        RaycastHit hit;

        //     QUESTO è IL MOVIMENTO SU X E Z
        if (Input.GetKey(KeyCode.W) && canFoward==true)
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed * SpeedMolt;
            }
        if (Input.GetKey(KeyCode.S) && canBackwards==true)
            {
                rb.position -= transform.forward * Time.deltaTime * moveSpeed * SpeedMolt;
            }
        if (Input.GetKey(KeyCode.A) && canLeft==true)
            {
                rb.position -= transform.right * Time.deltaTime * moveSpeed * SpeedMolt;
            }
        if (Input.GetKey(KeyCode.D) && canRight==true)
            {
                rb.position += transform.right * Time.deltaTime * moveSpeed * SpeedMolt;
            }
        //QUESTO è IL SALTO 
        if ((canJump == true) && Input.GetKey(jumpKey))
        {
            canJump = false;
            rb.AddForce(0, jumpforce, 0,ForceMode.Impulse);
        }
    }




    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pick Up"))
            {
                Destroy(other.gameObject);

            }     

        }






}
