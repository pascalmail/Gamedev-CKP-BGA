using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public const float MAX_POWER = 60;
    public float power;
    public bool isCharging;
    public bool isMoving;

    void Start ()
    {
        power = 0;
        isCharging = false;
        isMoving = false;
    }

    void Update ()
    {
        Vector3 vNow = this.rigidbody.velocity;
        if (vNow.magnitude < 0.001) {
            isMoving = false;
        }

//        if (!isMoving) {
//            if (Input.GetButtonDown ("Jump")) {
//                isCharging = true;
//            }
//            if (Input.GetButtonUp ("Jump")) {
//                isCharging = false;
//                Vector3 impulse = this.transform.localToWorldMatrix.MultiplyVector (new Vector3 (0, 0, this.rigidbody.mass * power));
//                this.rigidbody.AddForce (impulse, ForceMode.Impulse);
//            }
//        }
//        if (isCharging) {
//            power += MAX_POWER * Time.deltaTime;
//            if (power > MAX_POWER) {
//                power = MAX_POWER;
//                
//            }
//        } else {
//            power = 0;
//        }
    }


    void FixedUpdate ()
    {

        if (!isMoving) {
            float rotateLeft = Input.GetAxis ("Horizontal");
            this.transform.Rotate (new Vector3 (0, 1, 0), rotateLeft * 180 * Time.deltaTime);
        }
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Wall")) {
//            Vector3 tempV = this.rigidbody.velocity;
//            this.rigidbody.velocity = Vector3.Reflect(tempV, transform.norm);
            this.rigidbody.velocity = Vector3.zero;
            //this.rigidbody.isKinematic = true;
        }
    }
    public void move(float power, bool isFinish)
    {
        if (!isFinish) {
            isMoving = true;
            Vector3 impulse = this.transform.localToWorldMatrix.MultiplyVector (new Vector3 (0, 0, this.rigidbody.mass * power));
            this.rigidbody.AddForce (impulse, ForceMode.Impulse);
        }
    }
}
