using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
//    public enum PlayerState {CHARGING, MOVING};

    public const float MAX_POWER = 60;
    public float power;
    public bool isCharging;
    public bool isMoving;
    public float speedx;
    public float speedy;
    public float speedz;

    void Start ()
    {
        power = 0;
        isCharging = false;
        isMoving = false;
    }

    void Update ()
    {
        if (!isMoving) {
            if (Input.GetButtonDown ("Jump")) {
                isCharging = true;
            }
            if (Input.GetButtonUp ("Jump")) {
                isCharging = false;
                Vector3 impulse = this.transform.localToWorldMatrix.MultiplyVector (new Vector3 (0, 0, this.rigidbody.mass * power));
                this.rigidbody.AddForce (impulse, ForceMode.Impulse);
                isMoving = true;
            }
        } else {
            Vector3 vNow = this.rigidbody.velocity;
            if (vNow.magnitude < 0.001) {
                this.rigidbody.velocity = Vector3.zero;
                isMoving= false;
            }
        }

        if (isCharging) {
            power += MAX_POWER * Time.deltaTime;
            if (power > MAX_POWER) {
                power = MAX_POWER;
                
            }
        } else {
            power = 0;
        }
        Vector3 tmp = this.transform.localToWorldMatrix.MultiplyVector (this.rigidbody.velocity);
        speedx = tmp.x;
        speedy = tmp.y;
        speedz = tmp.z;
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
            this.rigidbody.velocity = Vector3.zero;
            isMoving = false;
            //this.rigidbody.isKinematic = true;
        }
        if (other.gameObject.tag.Equals ("Wind")) {
            this.rigidbody.AddForce(new Vector3(0, this.rigidbody.mass * 20, 0), ForceMode.Impulse);
            print("AW");
        }

    }
    void OnTriggerEnter(Collider other) {
    }
}
