using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GUISkin mySkin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.skin = mySkin;
        GUI.BeginGroup (new Rect (Screen.width / 2 - 160, Screen.height / 2 - 30, 320, 260));
        GUI.Box (new Rect(0,0,320, 260), "");
        GUI.TextArea (new Rect (10, 10, 300, 50), "CKP BGA");

        if(GUI.Button(new Rect(10, 70, 300, 50), "Level Development")) {
            Application.LoadLevel("GameplayTester");
        }
        if(GUI.Button(new Rect(10, 130, 300, 50), "Level 1")) {
            Application.LoadLevel("Level 1");
        }
        if(GUI.Button(new Rect(10, 190, 300, 50), "Level 2")) {
            Application.LoadLevel("Level 2");
        }
        GUI.EndGroup ();
    }
}
