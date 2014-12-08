using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    
    public const float MAX_POWER = 60;
    public float power;
    public bool isCharging;
    public bool isMoving;
    public GameObject destination;
    
    private NavMeshAgent _agent;
    private Vector3 nextTarget;
    private bool hasNextTarget;
    private bool rotate;
    private float angle;
    private float rotation;
    private float powerMultiplier;
    private bool hasMultiplier;
    void Start ()
    {
        power = 0;
        isCharging = false;
        isMoving = false;
        _agent = GetComponent<NavMeshAgent> ();
        _agent.SetDestination (destination.transform.position);

        hasMultiplier = false;

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

    void etPowerMultiplier(float multiplier)
    {
        hasMultiplier = true;
        powerMultiplier = multiplier;
        print ("Boost");
    }
    void rotateAI()
    {
        float step = 0;
        if (!isMoving && rotate) {
            angle = Vector3.Angle(transform.forward, (nextTarget - transform.position));

            step = 180 * Time.deltaTime * rotation;
            this.transform.Rotate (new Vector3 (0, 1, 0), step);
            if(Mathf.Abs(angle) <= 1) 
                rotate = false;
        }
        //print (nextTarget +" : "+transform.position+" : "+transform.forward+" : "+angle+" : "+rotate+" : "+this.rigidbody.velocity+" : "+isMoving+" : "+step);
    }
    void setNextTarget()
    {
        if (nextTarget != _agent.steeringTarget) {
            this.rigidbody.velocity = Vector3.zero;
            nextTarget = _agent.steeringTarget;
        }
    }
    void Update ()
    {
        
        Vector3 vNow = this.rigidbody.velocity;
        if (vNow.magnitude <= 0.1) {
            isMoving = false;
            this.rigidbody.velocity = Vector3.zero;
            
            setNextTarget();
        }

    }
    
    
    void FixedUpdate ()
    {
            rotateAI ();
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
            Vector3 impulse = this.transform.localToWorldMatrix.MultiplyVector (new Vector3 (0, 0, this.rigidbody.mass * power));
            this.rigidbody.AddForce (impulse, ForceMode.Impulse);
        }
    }
}
