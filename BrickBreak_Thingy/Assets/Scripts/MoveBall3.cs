using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall3 : MonoBehaviour
{
    [SerializeField] GameObject p1, p2, ufoExplosion;
    [SerializeField] float posOffset, ballSpeed = 10f;
    Rigidbody ballRigidBody;
    Vector3 newDirection;
    GameObject newExplosion;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        ballRigidBody = GetComponent<Rigidbody>();
        newDirection = new Vector3 (0, -1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MaintainBallVelocity(newDirection);
    }

    private void MaintainBallVelocity(Vector3 direction)
    { 
        if (direction.x == 0 && direction.y == 0)
        {
            if (ballRigidBody.velocity.y > 0)
            {
                ballRigidBody.velocity = new Vector3 (-1f, 1f , 0) * ballSpeed * Time.deltaTime;
            }
            else if (ballRigidBody.velocity.y < 0)
            {
                ballRigidBody.velocity = new Vector3 (-1f, -1f , 0) * ballSpeed * Time.deltaTime;
            }
            else if (ballRigidBody.velocity.y == 0)
            {
                if (ballRigidBody.velocity.x == 1 || ballRigidBody.velocity.x == -1)
                {
                    ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, -1, 0);
                }
            }
            
        }
        else
        {
            ballRigidBody.velocity = direction * ballSpeed * Time.deltaTime;
        }
    }

    private void ReflectBall(Collision other)
    {
        newDirection = Vector3.Reflect(ballRigidBody.velocity, other.contacts[0].normal).normalized;
        //Debug.Log("X:   " + ballRigidBody.velocity.x + "\nY:    " + ballRigidBody.velocity.y);
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "P1": transform.position = p2.transform.position + new Vector3(0, -posOffset, 0);
            break;
            case "P2": transform.position = p1.transform.position + new Vector3(0, posOffset, 0);
            break;
            case "Obstacle": ReflectBall(other);
            StartCoroutine(ExplodeUFO(other));
            break;
            case "Shield": ReflectBall(other);
            break;
            case "upperBound": transform.position = p1.transform.position + new Vector3(0, posOffset, 0);
            break;
            case "lowerBound": transform.position = p2.transform.position + new Vector3(0, -posOffset, 0);
            break;
            default:
            break;
        }
    }

    private IEnumerator ExplodeUFO(Collision other)
    {
        newExplosion = Instantiate(ufoExplosion, other.gameObject.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        yield return new WaitForSecondsRealtime(1f);
        Destroy(newExplosion);
    }
}
