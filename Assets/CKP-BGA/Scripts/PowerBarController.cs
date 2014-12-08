using UnityEngine;
using System.Collections;

public class PowerBarController : MonoBehaviour {

    public FinishController fController;
    public Texture2D image;
    public Texture2D emptyBarTexture;

    public GameObject playing;

    float bar;
    float barSpeed;

    void Start()
    {
        bar = 0;
        barSpeed = 2.5f;
        playing = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().playing;
    }

    void FixedUpdate()
    {

        //print (fController.isFinish);
        if(playing.CompareTag("Player")) {
            if (!playing.GetComponent<PlayerController>().isMoving && !fController.isFinish) {
                if (bar >= 60 || bar < 0) {
                    barSpeed = barSpeed * -1;
                }
                bar = bar + barSpeed;
            }
        }

    }

    void Update()
    {
        playing = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().playing;
        if (playing.CompareTag ("Player")) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                playing.GetComponent<PlayerController>().move (bar, fController.isFinish);
            }
        } else if (playing.CompareTag ("Enemy")) {
            if(!playing.GetComponent<AIController>().isMoving && !playing.GetComponent<AIController>().rotate){
                float temp = Random.value * 60;
                print ("KLIK "+temp);
                playing.GetComponent<AIController>().move (temp, fController.isFinish);
            }
        }

    }
    void OnGUI()
    {   
        GUI.Box (new Rect (0, 0, image.width + 10, image.height), "POWER");
        if(playing.CompareTag("Player")) {
            GUI.DrawTextureWithTexCoords (new Rect (5, image.height / 2, bar*(512/60), 20), image, new Rect (0, 0, (float)(bar / 60), 1));
        }

    }
}
