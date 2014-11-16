using UnityEngine;
using System.Collections;

public class PowerBarController : MonoBehaviour {

    public GameObject player;
    public Texture2D image;

    void OnGUI()
    {
        GUI.DrawTextureWithTexCoords (new Rect (5, 5, player.power, 20), image, new Rect (0, 0, (float)(player.power / image.width), 1));
    }
}