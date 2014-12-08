﻿using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour {

    public GameObject destination;

    void Start()
    {
        print ("start");
    }
    void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;
        print (other.tag);
        if (other.CompareTag ("Player")) {
            other.SendMessage ("Warp", destination.transform.position);
        }
        else if  (other.CompareTag ("Enemy")) {
            other.SendMessage ("Warp", destination.transform.position);

        }
    }

}
