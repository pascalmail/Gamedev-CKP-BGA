using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public int turnNumber;
    public int actorPlaying;
    public GameObject playing;

    private GameObject[] players;
    private GameObject[] enemies;


    void Awake() {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag ("Enemy");

        if (players.Length > 0) {
            playing = players [0];
        }
        else {
            playing = enemies[0];
        }
    }


    void Start() {
        StartCoroutine (Play ());
    }

    void Update() {

    }

    IEnumerator Play() {
        yield return new WaitForSeconds (2);
        while (true) {
            //print ("A");
            foreach (GameObject p in players) {
                playing = p;
                print (players.Length);
                PlayerController pc = p.GetComponent<PlayerController>();

                pc.isPlaying = true;
                print(pc.name+" is playing");

                while (pc.isPlaying) {
                    yield return 0;
                    if (!p.GetComponent<PlayerController>().isPlaying) {
                        //print("XX");
                        break;
                    }

                }
                //print ("B");
            }

            //print("C");
            foreach(GameObject e in enemies) {
                playing = e;
                AIController ac = e.GetComponent<AIController>();
                ac.isPlaying = true;
                print (ac.name+" is playing");

                while (ac.isPlaying) {
                    yield return 0;
                }
                ac.isPlaying = false;


            }
        }
    }

    IEnumerable<int> test() {
        for(int i = 0; i < 5; ++i ) {
            yield return i;
        }
    }

}
