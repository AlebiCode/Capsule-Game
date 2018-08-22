using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementeByAle : MonoBehaviour {

        private Rigidbody rb;
        public string runKey;
        public string jumpKey;
        public string crouchKey; 
        public float moveSpeed;
        public float jumpforce = 50;
        public float SpeedMolt = 1;
        private bool canJump;
        private bool isCrouching;
        bool isgrounded;

    // Use this for initialization
    void Start()
        {
        rb = GetComponent<Rigidbody>();
        isgrounded = false;
        isCrouching = false;
    }




    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "SetPlayerGrounded")
        {
            isgrounded = true;
        }
    }
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "SetPlayerGrounded")
        {
            isgrounded = false;
        }
    }

   

    // Update is called once per frame
    void Update()
        {
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
        RaycastHit hit;
        Ray CanStand = new Ray(transform.position,Vector3.up);
        if (Input.GetKeyDown(crouchKey) && isCrouching==false) 
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            isCrouching = true;
        }
        else if (Input.GetKeyDown(crouchKey) && isCrouching==true && !Physics.Raycast(transform.position,transform.TransformDirection(Vector3.up), out hit,0.5f))
        { transform.localScale = new Vector3(1, 1, 1);
            isCrouching = false;  }
            }



    void FixedUpdate()
    {
       
        
        //     QUESTO è IL MOVIMENTO SU X E Z
        if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed * SpeedMolt;
            }
        if (Input.GetKey(KeyCode.S))
            {
                rb.position -= transform.forward * Time.deltaTime * moveSpeed * SpeedMolt;
            }
        if (Input.GetKey(KeyCode.A))
            {
                rb.position -= transform.right * Time.deltaTime * moveSpeed * SpeedMolt;
            }
        if (Input.GetKey(KeyCode.D))
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
