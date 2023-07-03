using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField] GameObject P1, P2, Ball, ufoExplosion, shield;
    [SerializeField] float force, offset, ballVelocity = 5f;
    Rigidbody ballRigidBody;
    Vector3 newDirection;
    GameObject newExplosion;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = Ball.GetComponent<Rigidbody>();
        ballRigidBody.velocity = new Vector3(0,-ballVelocity, 0) * Time.deltaTime;
        ballRigidBody.transform.rotation = new Quaternion (180f, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MaintainballVelocity();
        Debug.Log (shield.GetComponent<MeshFilter>().mesh.normals);
    }

    private void MaintainballVelocity()
    {
        ballRigidBody.velocity = Ball.transform.rotation.eulerAngles.normalized * ballVelocity;
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
            //Change Direction of ball when it hits obstacle
            ReflectBall(other);
            StartCoroutine(ExplodeUFO(other));
        }
        if (other.gameObject.tag == "Shield")
        {
            ReflectBall(other);
        }
        if (other.gameObject.tag == "upperBound")
        {
            Ball.transform.position = P1.transform.position + new Vector3(0, -offset, 0);
        }
        if (other.gameObject.tag == "lowerBound")
        {
            Ball.transform.position = P2.transform.position + new Vector3(0, offset, 0);
        }
    }

    private IEnumerator ExplodeUFO(Collision other)
    {
        newExplosion = Instantiate(ufoExplosion, other.gameObject.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        yield return new WaitForSecondsRealtime(1f);
        Destroy(newExplosion);
    }

    private void ReflectBall(Collision other)
    {
        newDirection = Vector3.Reflect(Ball.transform.forward, -other.contacts[0].normal).normalized;
        Ball.transform.rotation = Quaternion.LookRotation(newDirection);
        //Debug.Log(other.contacts[0].normal);
        //Ball.transform.forward = Ball.transform.rotation.eulerAngles.normalized;
    }
}
