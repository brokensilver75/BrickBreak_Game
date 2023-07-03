using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall2 : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody ballRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody>();
        transform.forward = new Vector3 (0, -1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ballRigidBody.velocity = transform.forward * speed * Time.deltaTime;
    }
}
