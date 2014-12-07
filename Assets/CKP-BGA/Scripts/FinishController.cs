using UnityEngine;
using System.Collections;

/// <summary>
/// Finish controller.
/// </summary>
public class FinishController : MonoBehaviour 
{
    float _centerX=0;
    float _centerY=0;

    string message = "YOU WIN!";
    
    bool isWin=false;
    public bool isFinish=false;
    
    void Start()
    {
        _centerX = Screen.width / 3;
        _centerY = Screen.height / 3;
    }
    
    void OnTriggerEnter(Collider collider) 
    {
        GameObject other = collider.gameObject;

        print (other.tag);
        if(other.CompareTag("Player")){
            isWin = true;
            isFinish = true;
         
        }
        print (isWin);

    }
    
    void OnGUI()
    {
        if (isFinish) {
            GUI.Box (new Rect (_centerX, _centerY, Screen.width/ 3, Screen.height / 3 ), message);
        }
        
        
    }

}