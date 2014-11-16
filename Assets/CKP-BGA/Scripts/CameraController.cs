using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void LateUpdate() {
        transform.LookAt (player.transform);
        //transform.position = player.transform.position + offset;
    }
}
