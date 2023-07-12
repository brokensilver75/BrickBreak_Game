using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;
    GameManager gameManager;
    Vector3 newDirection;
    Rigidbody ballRb;
    bool startMoving = false;
    [Header("Player Portal")]
    [SerializeField]GameObject p1, p2;
    TrailRenderer trail0, trail1;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        newDirection = new Vector3(0, -1, 0);
        trail0 = transform.GetChild(0).gameObject.GetComponent<TrailRenderer>();
        trail1 = transform.GetChild(1).gameObject.GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            startMoving = true;
        }

        
        //Debug.Log(ballRb.velocity);
    }

    void FixedUpdate()
    {
        if (startMoving == true)
        {
            MaintainBallVelocity(newDirection);
        }
    }

    void MaintainBallVelocity(Vector3 direction)
    {
        /*if(direction.z != 0 && direction.x == 0)
        {
            direction.x = direction.z;
            direction.z = 0;
        }*/
        float speed = moveSpeed * Time.deltaTime;
        speed = Mathf.Clamp(speed, 3, 5);
        ballRb.velocity = direction * speed;            
        Debug.Log (direction.x);
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "P1":  transform.position = p2.transform.position + new Vector3(0, -1, 0); 
                        trail0.Clear();
                        trail1.Clear();                                               
                        break;
            case "P2":  transform.position = p1.transform.position + new Vector3(0, 1, 0);
                        trail0.Clear();
                        trail1.Clear();
                        break;
            case "UFO": ReflectBall(other);
                        Destroy(other.gameObject);
                        break;
            case "Shield": ReflectBall(other);
                           break;
            default: break;
        }
    }

    void ReflectBall(Collision collidingObject)
    {
        newDirection = Vector3.Reflect(newDirection, collidingObject.contacts[0].normal);
        newDirection = Vector3.Normalize(newDirection);
    }
}
