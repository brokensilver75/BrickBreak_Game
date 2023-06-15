using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    bool rightBound = false;
    bool leftBound = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A) && !leftBound)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            
        }

        if (Input.GetKey(KeyCode.D) && !rightBound)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "LeftWall" )
        {
            leftBound = true;
        }
        if (collision.gameObject.tag == "RightWall")
        {
            rightBound = true;
        }*/
    }
}
