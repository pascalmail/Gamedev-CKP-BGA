using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    public bool isMoving;
    public GameObject destination;
    public bool isPlaying;
    public bool rotate;

    private NavMeshAgent _agent;
    private Vector3 nextTarget;
    private bool hasNextTarget;

    private float angle;
    private float rotation;
    private float powerMultiplier;
    private bool hasMultiplier;
    private bool neg;
    private float step;
   
    void Start ()
    {
        isPlaying = false;
        isMoving = false;
        _agent = GetComponent<NavMeshAgent> ();
        _agent.SetDestination (destination.transform.position);

        hasMultiplier = false;
        powerMultiplier = 1;
        nextTarget = _agent.steeringTarget;
        hasNextTarget = true;
        rotate = true;
        rotation = 0.3f;
    }

    void Warp(Vector3 target)
    {
       
        _agent.Warp (target);
       
        _agent.SetDestination (destination.transform.position);
        print ("Warp");
    }

    void setPowerMultiplier(float multiplier)
    {
        hasMultiplier = true;
        powerMultiplier = multiplier;
        print ("Boost");
    }

    void rotateAI()
    {

        if (!isMoving && rotate) {

            angle = Vector3.Angle (transform.forward, (nextTarget - transform.position));
            neg = Vector3.Cross(transform.forward,(nextTarget - transform.position)).y < 0 ;
            
            step = 180 * Time.deltaTime * rotation;

            if(neg)
                this.transform.Rotate (new Vector3 (0, -1, 0), step);
            else
                this.transform.Rotate (new Vector3 (0, 1, 0), step);

            if (Mathf.Abs (angle) <= 1) 
                rotate = false;
        }
        //print (nextTarget +" : "+transform.position+" : "+transform.forward+" : "+angle+" : "+rotate+" : "
        //       +this.rigidbody.velocity+" : "+isMoving+" : "+step+" : "+neg+" : "
        //       +Vector3.Cross(transform.forward,(nextTarget - transform.position)));
    }

    void setNextTarget()
    {
        if (nextTarget != _agent.steeringTarget) {
            //rigidbody.isKinematic=false;
            this.rigidbody.velocity = Vector3.zero;
            //rigidbody.isKinematic = true;
            nextTarget = _agent.steeringTarget;
        }
    }

    void forceStop() {
        _agent.Stop(true);
        //rigidbody.isKinematic = false;
        this.rigidbody.velocity = Vector3.zero;
        this._agent.velocity = Vector3.zero;
        _agent.Resume();
        //rigidbody.isKinematic = true;
    }

    void Update ()
    {    
        if (isPlaying && isMoving) {
            Vector3 vNow = this.rigidbody.velocity;
            if (vNow.magnitude <= 0.2) {
                isMoving = false;
                isPlaying = false;
                
                //this.rigidbody.velocity = Vector3.zero;
                //this._agent.velocity = Vector3.zero;
                forceStop ();
                setNextTarget ();
            }
        }
    }

    void FixedUpdate ()
    {
        if (isPlaying) {
            rotateAI ();
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
            //rigidbody.isKinematic = false;
            rigidbody.AddForce (impulse, ForceMode.Impulse);
            //rigidbody.isKinematic = true;
        }
    }
}
