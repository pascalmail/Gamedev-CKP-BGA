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
        // rotate wheel
	    foreach (Transform child in transform) {
            if (child.name.Contains("Wheel")) {
//                child.Rotate(new Vector3(0,-1,0) * Time.deltaTime * 90);
                
            }
        }
	}

    void OnTriggerEnter(Collider other) {
        win = true;
        if (other.tag == "FinishArea") {
            if (Application.loadedLevelName == "GameplayTester") {
                Application.LoadLevel ("Level 1");
            }
            if (Application.loadedLevelName == "Level 1") {
                Application.LoadLevel ("Level 2");
            }
        }
    }

    void OnGUI() {
        GUI.TextArea(new Rect(0, Screen.height - 50, 100, 50), ((int)this.rigidbody.velocity.magnitude).ToString());
        if (win) {
            GUI.TextArea (new Rect (0, 200, 100, 50), "WIN!!");
        }
    }

}
