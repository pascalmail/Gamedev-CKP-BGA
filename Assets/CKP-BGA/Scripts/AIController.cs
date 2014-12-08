using UnityEngine;
using System.Collections;

/*
 * x = 180*n
 * 360 = 180*2t
 * 
 * n = x*2t/180
 * 
 * */

public class AIController : MonoBehaviour
{
    
    public const float MAX_POWER = 60;
    public float power;
    public bool isCharging;
    public bool isMoving;
    public bool isPlaying;
    public GameObject destination;
    
    private NavMeshAgent _agent;
    private Vector3 nextTarget;
    private bool hasNextTarget;

    private float angleFull;
    private float angleLeft;
    private bool neg;

    void Start ()
    {
        power = 0;
        isCharging = false;
        isMoving = false;
        isPlaying = false;
        _agent = GetComponent<NavMeshAgent> ();
        _agent.SetDestination (destination.transform.position);
        
        nextTarget = _agent.steeringTarget;
        hasNextTarget = true;

        angleLeft = Vector3.Angle(transform.forward, (_agent.steeringTarget - transform.position));
        angleFull = angleLeft;
        neg = Vector3.Cross((_agent.steeringTarget - transform.position), transform.forward).z < 0 ;
    }

    void setNextTarget()
    {
        if (nextTarget != _agent.steeringTarget) {
            forceStop();
        }
    }
    void Update ()
    {
        if (isPlaying) {
            if (!isMoving) {
                // update power


            } else {
                Vector3 vNow = this.rigidbody.velocity;
                print(vNow.magnitude);
                if (vNow.magnitude <= 0.1) {

                    isMoving = false;
                    isPlaying = false;

                    forceStop();


                    setNextTarget ();
                    angleLeft = Vector3.Angle(transform.forward, (_agent.steeringTarget - transform.position));
                    neg = Vector3.Cross((_agent.steeringTarget - transform.position), transform.forward).z < 0 ;
                    angleFull = angleLeft;
                }
            }
        }



    }
    
    
    void FixedUpdate ()
    {
        if (isPlaying) {

            if (!isMoving) {
                float angle = angleFull*Time.deltaTime;


                if (neg) {
                    this.transform.Rotate (new Vector3 (0, -1, 0), angle);
                    angleLeft -= angle;
                }
                else {
                    this.transform.Rotate (new Vector3 (0, 1, 0), angle);
                    angleLeft += angle;
                }

                print (angleLeft);
                if (Mathf.Abs(angleLeft) < angle ) isMoving = true;

            }
        }

    }
    
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Wall")) {
            //            Vector3 tempV = this.rigidbody.velocity;
            //            this.rigidbody.velocity = Vector3.Reflect(tempV, transform.norm);


            forceStop();


            isMoving = false;
            //this.rigidbody.isKinematic = true;
        }
    }

    void forceStop() {
        _agent.Stop(true);
        rigidbody.isKinematic = false;
        this.rigidbody.velocity = Vector3.zero;
        this._agent.velocity = Vector3.zero;
        _agent.Resume();
        rigidbody.isKinematic = true;
    }
//    public void move(float power, bool isFinish)
//    {
//        if (!isFinish) {
//            isMoving = true;
//            //rotate = true;
//            Vector3 impulse = this.transform.localToWorldMatrix.MultiplyVector (new Vector3 (0, 0, this.rigidbody.mass * power));
//            this.rigidbody.AddForce (impulse, ForceMode.Impulse);
//        }
//    }
}
