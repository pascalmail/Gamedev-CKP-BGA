using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private GameObject gc;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        gc = GameObject.FindGameObjectWithTag ("GameController");
        player = gc.GetComponent<GameController>().playing;
        offset = player.transform.position - transform.position;

	}


    void LateUpdate() {
        player = gc.GetComponent<GameController>().playing;
        offset = player.transform.position - transform.position;
        transform.LookAt (player.transform);
    }
}
