using UnityEngine;
using System.Collections;

public class PowerBarController : MonoBehaviour {

    public PlayerController pController;
    public Texture2D image;
    public Texture2D emptyBarTexture;

    void OnGUI()
    {   
        GUI.Box (new Rect (0, 0, image.width, image.height), "POWER");
        float filledWidth = pController.power / PlayerController.MAX_POWER * image.width;
        GUI.DrawTextureWithTexCoords (new Rect (5, 5, filledWidth, 20), image, new Rect (0, 0, (float)(filledWidth / image.width), 1));
    }
}