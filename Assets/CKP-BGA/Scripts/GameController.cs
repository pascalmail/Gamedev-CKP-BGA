using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public int turnNumber;
    public int actorPlaying;
    private GameObject[] players;
    private GameObject[] enemies;


    void Awake() {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag ("Enemy");
    }


    void Start() {
        StartCoroutine (Play ());
    }


    IEnumerator Play() {
        while (true) {
            foreach (GameObject p in players) {
                PlayerController pc = p.GetComponent<PlayerController>();
                pc.isPlaying = true;

                while (pc.isPlaying) {}

            }

            foreach(GameObject e in enemies) {
                AIController ac = e.GetComponent<AIController>();
                ac.isPlaying = true;

                while (ac.isPlaying) {}

            }
        }
    }

    IEnumerable<int> test() {
        for(int i = 0; i < 5; ++i ) {
            yield return i;
        }
    }

}
