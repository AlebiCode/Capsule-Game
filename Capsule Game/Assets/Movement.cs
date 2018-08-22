using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);

        }
    }









}
