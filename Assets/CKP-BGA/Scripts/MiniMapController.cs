using UnityEngine;
using System.Collections;

public class MiniMapController : MonoBehaviour {

    private Vector3 offset;
	// Use this for initialization
	void Start () {
        //this.camera.pixelRect = new Rect (0, 0, 100, 100);
        this.camera.fieldOfView = 45;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
