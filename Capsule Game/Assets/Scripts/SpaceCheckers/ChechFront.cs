using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechFront : MonoBehaviour {

    void OnTriggerEnter(Collider theCollision)
    {
        if (theCollision.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().canFoward = false;
        }
    }

    void OnTriggerExit(Collider theCollision)
    {
        if (theCollision.gameObject.tag == "Structure")
        {
            GameObject.Find("player").GetComponent<MovementeByAle>().canFoward = true;
        }
    }
}
