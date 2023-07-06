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

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        newDirection = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            startMoving = true;
        }

        if (startMoving == true)
        {
            MaintainBallVelocity(newDirection);
        }
    }

    void MaintainBallVelocity(Vector3 direction)
    {
        ballRb.velocity = direction * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "P1": transform.position = p2.transform.position + new Vector3(0, -7, 0);
            break;
            case "P2": transform.position = p1.transform.position + new Vector3(0, 7, 0);
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
