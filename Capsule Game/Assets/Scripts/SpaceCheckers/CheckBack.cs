using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBack : MonoBehaviour {

    void OnTriggerEnter(Collider theCollision)
    {
        if (theCollision.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().canBackwards = false;
        }
    }

    void OnTriggerExit(Collider theCollision)
    {
        if (theCollision.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().canBackwards = true;
        }
    }
}
