using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public int turnNumber;
    public int actorPlaying;
    private GameObject[] actor;
    private PlayerController[] states;

    void Start() {
        actor = GameObject.FindGameObjectsWithTag("Player");
        states = GameObject.FindObjectsOfType<PlayerController> ();
//        actor[0].GetC

    }



    void Update() {

        // find angle

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
