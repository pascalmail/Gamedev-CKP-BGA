using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public int turnNumber;
    public int actorPlaying;
    //private GameObject[] actor;
    //private PlayerController[] states;
    public AIController aiController;
    //public PlayerController pController;

    void Start() {
        //actor = GameObject.FindGameObjectsWithTag("Player");
        //states = GameObject.FindObjectsOfType<PlayerController> ();
//        actor[0].GetC
        turnNumber = 0;
        actorPlaying = 1;
        print ("game controller : start");

    }

    void switchTurn()
    {
        if (actorPlaying == 1) {
            if (!aiController.isNowPlaying) {
                aiController.SendMessage ("startTurn", true);
            } else if (!aiController.isMoving && !aiController.rotate) {
                aiController.SendMessage ("startTurn", false);
                actorPlaying = 2;
            }
            //} else if (actorPlaying == 2 && !pController.isNowPlaying) {
        } else if(actorPlaying == 2){
            actorPlaying = 1;
        }
    }

    void Update() {
        // find angle
        switchTurn ();
        // find power

        // shoot

        // save status

        // change
    }


    IEnumerable<int> test() {
        for(int i = 0; i < 5; ++i ) {
            yield return i;
        }
    }

}
