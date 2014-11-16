using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public const float MAX_SPEED = 60;
    public float speed;
    public bool isCharging;
    public bool isMoving;


    void Start ()
    {
        speed = 0;
        isCharging = false;
        isMoving = false;
    }

    void Update ()
    {
        
    }


    void FixedUpdate ()
    {
        if (!isMoving) {
            if (Input.GetButtonDown ("Jump")) {
                isCharging = true;
            }
            if (Input.GetButtonUp ("Jump")) {
                isCharging = false;
                this.rigidbody.velocity = this.transform.localToWorldMatrix * new Vector4(0, 0, speed, 0);
            }

            float rotateLeft = Input.GetAxis ("Horizontal");
            this.transform.Rotate (new Vector3 (0, 1, 0), rotateLeft * 180 * Time.deltaTime);
        }
        if (isCharging) {
            speed += MAX_SPEED * Time.deltaTime;
            if (speed > MAX_SPEED) speed = MAX_SPEED;
        } else {
            speed = 0;
        }




    }
}
