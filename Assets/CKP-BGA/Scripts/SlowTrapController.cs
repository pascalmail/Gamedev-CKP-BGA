using UnityEngine;
using System.Collections;

public class SlowTrapController : MonoBehaviour {

    // Use this for initialization
    void Start () 
    {
    }
    
    void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;
        
        if (other.CompareTag ("Player") || other.CompareTag ("NPC")) {
            other.SendMessage("SetPowerMultiplier", 0.5f);
        }
    }
}
