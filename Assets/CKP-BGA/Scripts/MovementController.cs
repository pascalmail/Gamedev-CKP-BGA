using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public Transform startArea;
    private bool win;
	// Use this for initialization
	void Start () {
        win = false;
        this.transform.position = startArea.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    foreach (Transform child in transform) {
            if (child.name.Contains("Wheel")) {
                child.Rotate(new Vector3(0,-1,0) * Time.deltaTime * 90);
                
            }
        }
	}

    void OnTriggerEnter(Collider other) {
        win = true;
    }

    void OnGUI() {
        if (win) {
            GUI.TextArea (new Rect (0, 200, 100, 50), "WIN!!");
        }
    }

}
