using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField] GameObject P1, P2, Ball;
    [SerializeField] float force, offset;
    Rigidbody ballRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = Ball.GetComponent<Rigidbody>();
        ballRigidBody.AddForce(0, -force, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
