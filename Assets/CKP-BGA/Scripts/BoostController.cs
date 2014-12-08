using UnityEngine;
using System.Collections;

public class BoostController : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	}
	
	void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;

        if (other.CompareTag ("Player") || other.CompareTag ("NPC")) {
            other.SendMessage("SetPowerMultiplier", 1.5f);
        }
    }
}
