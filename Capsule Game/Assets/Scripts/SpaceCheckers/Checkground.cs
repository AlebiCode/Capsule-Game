using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkground : MonoBehaviour {

    void OnTriggerEnter(Collider theCollision)
    {
        if (theCollision.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().isgrounded = true;
            GameObject.Find("player").GetComponent<MovementeByAle>().canWallclimb = true;
        }
    }

    void OnTriggerExit(Collider theCollision)
    {
        if (theCollision.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().isgrounded = false;
        }
    }
}
