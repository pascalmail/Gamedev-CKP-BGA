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
        
    }


    void FixedUpdate ()
    {
        if (!isMoving) {
            if (Input.GetButtonDown ("Jump")) {
                isCharging = true;
            }
            if (Input.GetButtonUp ("Jump")) {
                isCharging = false;
                Vector3 impulse = this.transform.localToWorldMatrix.MultiplyVector(new Vector3(0,0,this.rigidbody.mass*power));
                this.rigidbody.AddForce(impulse, ForceMode.Impulse);
//                this.rigidbody.velocity = this.transform.localToWorldMatrix * new Vector4(0, 0, speed, 0);
            }

            float rotateLeft = Input.GetAxis ("Horizontal");
            this.transform.Rotate (new Vector3 (0, 1, 0), rotateLeft * 180 * Time.deltaTime);
        }
        if (isCharging) {
            power += MAX_POWER * Time.deltaTime;
            if (power > MAX_POWER) {
                power = MAX_POWER;

            }
        } else {
            power = 0;
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Wall")) {
            this.rigidbody.velocity = Vector3.zero;
            //this.rigidbody.isKinematic = true;
        }
    }
}
