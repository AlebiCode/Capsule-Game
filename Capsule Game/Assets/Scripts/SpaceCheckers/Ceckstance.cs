using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceckstance : MonoBehaviour {

    void OnTriggerEnter(Collider thecollider)
    {
        if (thecollider.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().stanceCheck = false;
        }
    }

    void OnTriggerExit(Collider thecollider)
    {
        if (thecollider.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().stanceCheck = true;
        }
    }


}
