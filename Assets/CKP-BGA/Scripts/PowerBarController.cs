using UnityEngine;
using System.Collections;

public class PowerBarController : MonoBehaviour {

    public PlayerController pController;
    public Texture2D image;
    public Texture2D emptyBarTexture;

    float bar;
    float barSpeed;

    void Start()
    {
        bar = 0;
        barSpeed = 2.5f;

    }

    void FixedUpdate()
    {
        if (!pController.isMoving) {
            if (bar >= 60 || bar < 0) {
                barSpeed = barSpeed * -1;
            }
            bar = bar + barSpeed;
        }

    }

    void Update()
    {
        if (!pController.isMoving) {
            //float filledWidth = pController.power / PlayerController.MAX_POWER * image.width;
            if(Input.GetKeyDown(KeyCode.Space)){
                pController.move(bar);
            }
        }
    }
    void OnGUI()
    {   
        GUI.Box (new Rect (0, 0, image.width + 10, image.height), "POWER");
        GUI.DrawTextureWithTexCoords (new Rect (5, image.height / 2, bar*(512/60), 20), image, new Rect (0, 0, (float)(bar / 60), 1));
    }
}