using UnityEngine;
using System.Collections;

public class MiniMapController : MonoBehaviour {

    private Vector3 offset;
    private GameObject gc;
    private GameObject player;
    public float x, y, z;

	// Use this for initialization
	void Start () {
        //this.camera.pixelRect = new Rect (0, 0, 100, 100);
        this.camera.fieldOfView = 45;
        gc = GameObject.FindGameObjectWithTag ("GameController");
        player = gc.GetComponent<GameController>().playing;
	}
	
	// Update is called once per frame
	void Update () {
        player = gc.GetComponent<GameController>().playing;
        x = this.camera.transform.position.x;
        y = this.camera.transform.position.y;
        z = this.camera.transform.position.z;
        Vector3 t = player.transform.position;
        t.y = 100;


        this.camera.transform.position = t;
	}
}
