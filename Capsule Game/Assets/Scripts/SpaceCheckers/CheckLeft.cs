using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLeft : MonoBehaviour {

    void OnTriggerEnter(Collider theCollision)
    {
        if (theCollision.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().canLeft = false;
        }
    }

    void OnTriggerExit(Collider theCollision)
    {
        if (theCollision.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().canLeft = true;
        }
    }
}
