using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField] GameObject P1, P2, Ball;
    [SerializeField] float force, offset, ballVelocity = 5f;
    Rigidbody ballRigidBody;
    Vector3 newDirection;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = Ball.GetComponent<Rigidbody>();
        ballRigidBody.velocity = new Vector3(0,-ballVelocity, 0) * Time.deltaTime;
        Ball.transform.forward = new Vector3(0, -1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MaintainballVelocity();
        //Debug.Log(Ball.transform.forward);
    }

    private void MaintainballVelocity()
    {
        ballRigidBody.velocity = Ball.transform.forward * ballVelocity;
    }

    void OnCollisionEnter(Collision other)
    {
       
        
        if (other.gameObject.tag == "P1")
        {
            Ball.transform.position = P2.transform.position + new Vector3(0, -offset, 0);
        }
        if (other.gameObject.tag == "P2")
        {
            Ball.transform.position = P1.transform.position + new Vector3(0, offset, 0);
        }
        if (other.gameObject.tag == "Obstacle")
        {
              newDirection = Vector3.Reflect(Ball.transform.forward, -other.contacts[0].normal).normalized;
              Ball.transform.rotation = Quaternion.LookRotation(newDirection);
              //Ball.transform.position = Vector3.Reflect(Ball.transform.forward, other.contacts[0].normal).normalized;
              
        }
    }
}
