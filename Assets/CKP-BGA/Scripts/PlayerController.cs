using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    public bool isPlaying;
    public bool rotate;

    private float angle;
    private float powerMultiplier;
    private bool hasMultiplier;
    private bool neg;
    private float step;

    public float x, y, z;

    
    void Start ()
    {
        isPlaying = false;
        isMoving = false;

        hasMultiplier = false;
        powerMultiplier = 1;
        rotate = true;
    }
    
    void setPowerMultiplier(float multiplier)
    {
        hasMultiplier = true;
        powerMultiplier = multiplier;
        print ("Boost");
    }

    void forceStop() {

        //rigidbody.isKinematic = false;
        this.rigidbody.velocity = Vector3.zero;
        //rigidbody.isKinematic = true;
    }
    
    void Update ()
    {    
        x = this.rigidbody.velocity.x;
        y = this.rigidbody.velocity.y;
        z = this.rigidbody.velocity.z;


        if (isPlaying && isMoving) {
            Vector3 vNow = this.rigidbody.velocity;
            if (vNow.magnitude <= 0.2) {
                print ("STOP");
                isMoving = false;

                isPlaying = false;    
                //print (isPlaying);
                //this.rigidbody.velocity = Vector3.zero;
                //this._agent.velocity = Vector3.zero;
                forceStop ();
            }
        }
    }

    void Warp (Vector3 target)
    {
        transform.position = target;
    }

    void FixedUpdate ()
    {
        if (isPlaying) {
            if (!isMoving) {
                float rotateLeft = Input.GetAxis ("Horizontal");
                //print(rotateLeft);
                this.transform.Rotate (new Vector3 (0, 1, 0), rotateLeft * 180 * Time.deltaTime);
            }
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
            rotate = true;
            if(hasMultiplier){
                power = power * powerMultiplier;
                hasMultiplier = false;
            }
            print (power);
            Vector3 impulse = this.transform.localToWorldMatrix.MultiplyVector (new Vector3 (0, 0, this.rigidbody.mass * power));
            this.rigidbody.AddForce (impulse, ForceMode.Impulse);
        }
    }
}
